
using AcessFlow.Entity.DTO;
using EBS.DAL.Interface;
using System.Security.Cryptography;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IJwtAuthenticationService jwtAuthenticationService,
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
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] User user)
        {
            var exist = _applicationUserService.ValidateUser(user.Email);
            if (exist)
                return Unauthorized("Invalid credentials");

            var token = _jwtAuthenticationService.GenerateJwtToken(user.UserName);
            return Ok(new { token, status = 200 });
        }

        // POST api/<UserController>
        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            // Check if the user already exists
            var exist = _applicationUserService.ValidateUser(user.Email);
            if (exist) return BadRequest("Username is taken.");

            using var hmac = new HMACSHA512();

            var newUser = new ApplicationUser()
            {
                FirstName = user.FirstName.ToLower(),
                PasswordHash = user.Password,
            };

            // Add user and save changes
           await _applicationUserService.Add(newUser);
           _unitOfWork.Commit(); // Assuming Commit is async

            // Generate JWT token
            var token = _jwtAuthenticationService.GenerateJwtToken(newUser.UserName);

            return Ok(new { token, status = 200 });
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> Get(Guid id)
        {
            var user = await _applicationUserService.GetSingle(x => x.Id.Equals(id));
            if (user != null)
            {
                return Ok(user); 
            }
            return Unauthorized("Invalid credentials");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationUser>> Put(Guid id, [FromBody] ApplicationUser user)
        {
            var userEntity = await _applicationUserService.GetSingle(x => x.Id.Equals(id));
            if (userEntity != null)
            {
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.UserName = user.UserName;
                userEntity.PhoneNumber = user.PhoneNumber;
                userEntity.ProfilePicture = user.ProfilePicture;
                userEntity.UsernameChangeLimit = user.UsernameChangeLimit;
                var result = await _applicationUserService.Update(userEntity);
                _unitOfWork.Commit();
                return Ok(result);
            }
            return Unauthorized("Invalid credentials");
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
