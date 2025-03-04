namespace ProductNest.Repository;
public interface IProductRepository : IRepository<Product>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<Product> GetById(Guid productId);
}


public class ProductRepository(
    IUnitOfWork unitOfWork,
    ILogger<ProductRepository> logger
    ) : Repository<Product>(unitOfWork, logger), IProductRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<ProductRepository> _logger = logger;
    public async Task<Product> GetById(Guid id)
    {
        Product product = new Product();
        try
        {
            _logger.LogError("Getting products by Id");
            product = (from pro in _unitOfWork.Context.Product
                       where
                       pro.Id.Equals(id)
                       //&& pro.Status == Enum.ProductStatus.Active.ToString()
                       //&& pro.IsDeleted.Equals(false)

                       select new Product
                       {
                           Id = pro.Id,
                           ProductId = pro.ProductId,
                           Name = pro.Name,
                           Description = pro.Description,
                           SKU = pro.SKU,
                           UnitOfMeasure = pro.UnitOfMeasure,
                           UnitCost = pro.UnitCost ,
                           StockLevel = pro.StockLevel,
                           ReorderLevel = pro.ReorderLevel,
                           LeadTimeInDays = pro.LeadTimeInDays,
                           //BillOfMaterials = pro.BillOfMaterials,
                           Options = pro.Options,
                           Variants = pro.Variants,
                           ImageFiles = pro.ImageFiles,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning products :" + product);
        return await Task.FromResult(product);
    }
}
