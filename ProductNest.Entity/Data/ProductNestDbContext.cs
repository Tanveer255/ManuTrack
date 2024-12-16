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
    public DbSet<Inventory> Inventorys { get; set; }
    public DbSet<ImpactedComponent> ImpactedComponents { get; set; }
    public DbSet<ImageFile> ImageFiles { get; set; }
    public DbSet<Batch> Batchs { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<PresentmentPrice> PresentmentPrices { get; set; }
    public DbSet<VariantOption> VariantOption { get; set; }
    public DbSet<Warehouse> Warehouse { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Variant>().ToTable("Variant");
        modelBuilder.Entity<BOMItem>().ToTable("BOMItem");
        modelBuilder.Entity<CompletedPart>().ToTable("CompletedPart");
        modelBuilder.Entity<Inventory>().ToTable("Inventory");
        modelBuilder.Entity<ImpactedComponent>().ToTable("ImpactedComponent");
        modelBuilder.Entity<ImageFile>().ToTable("ImageFile");
        modelBuilder.Entity<Batch>().ToTable("Batch");
        modelBuilder.Entity<Price>().ToTable("Price");
        modelBuilder.Entity<PresentmentPrice>().ToTable("PresentmentPrice");
        modelBuilder.Entity<VariantOption>().ToTable("VariantOption");
        modelBuilder.Entity<Warehouse>().ToTable("Warehouse");

        modelBuilder.Entity<Batch>()
        .HasOne(b => b.Warehouse)
        .WithMany()
        .HasForeignKey(b => b.WarehouseId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Batch>()
            .HasOne(b => b.Product)
            .WithMany()
            .HasForeignKey(b => b.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Batch>()
            .HasOne(b => b.Inventory)
            .WithMany()
            .HasForeignKey(b => b.InventoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Batch>()
            .HasOne(b => b.BOMItem)
            .WithMany()
            .HasForeignKey(b => b.BOMItemId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ImpactedComponent>()
        .HasOne(ic => ic.Warehouse)
        .WithMany()  // Assuming Warehouse can have many impacted components
        .HasForeignKey(ic => ic.WarehouseId)
        .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
    }

}
