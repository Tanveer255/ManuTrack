using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFilesController(
        IImageFileRepository imageFileRepository,
        IUnitOfWork unitOfWork,
        IImageFileService imageFileService
        ) : ControllerBase
    {
        private readonly IImageFileRepository _imageFileRepository = imageFileRepository;
        private readonly IImageFileService _imageFileService = imageFileService;
        private readonly IUnitOfWork _unitofwork = unitOfWork;
        // GET: api/<ImageFilesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ImageFilesController>/5
        [HttpGet("{id}")]
        public Task<ImageFile> Get(Guid id)
        {
            var result = _imageFileRepository.GetById(id);
            return result;
        }

        // POST api/<ImageFilesController>
        [HttpPost]
        public async Task<ActionResult<ImageFile>> Post([FromBody] ImageFile file)
        {
            try
            {
                var result = await _imageFileService.AddUpdate(file);
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


        // PUT api/<ImageFilesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImageFilesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
