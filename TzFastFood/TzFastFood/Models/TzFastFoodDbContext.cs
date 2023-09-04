using Microsoft.EntityFrameworkCore;

namespace TzFastFood.Models
{
    public class TzFastFoodDbContext : DbContext
    {
        public TzFastFoodDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships here
                modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

                modelBuilder.Entity<Category>()
                .HasMany(cat => cat.Products)
                .WithOne(prod => prod.Category)
                .HasForeignKey(prod => prod.CategoryId);

                modelBuilder.Entity<Product>()
                .HasMany(prod => prod.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);

                modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}

