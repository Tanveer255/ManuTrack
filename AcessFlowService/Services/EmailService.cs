namespace AcessFlowService.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Infrastructure.Common;

public interface IEmailService
{
    Task<ApiResponse<bool>> SendEmailAsync(string toEmail, string subject, string message);
}
public class EmailService : IEmailService
{
    private readonly string _sendGridApiKey;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
    {
        _sendGridApiKey = configuration["SendGrid:ApiKey"] ?? throw new ArgumentNullException("SendGrid API Key is missing");
        _logger = logger;
    }

    public async Task<ApiResponse<bool>> SendEmailAsync(string toEmail, string subject, string message)
    {
        try
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("your-email@example.com", "Your Name");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);

            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Email sent successfully to {toEmail}");
                return ApiResponse<bool>.SuccessResponse(true,$"Email sent successfully to {toEmail}") ;
            }

            _logger.LogError($"Failed to send email to {toEmail}. Status Code: {response.StatusCode}");
            return ApiResponse<bool>.FailResponse($"Failed to send email to {toEmail}. Status Code: {response.StatusCode}");
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error sending email: {exception.Message}");
            return ApiResponse<bool>.FailResponse($"Error sending email: {exception.Message}");
        }
    }
}
