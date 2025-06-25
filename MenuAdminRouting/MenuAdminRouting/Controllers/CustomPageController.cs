using Microsoft.AspNetCore.Mvc;

namespace MenuAdminRouting.Controllers
{
    public class CustomPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display(int? id)
        {
            ViewBag.Title = $"Custom Route Page {id}";
            return View();
        }
    }
}
