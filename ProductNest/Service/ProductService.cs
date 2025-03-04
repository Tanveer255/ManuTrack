namespace ProductNest.BLL.Service;
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
public class ProductService(
    IProductRepository productRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Product>(productRepository, unitOfWork), IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Product> GetById(Guid id)
    {
        var products = await _productRepository.GetById(id);
        return products;
    }
    public async Task<List<Product>> GetAllDataAsync()
    {
        var products = await _unitOfWork.Context.Product.OrderByDescending(p=>p.CreatedAt).ToListAsync();
        return products;
    }
}
