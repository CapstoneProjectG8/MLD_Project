using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> AddAccount(Account acc);
        Task<bool> UpdateAccount(Account acc);
        Task<bool> DeleteAccount(int id);
        Account GetAccountByUsername(string username);
    }
}
