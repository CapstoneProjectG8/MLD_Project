using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> AddAccount(Account acc);
        Task<Account> UpdateAccount(Account acc);
        Task<bool> DeleteAccount(int id);
        Account GetAccountByUsername(string username);
        User AuthenticateAccountByUser(string username, string password);
        Task<User> GetUserByEmail(string email);
        //Task<Account> GetAccountByAccountId(int accountId);
        void UpdateAccountLoginInfo(Account account);
        bool CheckPasswordValidation(string password);
        string GenerateToken(User user);


    }
}
