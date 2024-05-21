using MarketPlaceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceApi.Data;
public class MarketplaceContext : DbContext
{
    public MarketplaceContext(DbContextOptions<MarketplaceContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCost> ProductCosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ProductCost>()
            .HasKey(pc => pc.Id);

        modelBuilder.Entity<ProductCost>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCosts)
            .HasForeignKey(pc => pc.ProductId);
    }
}
