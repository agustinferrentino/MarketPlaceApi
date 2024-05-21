using Microsoft.EntityFrameworkCore;

namespace MarketPlaceApi.Entities
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCost> ProductCosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCost)
                .WithOne(pc => pc.Product)
                .HasForeignKey<ProductCost>(pc => pc.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}