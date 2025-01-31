
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UnitOfMeasureController(IUnitOfMeasureService unitOfMeasureService)
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
        public void Post([FromBody] string value)
        {
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
