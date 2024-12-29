using Microsoft.AspNetCore.Mvc;
using ProductNest.Entity;
using System.Net.Http;
using System.Text.Json;

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
    }
}
