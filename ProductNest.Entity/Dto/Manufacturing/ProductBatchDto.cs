using ProductNest.Entity.Manufacturing;
using ProductNest.Entity;
using ProductNest.Enum.Manufacturing;
using System;

namespace ProductNest.Dto.Manufacturing;

public class ProductBatchDto : ProductBatch
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
    public ProductBatch MapDtoToModel(ProductBatchDto dto)
    {
        return new ProductBatch()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedTime = dto.CreatedTime,
            UpdatedTime = dto.UpdatedTime,
            Quantity = dto.Quantity,
            ProcessType = dto.ProcessType,
            Reason = dto.Reason,
            BOMVersion = dto.BOMVersion,
            AdditionalQuantity = dto.AdditionalQuantity,
            ExpectedStartDate = dto.ExpectedStartDate,
            ActualStartDate = dto.ActualStartDate,
            ExpectedFinishDate = dto.ExpectedFinishDate,
            ActualFinishDate = dto.ActualFinishDate,
            WorkingDays = dto.WorkingDays,
            Status = dto.Status,
            FinishProductTo = dto.FinishProductTo,
            QtyAvailable = dto.QtyAvailable,
            QtyReserved = dto.QtyReserved,
            QtyQuarantine = dto.QtyQuarantine,
            QtyRejected = dto.QtyRejected,
            QtyExpired = dto.QtyExpired,
            StockTreatment = dto.StockTreatment,
            StockImpact = dto.StockImpact,
            IsStarted = dto.IsStarted,
            StartStatus = dto.StartStatus,
            WarehouseBuildIn = dto.WarehouseBuildIn,
            WarehouseBuildInSaveId = dto.WarehouseBuildInSaveId,
            IsWIP = dto.IsWIP,
            StockStatus = dto.StockStatus,
            WIPStatus = dto.WIPStatus,
            TrackProgress = dto.TrackProgress,
            QtyCompleted = dto.QtyCompleted,
            IsDone = dto.IsDone,
            WarehouseFinished = dto.WarehouseFinished,
            WarehouseFinishedSaveId = dto.WarehouseFinishedSaveId,
            WarehouseZone = dto.WarehouseZone,
            WarehouseAisle = dto.WarehouseAisle,
            WarehouseLocation = dto.WarehouseLocation,
            WarehouseShelf = dto.WarehouseShelf,
            WarehouseRack = dto.WarehouseRack,
            WarehouseBay = dto.WarehouseBay,
            IsCancelled = dto.IsCancelled,
            ReasonForcancellation = dto.ReasonForcancellation,
            IsReinstate = dto.IsReinstate,
            CompleteQtyTreatment = dto.CompleteQtyTreatment,
            CancellationStatus = dto.CancellationStatus,
            ProgressStatus = dto.ProgressStatus,
            TenantId = dto.TenantId,
            ActionState = dto.ActionState,
            CreatedDateTimeStamp = dto.CreatedDateTimeStamp,
            UpdatedDateTimeStamp = dto.UpdatedDateTimeStamp,
            ProjectJNo = dto.ProjectJNo,
            ProductId = dto.ProductId,
            Products = dto.Products
        };
    }

    public ProductBatchDto MapModelToDto(ProductBatch entity)
    {
        return new ProductBatchDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedTime = entity.CreatedTime,
            UpdatedTime = entity.UpdatedTime,
            Quantity = entity.Quantity,
            ProcessType = entity.ProcessType,
            Reason = entity.Reason,
            BOMVersion = entity.BOMVersion,
            AdditionalQuantity = entity.AdditionalQuantity,
            ExpectedStartDate = entity.ExpectedStartDate,
            ActualStartDate = entity.ActualStartDate,
            ExpectedFinishDate = entity.ExpectedFinishDate,
            ActualFinishDate = entity.ActualFinishDate,
            WorkingDays = entity.WorkingDays,
            Status = entity.Status,
            FinishProductTo = entity.FinishProductTo,
            QtyAvailable = entity.QtyAvailable,
            QtyReserved = entity.QtyReserved,
            QtyQuarantine = entity.QtyQuarantine,
            QtyRejected = entity.QtyRejected,
            QtyExpired = entity.QtyExpired,
            StockTreatment = entity.StockTreatment,
            StockImpact = entity.StockImpact,
            IsStarted = entity.IsStarted,
            StartStatus = entity.StartStatus,
            WarehouseBuildIn = entity.WarehouseBuildIn,
            WarehouseBuildInSaveId = entity.WarehouseBuildInSaveId,
            IsWIP = entity.IsWIP,
            StockStatus = entity.StockStatus,
            WIPStatus = entity.WIPStatus,
            TrackProgress = entity.TrackProgress,
            QtyCompleted = entity.QtyCompleted,
            IsDone = entity.IsDone,
            WarehouseFinished = entity.WarehouseFinished,
            WarehouseFinishedSaveId = entity.WarehouseFinishedSaveId,
            WarehouseZone = entity.WarehouseZone,
            WarehouseAisle = entity.WarehouseAisle,
            WarehouseLocation = entity.WarehouseLocation,
            WarehouseShelf = entity.WarehouseShelf,
            WarehouseRack = entity.WarehouseRack,
            WarehouseBay = entity.WarehouseBay,
            IsCancelled = entity.IsCancelled,
            ReasonForcancellation = entity.ReasonForcancellation,
            IsReinstate = entity.IsReinstate,
            CompleteQtyTreatment = entity.CompleteQtyTreatment,
            CancellationStatus = entity.CancellationStatus,
            ProgressStatus = entity.ProgressStatus,
            TenantId = entity.TenantId,
            ActionState = entity.ActionState,
            CreatedDateTimeStamp = entity.CreatedDateTimeStamp,
            UpdatedDateTimeStamp = entity.UpdatedDateTimeStamp,
            ProjectJNo = entity.ProjectJNo,
            ProductId = entity.ProductId,
            Products = entity.Products
        };
    }

}
