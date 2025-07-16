using Microsoft.EntityFrameworkCore;
using CIS174_OlympicGames.Models;


namespace CIS174_OlympicGames.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options)
            : base(options) { }

        public DbSet<TicketModel> Tickets { get; set; }
    }
}
