using ProductNest.Entity;
using ProductNest.BLL.Interface;
using ProductNest.DAL.Interface;
using Microsoft.AspNetCore.Http;
using ProductNest.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace ProductNest.BLL.Service;

public class ProductService : CrudService<Product>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public ProductService(IProductRepository productRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(productRepository, unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<Product> GetById(Guid productId)
    {
        var products = await _productRepository.GetById(productId);
        return products;
    }
    public async Task<List<Product>> GetAllDataAsync()
    {
        var products = await _unitOfWork.Context.Product.ToListAsync();
        return products;
    }
}
