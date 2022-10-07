using Microsoft.EntityFrameworkCore;

namespace PersonContacts.Data
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
                    PersonEmail = $"Email: {i}",
                    PersonName = $"Esse nome: {i}",
                    PersonPhone = "0000000000"
                };
            }
            modelBuilder.Entity<Contact>().HasData(contacts);
        }
    }
}