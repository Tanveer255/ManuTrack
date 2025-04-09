namespace ProductNestService.BLL.Service;
public interface IProductService : ICrudService<Product>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<Product> GetById(Guid productId);
    public Task<List<Product>> GetAllDataAsync();
    public Task<ApiResponse<Product>> CreateAsync(Product product);
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
    public async Task<ApiResponse<Product>> CreateAsync(Product product)
    {

        try
        {
            if (product == null)
            {
                return ApiResponse<Product>.FailResponse("Product data is null.");
            }

            // Check if the product exists
            var existingProduct =await GetById(product.Id);

            if (existingProduct != null)
            {
                // Update existing product
                existingProduct.IsDeleted = product.IsDeleted;
                existingProduct.UpdatedAt = product.UpdatedAt;
                existingProduct.Title = product.Title;
                existingProduct.BodyHtml = product.BodyHtml;
                existingProduct.Vendor = product.Vendor;
                existingProduct.ProductType = product.ProductType;
                existingProduct.Tags = product.Tags;
                existingProduct.Status = product.Status;
                existingProduct.AdminGraphqlApiId = product.AdminGraphqlApiId;
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.SKU = product.SKU;
                existingProduct.UnitOfMeasure = product.UnitOfMeasure;
                existingProduct.UnitCost = product.UnitCost;
                existingProduct.StockLevel = product.StockLevel;
                existingProduct.ReorderLevel = product.ReorderLevel;
                existingProduct.LeadTimeInDays = product.LeadTimeInDays;

                if (product.Variants != null && product.Variants.Count > 0)
                {
                    foreach (var variant in product.Variants)
                    {
                        var existingVariant = existingProduct.Variants.FirstOrDefault(v => v.VariantId == variant.VariantId);
                        if (existingVariant != null)
                        {
                            // Update variant
                            existingVariant.Status = variant.Status;
                        }
                        else
                        {
                            // Add new variant
                            variant.ParentProductId = existingProduct.ProductId;
                            variant.VariantId =  GenerateId();
                            variant.Status = ProductStatus.Active.ToString();
                            existingProduct.Variants.Add(variant);
                        }
                    }
                }


                if (product.ImageFiles != null && product.ImageFiles.Count > 0)
                {
                    foreach (var imageFile in product.ImageFiles)
                    {
                        var existingImage = existingProduct.ImageFiles.FirstOrDefault(i => i.Id == imageFile.Id);
                        if (existingImage != null)
                        {
                            // Update ImageFile
                            existingImage.UpdatedAt = imageFile.UpdatedAt;
                        }
                        else
                        {
                            // Add new ImageFile
                            //imageFile.ProductId = existingProduct.ProductId;
                            existingProduct.ImageFiles.Add(imageFile);
                        }
                    }
                }

                // Update the product using service layer
                await _productRepository.Update(existingProduct);
                _unitOfWork.Commit();
                return ApiResponse<Product>.SuccessResponse(existingProduct, "Product updated successfully.");
            }
            else
            {
                // Create new product
                product.ProductId = long.Parse($"{DateTime.UtcNow:yyyyMMddHHmmss}");
                product.Status = ProductStatus.Active.ToString();

                if (product.Variants != null && product.Variants.Count > 0)
                {
                    foreach (var variant in product.Variants)
                    {
                        variant.ParentProductId = product.ProductId;
                        variant.VariantId = GenerateId();
                        variant.Status = ProductStatus.Active.ToString();
                    }
                }
                if (product.ImageFiles != null && product.ImageFiles.Count > 0)
                {
                    foreach (var imageFile in product.ImageFiles)
                    {
                        //imageFile.ProductId = product.ProductId;
                    }
                }

                // Add the product using service layer
                await _productRepository.Add(product);
                _unitOfWork.Commit();
                return ApiResponse<Product>.SuccessResponse(product, "Product created successfully.");
            }
        }
        catch (Exception exception)
        {
            return ApiResponse<Product>.FailResponse($"Error creating product: {exception.Message}");
        }
    }
    private long GenerateId()
    {
        var now = DateTime.UtcNow;
        return long.Parse($"{now:yyyyMMddHHmmss}");
    }
}
