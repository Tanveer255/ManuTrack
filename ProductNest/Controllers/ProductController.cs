using JwtAuthentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductNest.BLL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Commaon.Model;
using ProductNest.Entity.Data;
using ProductNest.Entity.Entity;
using ProductNest.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IVariantOptionService _variantOptionService;
        private readonly IVariantService _variantService;
        private readonly IBOMItemService _bOMItemService;
        private readonly IPriceService _priceService;
        private readonly IImageFileService _imageFileService;
        private readonly IWarehouseService _warehouseService;

        public ProductController(IProductService productService,
            IVariantOptionService variantOptionService,
            IVariantService variantService,
            IBOMItemService bOMItemService,
            IPriceService priceService,
            IImageFileService imageFileService,
            IWarehouseService warehouseService)
        {
            _productService = productService;
            _variantOptionService = variantOptionService;
            _variantService = variantService;
            _bOMItemService = bOMItemService;
            _priceService = priceService;
            _imageFileService = imageFileService;
            _warehouseService = warehouseService;
        }
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

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new ApiResponse<string>(false, "Product data is null.", null));
            }

            // Set default values for tracking
            product.ProductId = GenerateId();
            product.Status = ProductStatus.Active.ToString();

            if (product.Variants != null && product.Variants.Count > 0)
            {
                foreach (var variant in product.Variants)
                {
                    variant.ParentProductId = product.ProductId;
                    variant.ProductId = product.Id;
                    variant.VariantId = GenerateId();
                    variant.Status = ProductStatus.Active.ToString();
                }
            }

            // Add BOM items if any
            var billOfMaterialsAdd = new List<BOMItem>();
            if (product.BillOfMaterials != null && product.BillOfMaterials.Count > 0)
            {
                foreach (var material in product.BillOfMaterials)
                {
                    material.ProductId = product.ProductId;
                }
            }
            // Add ImageFiles if any
            if (product.ImageFiles != null && product.ImageFiles.Count > 0)
            {
                foreach (var imageFile in product.ImageFiles)
                {
                    imageFile.ProductId = product.Id;
                }
            }
            // Add the product using service layer
            await _productService.Add(product);

            // Return a structured response
            return CreatedAtAction(nameof(GetProductById),
                new { id = product.Id },
                new ApiResponse<Product>(true, "Product created successfully.", product));
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
