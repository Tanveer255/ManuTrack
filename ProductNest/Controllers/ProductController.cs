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

        public ProductController(IProductService productService,
            IVariantOptionService variantOptionService,
            IVariantService variantService,
            IBOMItemService bOMItemService,
            IPriceService priceService,
            IImageFileService imageFileService)
        {
            _productService = productService;
            _variantOptionService = variantOptionService;
            _variantService = variantService;
            _bOMItemService = bOMItemService;
            _priceService = priceService;
            _imageFileService = imageFileService;
        }
        //GET: api/<ProductController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _productService.GetAllDataAsync();
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
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            product.Status = ProductStatus.Active.ToString();
            await _productService.Add(product);
            // Add Product Variants if any
            var VariantsAdd = new List<Variant>();
            if (product.Variants != null && product.Variants.Count > 0)
            {
                foreach (var variant in product.Variants)
                {
                    variant.ParentProductId = product.ProductId;
                    variant.VariantId = GenerateId();
                    variant.CreatedAt = DateTime.UtcNow;
                    variant.UpdatedAt = DateTime.UtcNow;
                    variant.Status = ProductStatus.Active.ToString();
                    VariantsAdd.Add(variant);
                }
            }
            if (VariantsAdd.Any())
            _variantService.Add(VariantsAdd);

            // Add BOM items if any
            var billOfMaterialsAdd = new List<BOMItem>();
            if (product.BillOfMaterials != null && product.BillOfMaterials.Count > 0)
            {
                foreach (var material in product.BillOfMaterials)
                {
                    material.BomItemId = GenerateId();
                    material.CreatedAt = DateTime.UtcNow;
                    material.UpdatedAt = DateTime.UtcNow;
                    billOfMaterialsAdd.Add(material);
                }
            }
            if (!billOfMaterialsAdd.Any())
            _bOMItemService.Add(billOfMaterialsAdd);
            // Add ImageFiles if any
            var imageFilesAdd = new List<ImageFile>();
            if (product.ImageFiles != null && product.ImageFiles.Count > 0)
            {
                foreach (var imageFile in product.ImageFiles)
                {
                    imageFile.ProductId = product.ProductId;
                    imageFile.CreatedAt = DateTime.UtcNow;
                    imageFile.UpdatedAt = DateTime.UtcNow;
                    imageFilesAdd.Add(imageFile);
                }
            }
            if(imageFilesAdd.Any())
                _imageFileService.Add(imageFilesAdd);
            // Add the product using service layer
           

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

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // Helper function to generate ProductId
        private long GenerateId()
        {
            var now = DateTime.UtcNow;
            return long.Parse($"{now:yyyyMMddHHmmss}");
        }
    }
}
