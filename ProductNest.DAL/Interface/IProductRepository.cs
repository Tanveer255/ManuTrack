using ProductNest.DAL.Interface;
using ProductNest.Entity;

namespace ProductNest.DAL.Repository;

public interface IProductRepository : IRepository<Product>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<Product> GetById(Guid productId);
}
