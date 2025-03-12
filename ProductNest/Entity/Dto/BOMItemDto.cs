namespace ProductNestService.Dto;

public class BOMItemDto : BOMItem
{
    public new string MaterialName { get; set; } = string.Empty;
    public new Guid? InventoryId { get; set; }
    public new string UnitOfMeasure { get; set; } = string.Empty;
    public BOMItem MapDtoToModel(BOMItemDto dto)
    {
        return new BOMItem()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            MaterialName = dto.MaterialName,
            InventoryId = dto.InventoryId,
            UnitOfMeasure = dto.UnitOfMeasure,

        };
    }
    public BOMItemDto MapModelToDto(BOMItem entity)
    {
        return new BOMItemDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            MaterialName = entity.MaterialName,
            InventoryId = entity.InventoryId,
            UnitOfMeasure = entity.UnitOfMeasure,

        };
    }
}
