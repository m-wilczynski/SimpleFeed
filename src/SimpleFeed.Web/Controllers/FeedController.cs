namespace SimpleFeed.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Base;
    using Core.FeedEntries;
    using Core.User;
    using Data.Commands.FeedEntries;
    using Data.Queries;
    using Data.Storage;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models.FeedViewModels;
    using _Configuration;

    public class FeedController : BaseController
    {
        public FeedController(IOptions<PersistenceConfiguration> configuration, UserManager<ApplicationUser> userManager) 
            : base(configuration, userManager)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEntry(Guid entryId)
        {
            if (entryId.Equals(Guid.Empty)) return BadRequest();

            var entry = new GetEntryById(Configuration.Value.DefaultConnection)
            {
                EntryId = entryId
            }.Execute();

            return View(entry);
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
            var command = new AddExternalLinkEntry(Configuration.Value.DefaultConnection)
            {
                ExternalLink = new ExternalLinkFeedEntry(new Uri(viewModel.LinkAddress), user.Id)
            };
            var result = command.Execute();

            return !result.WasSuccessful ? 
                RedirectToAction(nameof(AddExternalLinkForm)) : 
                RedirectToAction(nameof(GetEntry), new {entryId = command.ExternalLink.Id});
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
                File = viewModel.Image
            }.ExecuteAsync();

            var command = new AddUploadedImageEntry(Configuration.Value.DefaultConnection)
            {
                UploadedImageEntry = new UploadedImageFeedEntry(new Uri(uploadedFilePath), user.Id)
            };
            var result = command.Execute();

            return !result.WasSuccessful ?
                RedirectToAction(nameof(AddUploadedImageForm)) :
                RedirectToAction(nameof(GetEntry), new { entryId = command.UploadedImageEntry.Id });
        }


    }
}