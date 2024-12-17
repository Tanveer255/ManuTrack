using JwtAuthentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductNest.BLL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Commaon.Model;
using ProductNest.Entity.Data;
using ProductNest.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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

            // Add Product Variants if any
            if (product.Variants != null && product.Variants.Count > 0)
            {
                foreach (var variant in product.Variants)
                {
                    variant.ParentProductId = product.ProductId;
                    variant.VariantId = GenerateId();
                    variant.CreatedAt = DateTime.UtcNow;
                    variant.UpdatedAt = DateTime.UtcNow;
                    variant.Status = ProductStatus.Active.ToString();
                }
            }

            // Add BOM items if any
            if (product.BillOfMaterials != null && product.BillOfMaterials.Count > 0)
            {
                foreach (var material in product.BillOfMaterials)
                {
                    material.BomItemId = GenerateId();
                    material.CreatedAt = DateTime.UtcNow;
                    material.UpdatedAt = DateTime.UtcNow;
                }
            }

            // Add ImageFiles if any
            if (product.ImageFiles != null && product.ImageFiles.Count > 0)
            {
                foreach (var imageFile in product.ImageFiles)
                {
                    imageFile.ProductId = product.ProductId;
                    imageFile.CreatedAt = DateTime.UtcNow;
                    imageFile.UpdatedAt = DateTime.UtcNow;
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
