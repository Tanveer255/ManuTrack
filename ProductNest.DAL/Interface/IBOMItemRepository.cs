namespace ProductNest.DAL.Interface;

public interface IBOMItemRepository : IRepository<BOMItem>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BOMItem> GetById(Guid id);
}
