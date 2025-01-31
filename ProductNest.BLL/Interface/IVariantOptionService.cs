

namespace ProductNest.BLL.Interface;
public interface IVariantOptionService : ICrudService<VariantOption>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<VariantOption> GetById(Guid Id);
    public Task<List<VariantOption>> GetAllDataAsync();
}
