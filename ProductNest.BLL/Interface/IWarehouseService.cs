namespace ProductNest.BLL.Interface;
public interface IWarehouseService : ICrudService<Warehouse>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Warehouse> GetById(Guid Id);
    public Task<Warehouse> AddUpdate(Warehouse warehouse);
    public Task<List<Warehouse>> GetAllDataAsync();
}
