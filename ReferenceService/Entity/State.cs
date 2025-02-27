namespace ReferenceService.Entity;

public class State :BaseEntity
{
    public string Name { get; set; } // State Name (e.g., "California", "Texas")
    public string Code { get; set; } // State Code (e.g., "CA", "TX")

    // Foreign Key
    public int CountryId { get; set; }
    public Country Country { get; set; } // Navigation Property
}

