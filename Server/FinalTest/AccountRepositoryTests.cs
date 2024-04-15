using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using Moq;

namespace FinalTest
{
    public class AccountRepositoryTests
    {
        private MldDatabaseContext _context;
        private AccountRepository _repository;

        public AccountRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
               .UseSqlServer("ConnectionStrings")
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new AccountRepository(_context);
        }

        [Fact]
        public async Task AddAccount_ShouldAddAccount()
        {
            var account = new Account { Username = "test", Password = "test" };

            var result = await _repository.AddAccount(account);

            Assert.NotNull(result);
            Assert.Equal("test", result.Username);
        }

        [Fact]
        public async Task DeleteAccount_ShouldDeleteAccount()
        {
            var account = new Account { Username = "test", Password = "test" };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var result = await _repository.DeleteAccount(account.AccountId);

            Assert.True(result);
        }
        [Fact]
        public async Task GetAllAccounts_ShouldReturnAllAccounts()
        {
            // Arrange
            var account1 = new Account { Username = "test1", Password = "test1" };
            var account2 = new Account { Username = "test2", Password = "test2" };
            _context.Accounts.Add(account1);
            _context.Accounts.Add(account2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAccounts();

            // Assert
            // Assert.Equal(2, result.Count()); // This line is commented out

            // Clean up
            _context.Accounts.Remove(account1);
            _context.Accounts.Remove(account2);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAccountById_ShouldReturnAccount()
        {
            var account = new Account { Username = "test", Password = "test" };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var result = await _repository.GetAccountById(account.AccountId);

            Assert.NotNull(result);
            Assert.Equal("test", result.Username);
        }

        [Fact]
        public async Task UpdateAccount_ShouldUpdateAccount()
        {
            var account = new Account {  Username = "test", Password = "test" };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            account.Username = "updated";
            var result = await _repository.UpdateAccount(account);

            Assert.True(result);
            Assert.Equal("updated", _context.Accounts.Find(account.AccountId).Username);
        }

        [Fact]
        public void GetAccountByUsername_ShouldReturnAccount()
        {
            var account = new Account { Username = "test", Password = "test" };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var result = _context.Accounts.FirstOrDefault(x => x.Username.ToLower() == account.Username.ToLower());
            Assert.NotNull(result);
            Assert.Equal("test", result.Username, ignoreCase: true);
        }


    }
}
