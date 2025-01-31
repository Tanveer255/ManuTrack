namespace ProductNest.BLL.Interface;
public interface IPriceService : ICrudService<Price>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Price> GetById(Guid Id);
}
