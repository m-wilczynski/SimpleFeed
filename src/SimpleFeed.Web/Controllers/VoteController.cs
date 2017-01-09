namespace SimpleFeed.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Base;
    using Core.User;
    using Data.Commands.Interactions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models.VoteViewModels;
    using _Configuration;

    public class VoteController : BaseController
    {
        public VoteController(IOptions<PersistenceConfiguration> configuration, UserManager<ApplicationUser> userManager) 
            : base(configuration, userManager)
        {
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeVoteForFeedEntry(Guid votedEntryId, bool isUpvote)
        {
            if (votedEntryId.Equals(Guid.Empty)) return AjaxRequestFailure();

            var user = await UserManager.GetUserAsync(HttpContext.User);
            var result = new AddOrSwapVoteForFeedEntry(Configuration.Value)
            {
                IsPositive = isUpvote,
                VotedEntryId = votedEntryId,
                VoterId = user.Id
            }.Execute();

            if (!result.WasSuccessful) return AjaxRequestFailure();

            return new JsonResult(
                new MakeVoteResultViewModel
                {
                    NewVoteBalance = result.Output.VotesBalance,
                    Upvote = isUpvote,
                    VotedEntry = votedEntryId
                });
        }
    }
}
