using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductNest.Entity.Entity;
using ProductNest.Entity.Manufacturing;

namespace ProductNest.Entity.Data;

public class ProductNestDbContext : DbContext
{
    public ProductNestDbContext(DbContextOptions<ProductNestDbContext> options)
            : base(options)
    {

    }
    public DbSet<Product> Product { get; set; }
    public DbSet<Variant> Variants { get; set; }
    public DbSet<BOMItem> BOMItems { get; set; }
    public DbSet<CompletedPart> CompletedParts { get; set; }
    public DbSet<ImpactedComponent> ImpactedComponents { get; set; }
    public DbSet<ImageFile> ImageFiles { get; set; }
    public DbSet<ProductBatch> ProductBatchs { get; set; }
    public DbSet<VariantOption> VariantOption { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<PresentmentPrice> PresentmentPrices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Variant>().ToTable("Variant");
        modelBuilder.Entity<BOMItem>().ToTable("BOMItem");
        modelBuilder.Entity<CompletedPart>().ToTable("CompletedPart");
        modelBuilder.Entity<ImpactedComponent>().ToTable("ImpactedComponent");
        modelBuilder.Entity<ImageFile>().ToTable("ImageFile");
        modelBuilder.Entity<ProductBatch>().ToTable("ProductBatch");
        modelBuilder.Entity<VariantOption>().ToTable("VariantOption");
        modelBuilder.Entity<Price>().ToTable("Price");
        modelBuilder.Entity<PresentmentPrice>().ToTable("PresentmentPrice");
    }

}
