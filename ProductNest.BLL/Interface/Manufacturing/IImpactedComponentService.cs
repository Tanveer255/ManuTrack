


namespace ProductNest.BLL.Interface.Manufacturing;

public interface IImpactedComponentService : ICrudService<ImpactedComponent>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImpactedComponent> GetById(Guid id);
    public Task<List<ImpactedComponent>> GetAllDataAsync();
}
