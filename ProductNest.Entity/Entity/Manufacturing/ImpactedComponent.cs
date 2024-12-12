using ProductNest.Enum.Manufacturing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity.Manufacturing
{
    [Table("ImpactedComponent")]
    public class ImpactedComponent : _Base
    {

        public Guid BOMItemId { get; set; }
        public Guid WarehouseId { get; set; }
        public string SectionZone { get; set; }
        public string Aisle { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
        public string Position { get; set; }
        public double PickedAvlQty { get; set; }
        public double PickedResQty { get; set; }
        public double PickedQty { get; set; }
        public bool IsPicked { get; set; } = false;
        public ImpactType ImpactType { get; set; }
        public string Direction { get; set; } = string.Empty;

        [ForeignKey("ProductBatch")]
        public Guid BatchId { get; set; }
        public ProductBatch ProductBatch { get; set; }
    }
}
