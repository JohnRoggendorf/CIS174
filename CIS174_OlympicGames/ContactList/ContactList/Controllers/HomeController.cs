using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx) =>
            context = ctx;


        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            var contacts = context.Contacts.OrderBy(
                m => m.Name).ToList();
            return View(contacts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
