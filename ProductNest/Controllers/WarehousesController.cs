using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController(
        IWarehouseService warehouseService
        ) : ControllerBase
    {
        private readonly IWarehouseService _warehouseService = warehouseService;
        // GET: api/<WarehousesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WarehousesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WarehousesController>
        [HttpPost]
        public async Task<ActionResult<Warehouse>> Post([FromBody] Warehouse warehouse)
        {
            try
            {
                var result = await _warehouseService.AddUpdate(warehouse);
                if (result != null)
                    return Ok(result);

                return BadRequest("Failed to add or update the image file.");
            }
            catch (Exception exception)
            {

                // Log the exception (consider using a logging framework like Serilog)
                return StatusCode(500, $"Internal server error: {exception.Message}");
            }
        }

        // PUT api/<WarehousesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WarehousesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
