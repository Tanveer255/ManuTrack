namespace ProductNestService.Entity.Commaon.Interface;

public interface IHasSoftDelete
{
    public bool IsDeleted { get; set; }
}
