namespace SimpleFeed.Controllers
{
    using System;
    using Base;
    using Core.User;
    using Data.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using _Configuration;

    public class UserController : BaseController
    {
        public UserController(IOptions<PersistenceConfiguration> configuration, UserManager<ApplicationUser> userManager)
            : base(configuration, userManager)
        {

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetUser(Guid userId)
        {
            var user = new GetUserWithActivity(Configuration.Value)
            {
                UserId = userId
            }.Execute();

            return View(user.Output);
        }
    }
}
