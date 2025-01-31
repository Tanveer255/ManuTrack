namespace ProductNest.BLL.Interface;

public interface IInventoryService : ICrudService<Inventory>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Inventory> GetById(Guid Id);
}
