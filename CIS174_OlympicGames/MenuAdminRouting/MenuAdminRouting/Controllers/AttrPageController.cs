using Microsoft.AspNetCore.Mvc;

namespace MenuAdminRouting.Controllers
{
    [Route("attr")]
    public class AttrPageController : Controller
    {
        [Route("page")]
        public IActionResult Index()
        {
            ViewBag.Title = "Attribute Route Page";
            return View();
        }
    }
}
