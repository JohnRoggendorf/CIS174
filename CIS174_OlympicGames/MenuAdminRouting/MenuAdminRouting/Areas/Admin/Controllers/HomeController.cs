using Microsoft.AspNetCore.Mvc;

namespace MenuAdminRouting.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin Area";
            return View();
        }
    }
}
