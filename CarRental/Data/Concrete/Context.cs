using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRental.Data.Concrete
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
