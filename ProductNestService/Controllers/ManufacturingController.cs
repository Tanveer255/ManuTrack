using Microsoft.AspNetCore.Mvc;
using ProductNestService.Entity.Manufacturing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturingController(IBatchRepository batchRepository,IBatchService batchService) : ControllerBase
    {
        private readonly IBatchRepository _batchRepository = batchRepository;
        private readonly IBatchService _batchService = batchService;
        // GET: api/<BatchesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BatchesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatchesController>
        [HttpPost]
        public async Task<ActionResult<Batch>> Post([FromBody] Batch batch)
        {
            try
            {
                var result = await _batchService.AddUpdate(batch);
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

        // PUT api/<BatchesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
