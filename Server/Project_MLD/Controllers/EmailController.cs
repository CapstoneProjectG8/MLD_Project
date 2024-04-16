using Microsoft.AspNetCore.Mvc;
using Project_MLD.Utils.GenerateCode;
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
        private readonly IGenerateCode _generateCode;

        public EmailController(IEmailSender emailSender,IMailBody mailBody, IGenerateCode generateCode)
        {
            _emailSender = emailSender;
            _mailBody = mailBody;
            _generateCode = generateCode;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string receiver)
        {
            try
            {
                var code = _generateCode.GenerateRandomCode();
                await _emailSender.SendEmailAsync(receiver, _mailBody.SubjectTitleResetPassword(code),
                    _mailBody.EmailBodyResetPassword("testUser",code));
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
