using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersByDepartmentId(int id);
        Task<IEnumerable<User>> GetPrinciples();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User User);
        Task<bool> UpdateUser(User User);
        Task<IEnumerable<object>> GetTotalUserLevelOfTrainning();
        Task<IEnumerable<object>> GetTotalUserProfessionalStandard();
        Task<IEnumerable<object>> GetTotalUserBySpecializedDepartmentId(int id);
    }
}
