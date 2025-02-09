namespace ProductNest.Entity.Entity;

[Table(nameof(PresentmentPrice))]
public class PresentmentPrice: _Base
{
    public long PredentPriceId { get; set; }
    public Price Price { get; set; }
    public string CompareAtPrice { get; set; }
    public PresentmentPrice()
    {
        PredentPriceId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
    }
}
