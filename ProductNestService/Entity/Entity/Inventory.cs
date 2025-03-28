﻿namespace ProductNestService.Entity.Entity;

[Table(nameof(Inventory))]
public class Inventory : _Base
{
    public long InventoryId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string Status { get; set; }
    public string StorageLocation { get; set; }
    [Precision(18, 4)]
    public decimal Quantity { get; set; }
    [Precision(18, 4)]
    public decimal AvailableQuantity { get; set; }
    [Precision(18, 4)]
    public decimal ReservedQuantity { get; set; }
    [Precision(18, 4)]
    public decimal QuarantinedQuantity { get; set; }
    [Precision(18, 4)]
    public decimal RejectedQuantity { get; set; }
    [Precision(18, 4)]
    public decimal ExpiredQuantity { get; set; }

    [ForeignKey("Warehouse")]
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    [ForeignKey("Price")]
    public Guid PriceId { get; set; }
    public Price Price { get; set; }
    public Inventory()
    {
        Status = StockStatus.Available.ToString();
        InventoryId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
