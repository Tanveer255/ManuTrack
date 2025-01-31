
namespace ProductNest.DAL.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(IUnitOfWork unitOfWork, ILogger<ProductRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
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
