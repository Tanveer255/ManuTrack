namespace ProductNest.DAL.Interface;

public interface IPriceRepository : IRepository<Price>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Price> GetById(Guid id);
}