using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class AccountRepositoryTests : IDisposable
    {
        private readonly MldDatabaseContext _context;
        private readonly AccountRepository _repository;

        public AccountRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new AccountRepository(_context);
        }

        public void Dispose()
        {
            // Clean up the database here
            _context.Accounts.RemoveRange(_context.Accounts);
            _context.SaveChanges();
        }

        [Fact]
        public async Task AddAccountTest()
        {
            var account = new Account { Username = "testuser", Password = "testpass" };
            var result = await _repository.AddAccount(account);

            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task DeleteAccountTest()
        {
            var account = new Account { Username = "testuser", Password = "testpass" };
            var addedAccount = await _repository.AddAccount(account);

            var result = await _repository.DeleteAccount(addedAccount.AccountId);

            Assert.True(result);
        }

        [Fact]
        public async Task GetAllAccountsTest()
        {
            // Arrange
            var account1 = new Account { Username = "testuser1", Password = "testpass1" };
            var account2 = new Account { Username = "testuser2", Password = "testpass2" };
            _context.Accounts.AddRange(account1, account2);
            await _context.SaveChangesAsync();

            // Act
            var accounts = await _repository.GetAllAccounts();

            // Assert
            Assert.NotNull(accounts);
            Assert.NotEmpty(accounts);
        }


        [Fact]
        public async Task GetAccountByIdTest()
        {
            var account = new Account { Username = "testuser", Password = "testpass" };
            var addedAccount = await _repository.AddAccount(account);

            var result = await _repository.GetAccountById(addedAccount.AccountId);

            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task UpdateAccountTest()
        {
            var account = new Account { Username = "testuser", Password = "testpass" };
            var addedAccount = await _repository.AddAccount(account);

            addedAccount.Password = "newpass";
            var result = await _repository.UpdateAccount(addedAccount);

            Assert.True(result);
        }

        [Fact]
        public void GetAccountByUsernameTest()
        {
            var account = new Account { Username = "testuser", Password = "testpass" };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var result = _repository.GetAccountByUsername("testuser");

            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }
    }
}
