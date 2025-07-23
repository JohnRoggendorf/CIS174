using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Data;
using CIS174_OlympicGames.Models;

namespace CIS174_OlympicGames.Services
{
    public class TicketService : ITicketService
    {

        private readonly TicketDbContext _context;

        public TicketService(TicketDbContext context)
        {
            _context = context;
        }

        public List<TicketModel> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public void AddTicket(TicketModel ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }
       
    }
}
