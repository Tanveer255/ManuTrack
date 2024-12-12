using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity;

/// <summary>
///  Sub-model for a Bill of Materials (BOM) item
/// </summary>
/// 
[Table("BOMItem")]

public class BOMItem : _Base
{
    public string MaterialName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
}
