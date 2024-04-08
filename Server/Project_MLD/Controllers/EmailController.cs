using Microsoft.AspNetCore.Mvc;
using Project_MLD.Utils.GmailSender;
using IEmailSender = Project_MLD.Utils.GmailSender.IEmailSender;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IMailBody _mailBody;

        public EmailController(IEmailSender emailSender,IMailBody mailBody)
        {
            _emailSender = emailSender;
            _mailBody = mailBody;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string receiver)
        {
            try
            {
                await _emailSender.SendEmailAsync(receiver, _mailBody.SubjectTitle, _mailBody.EmailBody);
                return Ok("Done");
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"Error sending email: {ex.Message}");
                // Return a more informative error message to the client
                return BadRequest("Failed to send email. Please check the details and try again.");
            }
        }
    }
}
