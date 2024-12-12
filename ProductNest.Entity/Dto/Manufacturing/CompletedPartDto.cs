using ProductNest.Entity.Manufacturing;
using System;

namespace ProductNest.Dto.Manufacturing;

public class CompletedPartDto : CompletedPart
{
    public new DateTime DateCompleted { get; set; }
    public new string PartCompleted { get; set; }
    public new Guid BatchId { get; set; }
    public new ProductBatch ProductBatch { get; set; }
    public CompletedPart MapDtoToModel(CompletedPartDto dto)
    {
        return new CompletedPart()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedTime = dto.CreatedTime,
            UpdatedTime = dto.UpdatedTime,
            DateCompleted = dto.DateCompleted,
            PartCompleted = dto.PartCompleted,
            BatchId = dto.BatchId,
            ProductBatch = dto.ProductBatch,

        };
    }
    public CompletedPartDto MapModelToDto(CompletedPart entity)
    {
        return new CompletedPartDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedTime = entity.CreatedTime,
            UpdatedTime = entity.UpdatedTime,
            DateCompleted = entity.DateCompleted,
            PartCompleted = entity.PartCompleted,
            ProductBatch = entity.ProductBatch,

        };
    }
}
