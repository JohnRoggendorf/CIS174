using Microsoft.AspNetCore.Mvc;

namespace MenuAdminRouting.Controllers
{
    public class DefaultPageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Default Route Page";
            return View();
        }
    }
}
