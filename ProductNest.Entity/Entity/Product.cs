using ProductNest.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity;

[Table("Product")]
public class Product : _Base
{

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
    public string Status { get; set; }
    public Product()
    {
        CreatedTime = DateTime.Now;
        UpdatedTime = DateTime.Now;
        BillOfMaterials = new List<BOMItem>();
        Status = ProductStatus.Active.ToString();
    }
}
