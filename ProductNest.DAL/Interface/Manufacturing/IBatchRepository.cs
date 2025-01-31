namespace ProductNest.DAL.Interface.Manufacturing;

public interface IBatchRepository : IRepository<Batch>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Batch> GetById(Guid id);
}
