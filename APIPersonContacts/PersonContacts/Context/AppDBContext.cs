using Microsoft.EntityFrameworkCore;
using PersonContacts.Model;

namespace PersonContacts.Context
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Contact[] contacts = new Contact[5];

            for (int i = 1; i <= 5; i++)
            {
                contacts[i - 1] = new Contact
                {
                    ContactId = i,
                    PersonEmail = $"DavidSmith{i}@gmail.com",
                    PersonName = $"David Smith 0{i}",
                    PersonPhone = $"{i}234567890"
                };
            }
            modelBuilder.Entity<Contact>().HasData(contacts);
        }
    }
}