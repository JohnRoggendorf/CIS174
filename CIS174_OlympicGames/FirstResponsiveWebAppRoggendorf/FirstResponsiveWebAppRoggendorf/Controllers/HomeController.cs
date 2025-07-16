using FirstResponsiveWebAppRoggendorf.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppRoggendorf.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.userAge = null;
            ViewBag.userName = null;
            return View();
        }
        public IActionResult Index(NameAgeModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.userAge = model.DisplayNameAndCurrentAge();
                ViewBag.userName = model.userName;
            }
            else
            {
                ViewBag.userAge = null;
                ViewBag.userName = null;
            }
            return View(model);
        }
    }
}
