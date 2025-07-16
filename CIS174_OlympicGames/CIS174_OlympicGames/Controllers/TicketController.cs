using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;

namespace CIS174_OlympicGames.Controllers
{
    public class TicketController : Controller
    {
        private static List<TicketModel> tickets = new List<TicketModel>();

        public IActionResult Index()
        {
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
            ticket.Id = tickets.Count + 1;
            tickets.Add(ticket);
            return RedirectToAction("Index");
        }
    }
}
