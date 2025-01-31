

namespace ProductNest.DAL.Interface;
public interface IWarehouseRepository : IRepository<Warehouse>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Warehouse> GetByIdAsync(Guid id);
}