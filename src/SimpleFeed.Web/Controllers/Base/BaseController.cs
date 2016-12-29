namespace SimpleFeed.Controllers.Base
{
    using Core.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public abstract class BaseController : Controller
    {
        protected readonly IConfiguration Configuration;
        protected readonly UserManager<ApplicationUser> UserManager;

        protected BaseController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            UserManager = userManager;
        }
    }
}
