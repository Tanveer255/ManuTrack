
using EBS.DAL.Interface;
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
        public IActionResult Login([FromBody] ApplicationUser user)
        {
            if (!ValidateUser(user))
                return Unauthorized("Invalid credentials");

            var token = _jwtAuthenticationService.GenerateJwtToken(user.UserName);
            return Ok(new { token, status = 200 });
        }
        [HttpPost(nameof(ValidateUser))]
        public bool ValidateUser(ApplicationUser user)
        {
            var userEntity = _applicationUserService.GetSingle(x => x.Email == user.Email);
            if (userEntity == null)
            {
                return false;
            }
            
            return true;
        }
        // POST api/<UserController>
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
