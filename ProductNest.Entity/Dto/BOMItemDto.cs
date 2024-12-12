using ProductNest.Entity;

namespace ProductNest.Dto;

public class BOMItemDto : BOMItem
{
    public new string MaterialName { get; set; } = string.Empty;
    public new decimal Quantity { get; set; }
    public new string UnitOfMeasure { get; set; } = string.Empty;
    public BOMItem MapDtoToModel(BOMItemDto dto)
    {
        return new BOMItem()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedTime = dto.CreatedTime,
            UpdatedTime = dto.UpdatedTime,
            MaterialName = dto.MaterialName,
            Quantity = dto.Quantity,
            UnitOfMeasure = dto.UnitOfMeasure,

        };
    }
    public BOMItemDto MapModelToDto(BOMItem entity)
    {
        return new BOMItemDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedTime = entity.CreatedTime,
            UpdatedTime = entity.UpdatedTime,
            MaterialName = entity.MaterialName,
            Quantity = entity.Quantity,
            UnitOfMeasure = entity.UnitOfMeasure,

        };
    }
}
