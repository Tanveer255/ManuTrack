
using EBS.DAL.Interface;
using static AcessFlow.Controllers.AuthController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IJwtAuthenticationService jwtAuthenticationService,
            IApplicationUserService applicationUserService,
            IUnitOfWork unitOfWork
            )
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _applicationUserService = applicationUserService;
            _unitOfWork = unitOfWork;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] ApplicationUser user)
        {
            if (!ValidateUser(user))
                return Unauthorized("Invalid credentials");

            var token = _jwtAuthenticationService.GenerateJwtToken(user.FirstName);
            return Ok(new { token, status = 200 });
        }
        [HttpPost("validate")]
        public bool ValidateUser(ApplicationUser user)
        {
            var userEntity = _applicationUserService.GetSingle(x => x.Email == user.Email);
            if (userEntity == null)
            {
                return false;
            }
            
            return true;
        }
        [HttpPost(nameof(Signup))]
        public IActionResult Signup([FromBody] ApplicationUser user)
        {
            if (!ValidateUser(user))
                return Unauthorized("email  is already used  credentials");
            //user.Id = Guid.NewGuid();
            var result = _applicationUserService.Add(user);
            _unitOfWork.Commit();
            return Ok(new { result, status = 200 });
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var user =await _applicationUserService.GetSingle(x => x.Id.Equals(id));
            if (user == null)
            {
                 return Ok(false); ;
            }
           await _applicationUserService.Delete(user);
            _unitOfWork.Commit();
            return Ok(true);
        }
    }
}
