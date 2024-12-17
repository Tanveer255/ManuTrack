﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity;

/// <summary>
///  Sub-model for a Bill of Materials (BOM) item
/// </summary>
/// 
[Table("BOMItem")]

public class BOMItem : _Base
{
    public long BomItemId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public long InventoryId { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public long ProductId { get; set; }
    public string Version { get; set; }

}
