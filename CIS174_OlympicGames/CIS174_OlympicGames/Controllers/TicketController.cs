using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;
using CIS174_OlympicGames.Data;
using CIS174_OlympicGames.Services;

namespace CIS174_OlympicGames.Controllers
{
    public class TicketController : Controller
    {

        private readonly ITicketService _ticketService;


        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            var tickets = _ticketService.GetAllTickets();
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

            _ticketService.AddTicket(ticket);
            return RedirectToAction("Index");
        }
    }
}
