using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;
using CIS174_OlympicGames.Data;

namespace CIS174_OlympicGames.Controllers
{
    public class TicketController : Controller
    {

        private readonly TicketDbContext _context;


        public TicketController(TicketDbContext context)
        {
            _context = context;
        }

        private static List<TicketModel> tickets = new List<TicketModel>();

        public IActionResult Index()
        {
            var tickets = _context.Tickets.ToList();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketModel ticket)
        {
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
