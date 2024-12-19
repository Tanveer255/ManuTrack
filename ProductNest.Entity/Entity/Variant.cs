using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity;

[Table("Variant")]
public class Variant : _BaseProduct
{
    public long VariantId { get; set; }
    public long ParentProductId { get; set; }
    public Guid? ProductId { get; set; }
    public string Price { get; set; }
    public int Position { get; set; }
    public string InventoryPolicy { get; set; }
    public string CompareAtPrice { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public bool Taxable { get; set; }
    public string Barcode { get; set; }
    public string FulfillmentService { get; set; }
    public int Grams { get; set; }
    public string InventoryManagement { get; set; }
    public bool RequiresShipping { get; set; }
    public string Sku { get; set; }
    public double Weight { get; set; }
    public string WeightUnit { get; set; }
    public Guid? InventoryId { get; set; }
    public int InventoryQuantity { get; set; }
    public int OldInventoryQuantity { get; set; }
    public List<PresentmentPrice> PresentmentPrices { get; set; }
    public long? ImageId { get; set; }
}
