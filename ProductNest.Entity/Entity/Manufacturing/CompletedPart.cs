using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductNest.Entity.Manufacturing
{
    [Table("CompletedPart")]
    public class CompletedPart : _Base
    {
        public DateTime DateCompleted { get; set; }
        public string PartCompleted { get; set; } = string.Empty;

        [ForeignKey("ProductBatch")]
        public Guid BatchId { get; set; }
        public ProductBatch ProductBatch { get; set; }
    }
}
