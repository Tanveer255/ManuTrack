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
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<VariantOption> VariantOption { get; set; }
    public DbSet<Warehouse> Warehouse { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        modelBuilder.Entity<ImpactedComponent>()
        .HasOne(ic => ic.Warehouse)
        .WithMany()
        .HasForeignKey(ic => ic.WarehouseId)
        .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete
        //UnitOfMeasure added in database
        modelBuilder.Entity<UnitOfMeasure>().HasData(
        new UnitOfMeasure { Name = "Assembled Item", Code = "AI" },
        new UnitOfMeasure { Name = "Liter", Code = "L" },
        new UnitOfMeasure { Name = "Centiliter", Code = "cl" },
        new UnitOfMeasure { Name = "Milliliter", Code = "ml" },
        new UnitOfMeasure { Name = "Deciliter", Code = "dl" },
        new UnitOfMeasure { Name = "Decaliter", Code = "dcl" },
        new UnitOfMeasure { Name = "Hectoliter", Code = "hcl" },
        new UnitOfMeasure { Name = "Kiloliter", Code = "kl" },
        new UnitOfMeasure { Name = "Pint", Code = "pt" },
        new UnitOfMeasure { Name = "Gallon (Metric)", Code = "gll" },
        new UnitOfMeasure { Name = "Gallon (Imperial)", Code = "glim" },
        new UnitOfMeasure { Name = "Microgram", Code = "mcg" },
        new UnitOfMeasure { Name = "Milligram", Code = "mg" },
        new UnitOfMeasure { Name = "Gram", Code = "g" },
        new UnitOfMeasure { Name = "Kilogram", Code = "kg" },
        new UnitOfMeasure { Name = "Pound", Code = "lb" },
        new UnitOfMeasure { Name = "Metric-Ton", Code = "mt" },
        new UnitOfMeasure { Name = "Millimeter", Code = "mm" },
        new UnitOfMeasure { Name = "Centimeter", Code = "cm" },
        new UnitOfMeasure { Name = "Decimeter", Code = "dm" },
        new UnitOfMeasure { Name = "Meter", Code = "m" },
        new UnitOfMeasure { Name = "Decameter", Code = "dcm" },
        new UnitOfMeasure { Name = "Hectometer", Code = "hcm" },
        new UnitOfMeasure { Name = "Kilometer", Code = "km" },
        new UnitOfMeasure { Name = "Inch", Code = "in" },
        new UnitOfMeasure { Name = "Foot", Code = "ft" },
        new UnitOfMeasure { Name = "Yard", Code = "yard" },
        new UnitOfMeasure { Name = "Single Item", Code = "SI" },
        new UnitOfMeasure { Name = "Single Unit", Code = "SU" },
        new UnitOfMeasure { Name = "Ton", Code = "t" },
        new UnitOfMeasure { Name = "Square Meter", Code = "m2" },
        new UnitOfMeasure { Name = "Hectare", Code = "ha" },
        new UnitOfMeasure { Name = "Square Kilometer", Code = "km2" },
        new UnitOfMeasure { Name = "Cubic Centimeter", Code = "cm3" },
        new UnitOfMeasure { Name = "Cubic Meter", Code = "m3" },
        new UnitOfMeasure { Name = "Kilogram Per Cubic Meter", Code = "kg/m3" },
        new UnitOfMeasure { Name = "Each", Code = "each" },
        new UnitOfMeasure { Name = "Piece", Code = "piece" },
        new UnitOfMeasure { Name = "Pair", Code = "pair" },
        new UnitOfMeasure { Name = "Ounce", Code = "oz" },
        new UnitOfMeasure { Name = "Fluid Ounce", Code = "floz" },
        new UnitOfMeasure { Name = "Acre", Code = "ac" },
        new UnitOfMeasure { Name = "Lot", Code = "lot" },
        new UnitOfMeasure { Name = "Square Inch", Code = "sin" },
        new UnitOfMeasure { Name = "Other", Code = "Other" }
    );

    }
    public async Task CreateStoredProcedureAsync()
    {
        var sql = @"
            CREATE PROCEDURE GetAllUnitOfMeasure
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT TOP (1000) [Code], [Name]
                FROM [ProductNestDev].[dbo].[UnitOfMeasures];
            END;
        ";

        await this.Database.ExecuteSqlRawAsync(sql);
    }
}
