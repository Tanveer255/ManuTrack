using ProductNest.Entity.Entity;
using ProductNest.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace ProductNest.Entity;

[Table("Product")]
public class Product : _BaseProduct
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal UnitCost { get; set; }
    public decimal SellingPrice { get; set; }
    public int StockLevel { get; set; }
    public int ReorderLevel { get; set; }
    public int LeadTimeInDays { get; set; }
    public List<BOMItem> BillOfMaterials { get; set; }
    public List<Variant> Variants { get; set; }
    public List<VariantOption> Options { get; set; }
    public List<ImageFile> ImageFiles { get; set; }
    //public Image Image { get; set; }
    public Product()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        BillOfMaterials = new List<BOMItem>();
        Variants = new List<Variant>();
        Options = new List<VariantOption>();
        ImageFiles = new List<ImageFile>();
        Status = ProductStatus.Active.ToString();
    }

}
