using InventoryManagementAPI.src.Domain;
using InventoryManagementAPI.src.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.src.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); 

            base.OnModelCreating(modelBuilder);
        }
    }

}