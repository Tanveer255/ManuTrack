namespace ProductNest.DAL.Interface.Manufacturing;
public interface IImpactedComponentRepository : IRepository<ImpactedComponent>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImpactedComponent> GetById(Guid id);
}