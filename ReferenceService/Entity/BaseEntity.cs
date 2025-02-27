using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReferenceService.Entity;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } // To mark active/inactive status
    public bool IsDeleted { get; set; } // To mark active/inactive status
    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsActive = false;
        IsDeleted = false;
    }
}
