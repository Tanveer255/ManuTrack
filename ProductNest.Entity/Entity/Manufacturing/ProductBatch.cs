using ProductNest.Enum.Manufacturing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity.Manufacturing
{
    [Table("ProductBatch")]
    public class ProductBatch : _Base
    {
        public string ProcessType { get; set; }
        public string Reason { get; set; }
        public string BOMVersion { get; set; }
        public string Quantity { get; set; }
        public string AdditionalQuantity { get; set; }
        public string ExpectedStartDate { get; set; }
        public string ActualStartDate { get; set; }
        public string ExpectedFinishDate { get; set; }
        public string ActualFinishDate { get; set; }
        public string WorkingDays { get; set; }
        public string Status { get; set; }
        public string FinishProductTo { get; set; }
        public string QtyAvailable { get; set; }
        public string QtyReserved { get; set; }
        public string QtyQuarantine { get; set; }
        public string QtyRejected { get; set; }
        public string QtyExpired { get; set; }
        public string StockTreatment { get; set; }
        public string StockImpact { get; set; }
        public string IsStarted { get; set; }
        public string StartStatus { get; set; }
        public string WarehouseBuildIn { get; set; }
        public Guid WarehouseBuildInSaveId { get; set; }
        public string IsWIP { get; set; }
        public string StockStatus { get; set; }
        public string WIPStatus { get; set; }
        public string TrackProgress { get; set; }
        public string QtyCompleted { get; set; }
        public string IsDone { get; set; }
        public string WarehouseFinished { get; set; }
        public Guid WarehouseFinishedSaveId { get; set; }
        public string WarehouseZone { get; set; }
        public string WarehouseAisle { get; set; }
        public string WarehouseLocation { get; set; }
        public string WarehouseShelf { get; set; }
        public string WarehouseRack { get; set; }
        public string WarehouseBay { get; set; }
        public string IsCancelled { get; set; }
        public string ReasonForcancellation { get; set; }
        public string IsReinstate { get; set; }
        public string CompleteQtyTreatment { get; set; }
        public string CancellationStatus { get; set; }
        public string ProgressStatus { get; set; }
        public string TenantId { get; set; }
        public ActionState ActionState { get; set; }
        public DateTime CreatedDateTimeStamp { get; set; }
        public DateTime? UpdatedDateTimeStamp { get; set; }
        public string ProjectJNo { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Products { get; set; }
        //public List<ImpactedComponent> ImpactedComponents { get; set; }
        //public List<CompletedPart> CompletedParts { get; set; }
    }
}
