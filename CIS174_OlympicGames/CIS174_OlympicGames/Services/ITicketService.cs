using Microsoft.AspNetCore.Mvc;
using CIS174_OlympicGames.Models;
using System.Collections.Generic;

namespace CIS174_OlympicGames.Services
{
    public interface ITicketService
    {
        List<TicketModel> GetAllTickets();
        void AddTicket(TicketModel ticket);
    }
}
