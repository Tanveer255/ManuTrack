

namespace ProductNest.BLL.Interface;

public interface IVariantService : ICrudService<Variant>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Variant> GetById(Guid Id);
    public Task<List<Variant>> GetAllDataAsync();
}
