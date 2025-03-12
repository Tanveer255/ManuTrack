namespace ProductNestService.Dto.Manufacturing;

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
    public new Batch Batch { get; set; }
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
            IsPicked = dto.IsPicked,
            ImpactType = dto.ImpactType,
            Direction = dto.Direction,
            BatchId = dto.BatchId,
            Batch = dto.Batch,

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
            IsPicked = entity.IsPicked,
            ImpactType = entity.ImpactType,
            Direction = entity.Direction,
            BatchId = entity.BatchId,
            Batch = entity.Batch,

        };
    }
}
