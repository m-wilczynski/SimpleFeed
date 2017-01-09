namespace SimpleFeed.Controllers.Base
{
    using Core.User;
    using Data.Configuration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using Models;
    using _Configuration;

    public abstract class BaseController : Controller
    {
        protected readonly IOptions<PersistenceConfiguration> Configuration;
        protected readonly UserManager<ApplicationUser> UserManager;

        protected BaseController(IOptions<PersistenceConfiguration> configuration, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            UserManager = userManager;
        }

        protected JsonResult AjaxRequestFailure(string message = null)
        {
            return new JsonResult(new AjaxRequestResult { Success = false, Message = message });
        }
    }
}
