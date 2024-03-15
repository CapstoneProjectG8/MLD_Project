using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<Role> AddRole(Role role);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(int id);

    }
}
