namespace ProductNestService.Entity;

/// <summary>
///  Sub-model for a Bill of Materials (BOM) item
/// </summary>
/// 
[Table(nameof(BOMItem))]

public class BOMItem : _Base
{
    public long BomItemId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public Guid? InventoryId { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public long ProductId { get; set; }
    public string Version { get; set; }
    public BOMItem()
    {
        BomItemId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }

}
