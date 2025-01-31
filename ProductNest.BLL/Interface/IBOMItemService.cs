namespace ProductNest.BLL.Interface;

public interface IBOMItemService : ICrudService<BOMItem>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<BOMItem> GetById(Guid Id);
    public Task<List<BOMItem>> GetAllDataAsync();
}
