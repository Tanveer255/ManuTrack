﻿
using AcessFlowService.BLL.Services;
using AcessFlowService.Entity.DTO;
using JwtAuthentication.Model.Common;
using JwtAuthentication.Request;
using JwtAuthentication.Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlowService.Controllers
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
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _applicationUserService.GetUserByEmail(loginDTO.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.PassWord, user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
            var generateTokenRequest = new GenerateTokenRequest
            {
                Email = user.Email,
                UserId = user.Id
            };

            var token = _jwtAuthenticationService.GenerateJwtToken(generateTokenRequest);
            return Ok(new { token, status = 200 });
        }

        // POST api/<UserController>
        [HttpPost(nameof(Signup))]
        public async Task<ActionResult> Signup([FromBody] UserDTO userRequest)
        {
            // Check if the user already exists
            var exist = _applicationUserService.ExistUser(userRequest.Email);
            if (exist) return BadRequest("Username is taken.");

            userRequest.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);

            var newUser = new ApplicationUser()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                NormalizedUserName = $"{userRequest.FirstName} {userRequest.LastName}",
                Email = userRequest.Email,
                EmailConfirmed = true,
                PhoneNumber = userRequest.PhoneNumber,
                PhoneNumberConfirmed = true,
                PasswordHash = userRequest.Password,
                TenantId = UniqueIdGenerator.GenerateId()
            };

            // Add user and save changes
           await _applicationUserService.Add(newUser);
           _unitOfWork.Commit(); // Assuming Commit is async

            // Generate JWT token
            var generateTokenRequest = new GenerateTokenRequest
            {
                Email = newUser.Email,
                UserId = newUser.Id
            };
            var token = _jwtAuthenticationService.GenerateJwtToken(generateTokenRequest);

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
