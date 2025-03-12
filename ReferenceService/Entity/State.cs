using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReferenceService.Entity;

public class State
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } // State Name (e.g., "California", "Texas")
    public string Code { get; set; } // State Code (e.g., "CA", "TX")

    // Foreign Key
    public int CountryId { get; set; }
    public Country Country { get; set; } // Navigation Property
}

