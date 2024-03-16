using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IAccountRoleRepository
    {
        Task<IEnumerable<AccountRole>> GetAllAccountRoles();
        Task<AccountRole> GetAccountRoleByAccountId(int id);
        Task<AccountRole> AddAccountRole(AccountRole ar);
    }
}
