namespace ProductNestService.Entity;

[Table(nameof(Product))]
public class Product : _BaseProduct
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal UnitCost { get; set; }
    public int StockLevel { get; set; }
    public int ReorderLevel { get; set; }
    public int LeadTimeInDays { get; set; }
    //public List<BOMItem> BillOfMaterials { get; set; }
    public List<Variant> Variants { get; set; }
    public List<VariantOption> Options { get; set; }
    public List<ImageFile> ImageFiles { get; set; }
    public Product()
    {
        ProductId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        //BillOfMaterials = new List<BOMItem>();
        Variants = new List<Variant>();
        Options = new List<VariantOption>();
        ImageFiles = new List<ImageFile>();
        Status = ProductStatus.Active.ToString();
    }

}
