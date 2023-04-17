using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Database
{
    public class DatabaseContext: DbContext

    {
        public DatabaseContext(DbContextOptions options) :base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get;set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
