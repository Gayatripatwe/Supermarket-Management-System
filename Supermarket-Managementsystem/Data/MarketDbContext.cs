using Microsoft.EntityFrameworkCore;
using Supermarket_Managementsystem.Models;

namespace Supermarket_multiplemodels.Data
{
    public class marketDbContext : DbContext
    {
        public marketDbContext(DbContextOptions<marketDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Orderitem> orderitems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your model configuration here
            base.OnModelCreating(modelBuilder);
        }


    }


}
