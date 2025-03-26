

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
            IProductService productService,
            IVariantOptionService variantOptionService,
            IVariantService variantService,
            IBOMItemService bOMItemService,
            IPriceService priceService,
            IImageFileService imageFileService,
            IWarehouseService warehouseServicec,
            IUnitOfWork unitOfWork
        ) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IVariantOptionService _variantOptionService = variantOptionService;
        private readonly IVariantService _variantService = variantService;
        private readonly IBOMItemService _bOMItemService = bOMItemService;
        private readonly IPriceService _priceService = priceService;
        private readonly IImageFileService _imageFileService = imageFileService;
        private readonly IWarehouseService _warehouseService = warehouseServicec;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        //GET: api/<ProductController>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _productService.GetAllDataAsync();

            if (products == null || !products.Any())
            {
                return NotFound("No products available.");
            }
            return Ok(products);
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new ApiResponse<string>(false, "Product data is null.", null));
            }

            // Check if the product exists
            var existingProduct = await _productService.GetById(product.Id);

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
                            variant.VariantId = GenerateId();
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
                await _productService.Update(existingProduct);
                _unitOfWork.Commit();
                return Ok(new ApiResponse<Product>(true, "Product updated successfully.", existingProduct));
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
                await _productService.Add(product);
                _unitOfWork.Commit();
                return CreatedAtAction(nameof(GetProductById),
                    new { id = product.ProductId },
                    new ApiResponse<Product>(true, "Product created successfully.", product));
            }
        }


        // GET: api/products/{id} (helper method to return a specific product)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound(new ApiResponse<string>(false, "Product not found.", null));
            }

            return Ok(new ApiResponse<Product>(true, "Product retrieved successfully.", product));
        }
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found" });
                }

                //_productService.Delete(id); // Pass the Guid to the Delete method
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
        // Helper function to generate ProductId
        private long GenerateId()
        {
            var now = DateTime.UtcNow;
            return long.Parse($"{now:yyyyMMddHHmmss}");
        }
    }
}
