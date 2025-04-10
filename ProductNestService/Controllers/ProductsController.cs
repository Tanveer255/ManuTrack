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
            var result = await _productService.CreateAsync(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
            
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
