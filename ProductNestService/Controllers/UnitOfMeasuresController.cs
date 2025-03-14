﻿
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;    
        }
        // GET: api/<UnitOfMeasureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasure>>> GetUnitOfMeasure()
        {
            var unitOfMeasures = await _unitOfMeasureService.GetAllDataAsync();
            return Ok(unitOfMeasures);
        }

        // GET api/<UnitOfMeasureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnitOfMeasureController>
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasure>> Post([FromBody] UnitOfMeasure uom)
        {
            try
            {
                var result = await _unitOfMeasureService.AddUpdate(uom);
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

        // PUT api/<UnitOfMeasureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnitOfMeasureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
