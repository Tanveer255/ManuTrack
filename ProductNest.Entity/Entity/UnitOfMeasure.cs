namespace ProductNest.Entity.Entity;

public class UnitOfMeasure
{
    [Key]
    public string Code { get; set; } // Example: "L", "ml"

    [Required]
    public string Name { get; set; } // Example: "Liter", "Milliliter"

    // Factory method for creation
    public static UnitOfMeasure CreateFrom(string name, string code)
    {
        return new UnitOfMeasure { Name = name, Code = code };
    }
}

