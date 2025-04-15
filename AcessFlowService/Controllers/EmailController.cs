// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlowService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(
        IEmailService emailService
        ) : ControllerBase
    {
        private readonly IEmailService _emailService = emailService;
        // POST api/<EmailController>
        [Authorize,HttpPost(nameof(Post))]
        public async Task<ActionResult<SendGridRequest>> Post([FromBody] SendGridRequest value)
        {
            var result =  await _emailService.SendEmailAsync(value.ToEmail, value.Subject, value.Message);
            if (result.Success)
                return Ok(new { Message = "Email sent successfully" });
            return BadRequest(result.Message);
        } 
    }
}
