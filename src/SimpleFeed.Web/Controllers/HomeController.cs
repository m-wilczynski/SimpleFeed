using Microsoft.AspNetCore.Mvc;

namespace SimpleFeed.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Feed");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
