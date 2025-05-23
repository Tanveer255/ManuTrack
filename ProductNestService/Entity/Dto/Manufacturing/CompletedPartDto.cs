﻿

namespace ProductNestService.Dto.Manufacturing;

public class CompletedPartDto : CompletedPart
{
    public new DateTime DateCompleted { get; set; }
    public new string PartCompleted { get; set; }
    public new Guid BatchId { get; set; }
    public new Batch Batch { get; set; }
    public CompletedPart MapDtoToModel(CompletedPartDto dto)
    {
        return new CompletedPart()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            DateCompleted = dto.DateCompleted,
            PartCompleted = dto.PartCompleted,
            BatchId = dto.BatchId,
            Batch = dto.Batch,

        };
    }
    public CompletedPartDto MapModelToDto(CompletedPart entity)
    {
        return new CompletedPartDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DateCompleted = entity.DateCompleted,
            PartCompleted = entity.PartCompleted,
            Batch = entity.Batch,

        };
    }
}
