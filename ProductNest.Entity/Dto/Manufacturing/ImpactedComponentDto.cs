using ProductNest.Entity.Manufacturing;
using ProductNest.Enum.Manufacturing;
using System;

namespace ProductNest.Dto.Manufacturing;

public class ImpactedComponentDto : ImpactedComponent
{
    public new Guid BOMItemId { get; set; }
    public new Guid WarehouseId { get; set; }
    public new string SectionZone { get; set; }
    public new string Aisle { get; set; }
    public new string Rack { get; set; }
    public new string Shelf { get; set; }
    public new string Position { get; set; }
    public new double PickedAvlQty { get; set; }
    public new double PickedResQty { get; set; }
    public new double PickedQty { get; set; }
    public new bool IsPicked { get; set; } = false;
    public new ImpactType ImpactType { get; set; }
    public new string Direction { get; set; } = string.Empty;
    public new Guid BatchId { get; set; }
    public new ProductBatch ProductBatch { get; set; }
    public ImpactedComponent MapDtoToModel(ImpactedComponentDto dto)
    {
        return new ImpactedComponent()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            BOMItemId = dto.BOMItemId,
            WarehouseId = dto.WarehouseId,
            SectionZone = dto.SectionZone,
            Aisle = dto.Aisle,
            Rack = dto.Rack,
            Shelf = dto.Shelf,
            Position = dto.Position,
            PickedAvlQty = dto.PickedAvlQty,
            PickedResQty = dto.PickedResQty,
            PickedQty = dto.PickedQty,
            IsPicked = dto.IsPicked,
            ImpactType = dto.ImpactType,
            Direction = dto.Direction,
            BatchId = dto.BatchId,
            ProductBatch = dto.ProductBatch,

        };
    }
    public ImpactedComponentDto MapModelToDto(ImpactedComponent entity)
    {
        return new ImpactedComponentDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.UpdatedAt,
            UpdatedAt = entity.UpdatedAt,
            BOMItemId = entity.BOMItemId,
            WarehouseId = entity.WarehouseId,
            SectionZone = entity.SectionZone,
            Aisle = entity.Aisle,
            Rack = entity.Rack,
            Shelf = entity.Shelf,
            Position = entity.Position,
            PickedAvlQty = entity.PickedAvlQty,
            PickedResQty = entity.PickedResQty,
            PickedQty = entity.PickedQty,
            IsPicked = entity.IsPicked,
            ImpactType = entity.ImpactType,
            Direction = entity.Direction,
            BatchId = entity.BatchId,
            ProductBatch = entity.ProductBatch,

        };
    }
}
