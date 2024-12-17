using ProductNest.Entity;

namespace ProductNest.BLL.Interface;

public interface IProductService : ICrudService<Product>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<Product> GetById(Guid productId);
    public Task<List<Product>> GetAllDataAsync();
}
