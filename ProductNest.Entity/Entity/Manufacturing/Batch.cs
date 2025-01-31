

namespace ProductNest.Entity.Manufacturing;

[Table("Batch")]
public class Batch : _Base
{
    public long BatchId { get; set; }
    public string ProcessType { get; set; }
    public string CancellationReason { get; set; }
    public int ManufacturedQuantity { get; set; }
    public DateTime ExpectedStartDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime ExpectedFinishDate { get; set; }
    public DateTime ActualFinishDate { get; set; }
    public int TotalWorkingDays { get; set; }
    public string Status { get; set; }
    public string StockHandlingProcedure { get; set; }
    public string ProgressTracking { get; set; }
    public int CompletedQuantity { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsReinstated { get; set; }
    public ActionState CurrentActionState { get; set; }
    public string ProjectJobNumber { get; set; }

    [ForeignKey("Product")]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [ForeignKey("Inventory")]
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    [ForeignKey("Warehouse")]
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    [ForeignKey("BOMItem")]
    public Guid BOMItemId { get; set; }
    public BOMItem BOMItem { get; set; }

    public Batch()
    {
        Status = BatchStatus.NotStarted.ToString();
        BatchId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}

