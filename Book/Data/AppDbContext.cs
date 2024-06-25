using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "server=(localdb)\\MSSQLLocalDB;" +
                          "database=BookDb;" +
                          "Trusted_Connection = true;";

            optionsBuilder.UseSqlServer(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Books books = new Books()
            {
                Id = 1,
                Title = "So'ngi safar",
                Author = "Abdullmannon Abdullox",
                PublishedYear = 2023,
                Photo = @"X:\books\Book\wwwroot\images\songiSahifa.jpg"
            };

            modelBuilder.Entity<Books>().HasData(books);
        }

    }
}
