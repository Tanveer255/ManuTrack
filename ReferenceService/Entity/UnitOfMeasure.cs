using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReferenceService.Entity;
[Table(nameof(UnitOfMeasure))]
public class UnitOfMeasure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}
