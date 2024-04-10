using System.Text;

namespace Project_MLD.Utils.GmailSender
{
    public class MailBody : IMailBody
    {
        public string EmailBodyResetPassword(string randomCode)
        {
            return @"
            <html lang=""en"">" +
                @"
            <head>" +
                @"
                <meta charset=""UTF-8"">" +
                @"
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" +
                @"
                <title>Your Email Subject</title>" +
                @"
                <style>" +
                @"
                    /* Style your email here */" +
                @"
                    body {" +
                @"
                        font-family: Arial, sans-serif;" +
                @"
                        line-height: 1.6;" +
                @"
                        background-color: #f4f4f4;" +
                @"
                        margin: 0;" +
                @"
                        padding: 0;" +
                @"
                    }" +
                @"
                    .container {" +
                @"
                        max-width: 600px;" +
                @"
                        margin: 0 auto;" +
                @"
                        padding: 20px;" +
                @"
                        background-color: #ffffff;" +
                @"
                        border-radius: 8px;" +
                @"
                        box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);" +
                @"
                    }" +
                @"
                    h1 {" +
                @"
                        color: #333333;" +
                @"
                        font-size: 20px;" +
                @"
                    }" +
                @"
                    p {" +
                @"
                        color: #666666;" +
                @"
                    }" +
                @"
                    .button {" +
                @"
                        display: inline-block;" +
                @"
                        background-color: #007bff;" +
                @"
                        color: #ffffff;" +
                @"
                        padding: 10px 20px;" +
                @"
                        text-decoration: none;" +
                @"
                        border-radius: 4px;" +
                @"
                    }" +
                @"
                </style>" +
                @"
            </head>" +
                @"
            <body>" +
                @"
                <div class=""container"">" +
                @"
                    <h1 style=""font-size: 20px;color: #007bff;"">Hello Teachers: </h1>" +
                @"
                    <p>Did you request a password change?</p>" +
                @"
                    <p>To reset your password, we have sent you a code.</p>" +
                @"
                    <p><strong>Code:</strong> " + randomCode + "</p>" +
                @"
                    <p>Please remember your password next time.</p>" +
                @"
                    <p>Thank you</p>" +
                @"
                </div>" +
                @"
            </body>" +
                @"
            </html>";
        }

        public string SubjectTitleResetPassword(string randomCode)
        {
            return "Reset Password Code: " + randomCode;
        }
    }
}
