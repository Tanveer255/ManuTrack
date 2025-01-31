namespace ProductNest.DAL.Interface;
public interface IVariantOptionRepository : IRepository<VariantOption>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<VariantOption> GetById(Guid id);
}
