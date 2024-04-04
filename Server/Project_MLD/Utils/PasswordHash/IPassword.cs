using Project_MLD.Models;

namespace Project_MLD.Utils.PasswordHash
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool VerifyPassword(string passwordHash, string password);
    }
}
