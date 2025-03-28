﻿// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlowService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(IEmailService emailService) : ControllerBase
    {
        private readonly IEmailService _emailService = emailService;
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public async Task<ActionResult<SendGridRequest>> Post([FromBody] SendGridRequest value)
        {
            var result =  await _emailService.SendEmailAsync(value.ToEmail, value.Subject, value.Message);
            if (result)
                return Ok(new { Message = "Email sent successfully" });

            return BadRequest(new { Message = "Failed to send email" });
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
