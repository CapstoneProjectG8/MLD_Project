using System.Net;
using System.Net.Mail;

namespace Project_MLD.Utils.GmailSender
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string senderEmail = "leenguyenquangdung1@gmail.com"; // Your sender email address
            string senderPassword = "niiz gbhq cytf earn"; // Your sender email password

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

            var mailMessage = new MailMessage(senderEmail, email)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true // Set to true if your message is in HTML format
            };

            await client.SendMailAsync(mailMessage);
        }
    }
}
