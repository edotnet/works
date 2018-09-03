using System.Data.Entity;
using CoffeeApp.Data.Models;

namespace CoffeeApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }

        public AppDbContext() : base("DBConnection")
        {

        }
    }
}
