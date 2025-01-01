using Microsoft.AspNetCore.Mvc;
using ProductNest.Entity;
using ProductNest.Entity.Commaon.Model;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks; // Don't forget to add this using statement

namespace ManuTrackUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7067/Product");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(json);
                return View(products);
            }

            return StatusCode(501);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new ApiResponse<string>(false, "Product data is null.", null));
            }

            // Your logic for saving the product (add or update) goes here
            // Example: Call your service layer to handle adding/updating the product

            // Return a structured response
            return Ok(new ApiResponse<Product>(true, "Product saved successfully.", product));
        }
    }
}
