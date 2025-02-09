using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFilesController(IImageFileRepository imageFileRepository,IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IImageFileRepository _imageFileRepository = imageFileRepository;
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
        public void Post([FromBody] ImageFile value)
        {

            _imageFileRepository.Add(value);
            _unitofwork.Commit();
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
