namespace ProductNest.Entity.Entity;

[Table(nameof(ImageFile))]
public class ImageFile:_Base
{
    public long ImageFileId { get; set; }
    public string Alt { get; set; }
    public int Position { get; set; }
    public Guid? ProductId { get; set; }
    public string AdminGraphqlApiId { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Src { get; set; }
    public List<long> VariantIds { get; set; }
    public ImageFile()
    {
        VariantIds = new List<long>();
        ImageFileId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
