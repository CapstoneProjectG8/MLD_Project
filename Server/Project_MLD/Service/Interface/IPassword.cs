using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool VerifyPassword(string passwordHash, string password);
    }
}
