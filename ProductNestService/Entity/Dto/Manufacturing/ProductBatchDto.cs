namespace ProductNestService.Dto.Manufacturing;

public class ProductBatchDto : Batch
{
    public new string ProcessType { get; set; }
    public new string Reason { get; set; }
    public new string BOMVersion { get; set; }
    public new string Quantity { get; set; }
    public new string AdditionalQuantity { get; set; }
    public new string ExpectedStartDate { get; set; }
    public new string ActualStartDate { get; set; }
    public new string ExpectedFinishDate { get; set; }
    public new string ActualFinishDate { get; set; }
    public new string WorkingDays { get; set; }
    public new string Status { get; set; }
    public new string FinishProductTo { get; set; }
    public new string QtyAvailable { get; set; }
    public new string QtyReserved { get; set; }
    public new string QtyQuarantine { get; set; }
    public new string QtyRejected { get; set; }
    public new string QtyExpired { get; set; }
    public new string StockTreatment { get; set; }
    public new string StockImpact { get; set; }
    public new string IsStarted { get; set; }
    public new string StartStatus { get; set; }
    public new string WarehouseBuildIn { get; set; }
    public new Guid WarehouseBuildInSaveId { get; set; }
    public new string IsWIP { get; set; }
    public new string StockStatus { get; set; }
    public new string WIPStatus { get; set; }
    public new string TrackProgress { get; set; }
    public new string QtyCompleted { get; set; }
    public new string IsDone { get; set; }
    public new string WarehouseFinished { get; set; }
    public new Guid WarehouseFinishedSaveId { get; set; }
    public new string WarehouseZone { get; set; }
    public new string WarehouseAisle { get; set; }
    public new string WarehouseLocation { get; set; }
    public new string WarehouseShelf { get; set; }
    public new string WarehouseRack { get; set; }
    public new string WarehouseBay { get; set; }
    public new string IsCancelled { get; set; }
    public new string ReasonForcancellation { get; set; }
    public new string IsReinstate { get; set; }
    public new string CompleteQtyTreatment { get; set; }
    public new string CancellationStatus { get; set; }
    public new string ProgressStatus { get; set; }
    public new string TenantId { get; set; }
    public new ActionState ActionState { get; set; }
    public new DateTime CreatedDateTimeStamp { get; set; }
    public new DateTime? UpdatedDateTimeStamp { get; set; }
    public new string ProjectJNo { get; set; }
    public new Guid ProductId { get; set; }
    public new Product Products { get; set; }
    public Batch MapDtoToModel(ProductBatchDto dto)
    {
        return new Batch()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            ProcessType = dto.ProcessType,
            Status = dto.Status,
            ProductId = dto.ProductId,
        };
    }

    public ProductBatchDto MapModelToDto(Batch entity)
    {
        return new ProductBatchDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ProcessType = entity.ProcessType,
            ProductId = entity.ProductId,
        };
    }

}
