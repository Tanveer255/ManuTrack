namespace ProductNest.BLL.Interface;

public interface IPresentmentPriceService : ICrudService<PresentmentPrice>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<PresentmentPrice> GetById(Guid Id);
}
