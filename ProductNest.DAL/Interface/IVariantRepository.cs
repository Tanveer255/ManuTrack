

namespace ProductNest.DAL.Interface;
public interface IVariantRepository : IRepository<Variant>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Variant> GetById(Guid id);
}
