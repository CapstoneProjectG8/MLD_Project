using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> AddAccount(Account acc);
        Task<bool> UpdateAccount(Account acc);
        Task<Account> GetAccountByUsername(string username);
        Task<IEnumerable<Notification>> GetAllNotification();
        Task<IEnumerable<Report>> GetAllReport();
    }
}
