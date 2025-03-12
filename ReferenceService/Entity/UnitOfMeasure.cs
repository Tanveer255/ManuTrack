using System.ComponentModel.DataAnnotations.Schema;

namespace ReferenceService.Entity;
[Table(nameof(UnitOfMeasure))]
public class UnitOfMeasure:BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
}
