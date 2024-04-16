using System.CodeDom.Compiler;
using System.Text;

namespace Project_MLD.Utils.GmailSender
{
    public interface IMailBody
    {
        string EmailBodyResetPassword(string username, string randomCode);
        string SubjectTitleResetPassword(string randomCode);
    }
}
