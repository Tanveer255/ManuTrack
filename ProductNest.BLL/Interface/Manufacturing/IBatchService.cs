
namespace ProductNest.BLL.Interface.Manufacturing;

public interface IBatchService : ICrudService<Batch>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Batch> GetById(Guid id);
    public Task<List<Batch>> GetAllDataAsync();
    public Task<Batch> AddUpdate(Batch batch);
}
