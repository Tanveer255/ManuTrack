

namespace ProductNest.Entity.Manufacturing;

[Table("ImpactedComponent")]
public class ImpactedComponent : _Base
{
    public long ImpactedComponentId { get; set; }
    public Guid BOMItemId { get; set; }
    public bool IsPicked { get; set; } = false;
    public ImpactType ImpactType { get; set; }
    public string Direction { get; set; } = string.Empty;

    [ForeignKey("Batch")]
    public Guid BatchId { get; set; }
    public Batch Batch { get; set; }

    [ForeignKey("Warehouse")]
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    [ForeignKey("Inventory")]
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    public ImpactedComponent()
    {
        ImpactedComponentId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
