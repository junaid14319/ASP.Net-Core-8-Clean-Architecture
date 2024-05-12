using AspNetCoreCA.Domain.ModelEntity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCA.Infrastructure.Persistence.Contexts
{
    public class ECommDbContext : DbContext
    {
        public ECommDbContext(DbContextOptions<ECommDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
