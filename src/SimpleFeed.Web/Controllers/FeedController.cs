namespace SimpleFeed.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Base;
    using Core.FeedEntries;
    using Core.User;
    using Data.Commands.FeedEntries;
    using Data.OperationInputs;
    using Data.Queries;
    using Data.Storage;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models.FeedViewModels;
    using Services;
    using _Configuration;

    public class FeedController : BaseController
    {
        private readonly IWebScreenshotService _screenshotService;

        public FeedController(IOptions<PersistenceConfiguration> configuration, UserManager<ApplicationUser> userManager,
            IWebScreenshotService screenshotService)
            : base(configuration, userManager)
        {
            if (screenshotService == null) throw new ArgumentNullException(nameof(screenshotService));
            _screenshotService = screenshotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entries = new GetAllEntries(Configuration.Value)
            {
                PaginationRequest = new PaginationRequest(1, 10),
                DateCreatedOrder = DateCreatedOrder.Descending,
            }.Execute();

            return View(entries);
        }

        [HttpGet]
        public IActionResult TopTen()
        {
            var entries = new GetTopEntries(Configuration.Value)
            {
                HowMany = 10
            }.Execute();

            return View(entries);
        }

        [HttpGet]
        public IActionResult GetEntry(Guid entryId)
        {
            if (entryId.Equals(Guid.Empty)) return BadRequest();

            var entry = new GetEntryById(Configuration.Value)
            {
                EntryId = entryId
            }.Execute();

            return View(entry.Output);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddFeedEntryForm()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddExternalLinkForm()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExternalLink(AddExternalLinkViewModel viewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(AddExternalLinkForm));

            var user = await UserManager.GetUserAsync(HttpContext.User);
            var command = new AddExternalLinkEntry(Configuration.Value)
            {
                ExternalLink = new ExternalLinkFeedEntry(new Uri(viewModel.LinkAddress), viewModel.Title, user.Id)
                {
                    Description = viewModel.Description
                }
            };
            var result = command.Execute();

            if (result.WasSuccessful)
            {
                var snapshotStorageCommand = new StoreUrlSnapshotImage(Configuration.Value)
                {
                    EntryId = command.ExternalLink.Id,
                    Image = await _screenshotService.GetScreenshotFor(command.ExternalLink.LinkAddress.AbsoluteUri),
                    UserId = user.Id
                };
                await snapshotStorageCommand.ExecuteAsync();
            }

            return !result.WasSuccessful
                ? RedirectToAction(nameof(AddExternalLinkForm))
                : RedirectToAction(nameof(GetEntry), new {entryId = command.ExternalLink.Id});
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddUploadedImageForm()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUploadedImage(AddUploadedImageViewModel viewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(AddUploadedImageForm));

            var user = await UserManager.GetUserAsync(HttpContext.User);

            var uploadedFilePath = await new StoreUploadedFeedImage(Configuration.Value)
            {
                UserId = user.Id,
                Image = viewModel.Image
            }.ExecuteAsync();

            var command = new AddUploadedImageEntry(Configuration.Value)
            {
                UploadedImageEntry = new UploadedImageFeedEntry(uploadedFilePath, viewModel.Title, user.Id)
                {
                    Description = viewModel.Description
                }
            };
            var result = command.Execute();

            return !result.WasSuccessful
                ? RedirectToAction(nameof(AddUploadedImageForm))
                : RedirectToAction(nameof(GetEntry), new {entryId = command.UploadedImageEntry.Id});
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditFeedEntry(Guid entryId)
        {
            if (entryId.Equals(Guid.Empty)) return BadRequest();

            var entry = new GetEntryById(Configuration.Value)
            {
                EntryId = entryId
            }.Execute();

            var user = await UserManager.GetUserAsync(HttpContext.User);
            if (!entry.Output.Creator.Id.Equals(user.Id)) return Unauthorized();

            return View(entry.Output.Model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFeedEntry(UpdateFeedEntryViewModel viewModel)
        {
            if (!ModelState.IsValid || viewModel.Id.Equals(Guid.Empty)) return RedirectToAction(nameof(Index));

            var user = await UserManager.GetUserAsync(HttpContext.User);
            var canUpdate = new CheckIfCanModifyEntry(Configuration.Value)
            {
                EntryId = viewModel.Id,
                UserId = user.Id
            }.Execute();
            if (!canUpdate.Output) return Unauthorized();

            var result = new UpdateFeedEntry(Configuration.Value)
            {
                UpdatedEntryId = viewModel.Id,
                NewTitle = viewModel.Title,
                NewDescription = viewModel.Description
            }.Execute();

            return RedirectToAction(nameof(GetEntry), new {entryId = viewModel.Id});
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteFeedEntry(Guid entryId)
        {
            if (entryId.Equals(Guid.Empty)) return BadRequest();

            var user = await UserManager.GetUserAsync(HttpContext.User);
            var canDelete = new CheckIfCanModifyEntry(Configuration.Value)
            {
                EntryId = entryId,
                UserId = user.Id
            }.Execute();
            if (!canDelete.Output) return Unauthorized();

            var result = new DeleteFeedEntry(Configuration.Value) {EntryId = entryId}.Execute();

            return RedirectToAction(nameof(Index));
        }
    }
}