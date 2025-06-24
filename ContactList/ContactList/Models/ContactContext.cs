using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                ContactId = 1,
                Name = "Aye Person",
                Number = "1234567890",
                Address = "123 Concrete Street, Cityville, IA",
                Note = "Work"
            },
            new Contact
            {
                ContactId = 2,
                Name = "Psalm Body",
                Number = "3216549870",
                Address = "321 Asphalt Street, Town City, IA",
                Note = "School"
            },
            new Contact
            {
                ContactId = 3,
                Name = "Connie Tact",
                Number = "7894561230",
                Address = "111 Gravel Road, Somme City,IA",
                Note = "Xbox Friend"
            }
            );
        }
    }
}
