using ProductNest.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity;

[Table("Inventory")]
public class Inventory : _Base
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string Status { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalValue => Quantity * UnitPrice;
    public string StorageLocation { get; set; }
    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int QuarantinedQuantity { get; set; }
    public int RejectedQuantity { get; set; }
    public int ExpiredQuantity { get; set; }

    [ForeignKey("Warehouse")]
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public Inventory()
    {
        Status = StockStatus.Available.ToString();
    }
}
