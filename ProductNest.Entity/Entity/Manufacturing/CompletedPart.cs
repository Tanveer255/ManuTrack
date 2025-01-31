

namespace ProductNest.Entity.Manufacturing;

[Table("CompletedPart")]
public class CompletedPart : _Base
{
    public long CompletePartId { get; set; }
    public DateTime DateCompleted { get; set; }
    public string PartCompleted { get; set; } = string.Empty;

    [ForeignKey("Batch")]
    public Guid BatchId { get; set; }
    public Batch Batch { get; set; }
    public CompletedPart()
    {
        CompletePartId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
