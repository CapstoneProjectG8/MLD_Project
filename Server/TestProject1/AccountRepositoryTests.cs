using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace TestProject1
{
    public class AccountRepositoryTests
    {
        private MldDatabaseContext _context;
        private AccountRepository _repo;
        public AccountRepositoryTests()
        {
            

      
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repo = new AccountRepository(_context);
        }


        [Fact]
        public async Task GetAllAccounts_ShouldReturnAllAccounts()
        {
            // Arrange
            //var account1 = new Account { Username = "TestUser1" };
            //var account2 = new Account { Username = "TestUser2" };
            //_context.Accounts.AddRange(account1, account2);
            //await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllAccounts();

            // Assert
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public async Task GetAccountById_ShouldReturnAccount()
        {
            // Arrange
            //var account = new Account { AccountId = 11, Username = "TestUser" };
            //_context.Accounts.Add(account);
            //await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAccountById(11);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("JohnDoe", result.Username);
        }

        [Fact]
        public async Task AddAccount_ShouldAddAccount()
        {
            // Arrange
            var account = new Account { Username = "TestUser" , Password ="abc" };

            // Act
            var result = await _repo.AddAccount(account);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(account.Username, result.Username);
        }

        [Fact]
        public async Task UpdateAccount_ShouldUpdateAccount()
        {
            // Arrange
            var account = new Account { AccountId = 1, Username = "TestUser" };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            account.Username = "UpdatedUser";

            // Act
            var result = await _repo.UpdateAccount(account);

            // Assert
            Assert.True(result);
            Assert.Equal("UpdatedUser", _context.Accounts.Find(1).Username);
        }

        [Fact]
        public async Task DeleteAccount_ShouldDeleteAccount()
        {
            // Arrange
            var account = new Account { AccountId = 1, Username = "TestUser" };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.DeleteAccount(1);

            // Assert
            Assert.True(result);
            Assert.Null(await _repo.GetAccountById(1));
        }

       
    }
}
