namespace SimpleFeed.Controllers
{
    using Base;
    using Core.User;
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

        public IActionResult Index()
        {
            
        }
    }
}
