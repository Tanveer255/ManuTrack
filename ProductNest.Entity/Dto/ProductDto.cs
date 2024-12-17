using ProductNest.Entity;
using System.Collections.Generic;

namespace ProductNest.Dto;

public class ProductDto : Product
{
    public new string Name { get; set; }
    public new string Description { get; set; }
    public new string SKU { get; set; }
    public new string UnitOfMeasure { get; set; }
    public new decimal UnitCost { get; set; }
    public new decimal SellingPrice { get; set; }
    public new int StockLevel { get; set; }
    public new int ReorderLevel { get; set; }
    public new int LeadTimeInDays { get; set; }
    public new string Status { get; set; }
    public new List<BOMItem> BillOfMaterials { get; set; }
    public Product MapDtoToModel(ProductDto dto)
    {
        return new Product()
        {
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.CreatedAt,
            Name = dto.Name,
            Description = dto.Description,
            SKU = dto.SKU,
            UnitOfMeasure = dto.UnitOfMeasure,
            UnitCost = dto.UnitCost,
            StockLevel = dto.StockLevel,
            ReorderLevel = dto.ReorderLevel,
            LeadTimeInDays = dto.LeadTimeInDays,
            Status = dto.Status,
        };
    }
    public ProductDto MapModelToDto(Product entity)
    {
        return new ProductDto()
        {
            Id = entity.Id,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Name = entity.Name,
            Description = entity.Description,
            SKU = entity.SKU,
            UnitOfMeasure = entity.UnitOfMeasure,
            UnitCost = entity.UnitCost,
            StockLevel = entity.StockLevel,
            ReorderLevel = entity.ReorderLevel,
            LeadTimeInDays = entity.LeadTimeInDays,
            Status = entity.Status,
        };
    }
}
