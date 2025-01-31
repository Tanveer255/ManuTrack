namespace ProductNest.DAL.Interface;

public interface IPresentmentPriceRepository : IRepository<PresentmentPrice>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<PresentmentPrice> GetById(Guid id);
}
