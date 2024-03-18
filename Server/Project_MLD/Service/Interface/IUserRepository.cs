using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User User);
        Task<bool> UpdateUser(User User);
        //Task<User> Login()
    }
}
