using Microsoft.EntityFrameworkCore;
using Shops.Entities;

namespace Shops
{
    public class ShopAppDbContext : DbContext
    {
        public ShopAppDbContext(DbContextOptions<ShopAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Shops)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Workers)
                .WithOne(w => w.Shop)
                .HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Position)
                .WithMany(p => p.Workers)
                .HasForeignKey(w => w.PositionId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
