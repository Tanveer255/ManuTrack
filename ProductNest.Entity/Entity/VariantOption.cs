namespace ProductNest.Entity.Entity;

[Table("Option")]
public class VariantOption:_Base
{
    public long VariantOptionId { get; set; }
    public Guid? ProductId { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public List<string> Values { get; set; }
    public VariantOption()
    {
        VariantOptionId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
