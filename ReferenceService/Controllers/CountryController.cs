using Microsoft.AspNetCore.Mvc;
using ReferenceService.Entity;
using ReferenceService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReferenceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(
            ICountryService countryService
            )
        {
            _countryService = countryService;
        }
        // GET: api/<CountryController>
        [HttpGet(nameof(GetAllCountries))]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            return await _countryService.GetAllDataAsync();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
