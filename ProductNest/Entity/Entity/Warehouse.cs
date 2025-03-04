namespace ProductNest.Entity.Entity;
[Table(nameof(Warehouse))]
public class Warehouse : _Base
{
    public long WarehouseId { get; set; }
    public string Zone { get; set; }
    public string Aisle { get; set; }
    public string Location { get; set; }
    public string Shelf { get; set; }
    public string Rack { get; set; }
    public string Bay { get; set; }

    [ForeignKey("Variant")]
    public Guid VariantId { get; set; }
    public Variant Variant { get; set; }
    public List<Inventory> Inventory { get; set; }
    public Warehouse()
    {
        Inventory = new List<Inventory>();
        WarehouseId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
