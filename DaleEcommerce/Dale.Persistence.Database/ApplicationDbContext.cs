using Dale.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dale.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CustomersEntity> CustomersEntity { get; set; }
        public DbSet<OrderDetailsEntity> OrderDetail { get; set; }
        public DbSet<ProductsEntity> ProductsEntity { get; set; }
        public DbSet<OrdersEntity> OrdersEntity { get; set; }
    }
}