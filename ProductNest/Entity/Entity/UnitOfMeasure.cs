namespace ProductNest.Entity.Entity;
[Table(nameof(UnitOfMeasure))]
public class UnitOfMeasure
{
    [Key]
    public string Code { get; set; } // Example: "L", "ml"

    [Required]
    public string Name { get; set; } // Example: "Liter", "Milliliter"
}

