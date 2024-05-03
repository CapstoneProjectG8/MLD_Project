using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Controllers;
using Project_MLD.DTO;
using Project_MLD.Service.Interface;
using Project_MLD.Models;
using Project_MLD.Utils.PasswordHash;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project_MLD.Utils.GenerateCode;
using Project_MLD.Utils.GmailSender;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace ControllerTest;

public class AccountControllerTests
{
    private readonly Mock<IAccountRepository> _mockRepository;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly AccountController _controller;
    private readonly MldDatabase2Context _mockContext;
    private readonly Mock<IEmailSender> _mockEmailSender;
    private readonly Mock<IMailBody> _mockMailBody;
    private readonly Mock<IGenerateCode> _mockCodeGenerate;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly Mock<IMapper> _mockMapper;

    public AccountControllerTests()
    {
        var options = new DbContextOptionsBuilder<MldDatabase2Context>()
               .UseSqlServer("ConnectionStrings")
                .Options;

        _mockContext = new MldDatabase2Context(options);
        _mockRepository = new Mock<IAccountRepository>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _mockEmailSender = new Mock<IEmailSender> ();
        _mockCodeGenerate = new Mock<IGenerateCode> ();
        _mockMailBody = new Mock<IMailBody> (); 
        _mockMapper = new Mock<IMapper> ();
        _mockConfig = new Mock<IConfiguration> ();
        _controller = new AccountController(_mockConfig.Object, _mockRepository.Object, _mockContext, _mockMapper.Object, _mockPasswordHasher.Object, _mockEmailSender.Object, _mockMailBody.Object, _mockCodeGenerate.Object);
    }

    public void Dispose()
    {
        _mockContext.Database.EnsureDeleted();
    }
    [Fact]
    public void Login_WithNullUsername_ReturnsBadRequest()
    {
        var accountLogin = new AccountDTO { Username = null, Password = "password" };
        var result = _controller.Login(accountLogin);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Login_WithNullPassword_ReturnsBadRequest()
    {
        var accountLogin = new AccountDTO { Username = "username", Password = null };
        var result = _controller.Login(accountLogin);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsBadRequest()
    {
        // Arrange
        var accountLogin = new AccountDTO { Username = "dg12", Password = "Dung101201@" };

        // Act
        var result = _controller.Login(accountLogin);

        // Assert
        Assert.IsType<ObjectResult>(result);
        var objectResult = result as ObjectResult;
        Assert.Equal(400, objectResult.StatusCode);
        Assert.Equal("Account not found.", objectResult.Value);
    }


    [Fact]
    public async Task GetAllAccount_ReturnsOkResult_WithAllAccounts()
    {
        // Arrange
        var allAccounts = new List<Account> { new Account(), new Account() };
        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(allAccounts);

        // Act
        var result = await _controller.GetAllAccount();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Account>>(okResult.Value);
        Assert.Equal(allAccounts.Count, returnValue.Count);
    }
    [Fact]
    public async Task GetAllAccount_ReturnsEmptyList_WhenNoAccountsExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(new List<Account>());

        // Act
        var result = await _controller.GetAllAccount();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Account>>(okResult.Value);
        Assert.Empty(returnValue);
    }

    [Fact]
    public async Task GetAllAccount_ReturnsCorrectNumberOfAccounts()
    {
        // Arrange
        var allAccounts = new List<Account> { new Account(), new Account(), new Account() };
        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(allAccounts);

        // Act
        var result = await _controller.GetAllAccount();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Account>>(okResult.Value);
        Assert.Equal(allAccounts.Count, returnValue.Count);
    }


    [Fact]
    public async Task GetAccountById_ReturnsOkResult_WithAccount()
    {
        // Arrange
        var accountId = 1;
        var account = new Account();
        _mockRepository.Setup(repo => repo.GetAccountById(accountId)).ReturnsAsync(account);

        // Act
        var result = await _controller.GetAccountById(accountId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Account>(okResult.Value);
        Assert.Equal(account, returnValue);
    }
    [Fact]
    public async Task GetAccountById_ReturnsCorrectAccount()
    {
        // Arrange
        var accountId = 1;
        var account = new Account { AccountId = accountId };
        _mockRepository.Setup(repo => repo.GetAccountById(accountId)).ReturnsAsync(account);

        // Act
        var result = await _controller.GetAccountById(accountId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Account>(okResult.Value);
        Assert.Equal(account, returnValue);
    }

    [Fact]
    public async Task GetAccountById_ReturnsNotFoundResult_WhenAccountDoesNotExist()
    {
        // Arrange
        var accountId = 1;
        _mockRepository.Setup(repo => repo.GetAccountById(accountId)).ReturnsAsync((Account)null);

        // Act
        var result = await _controller.GetAccountById(accountId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddAccount_ReturnsBadRequestResult_WhenAccountExists()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser" };
        _mockRepository.Setup(repo => repo.GetAccountByUsername(accountDTO.Username)).Returns(new Account());

        // Act
        var result = await _controller.AddAccount(accountDTO);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task AddAccount_ReturnsOkResult_WhenAccountDoesNotExist()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser" };
        _mockRepository.Setup(repo => repo.GetAccountByUsername(accountDTO.Username)).Returns((Account)null);
        _mockRepository.Setup(repo => repo.AddAccount(It.IsAny<Account>())).ReturnsAsync(new Account());

        // Act
        var result = await _controller.AddAccount(accountDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<Account>(okResult.Value);


    }

    [Fact]
    public async Task AddAccount_CreatesNewAccount_WithCorrectProperties()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser", Password = "password" };
        _mockRepository.Setup(repo => repo.GetAccountByUsername(accountDTO.Username)).Returns((Account)null);
        _mockRepository.Setup(repo => repo.AddAccount(It.IsAny<Account>())).ReturnsAsync(new Account());
        _mockPasswordHasher.Setup(hasher => hasher.Hash(accountDTO.Password)).Returns("hashedpassword");

        // Act
        var result = await _controller.AddAccount(accountDTO);

        // Assert
        _mockRepository.Verify(repo => repo.AddAccount(It.Is<Account>(acc =>
            acc.Username == accountDTO.Username &&
            acc.Password == "hashedpassword" &&
            acc.Active == true &&
            acc.CreatedBy == "ADMIN" &&
            acc.LoginAttempt == 0
        )), Times.Once);
    }
    [Fact]
    public async Task UpdateAccount_WithMismatchedId_ReturnsBadRequest()
    {
        // Arrange
        var accountDto = new AccountDTO { AccountId = 1 };
        var id = 2;

        // Act
        var result = await _controller.UpdateAccount(id, accountDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateAccount_WithValidAccount_ReturnsOk()
    {
        // Arrange
        var accountDto = new AccountDTO { AccountId = 1, Password = "testpassword" };
        var id = 1;
        _mockRepository.Setup(r => r.UpdateAccount(It.IsAny<Account>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateAccount(id, accountDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAccount = Assert.IsType<Account>(okResult.Value);
        Assert.Equal(accountDto.AccountId, returnAccount.AccountId);
    }

    [Fact]
    public async Task UpdateAccount_WithNonExistingAccount_ReturnsNotFound()
    {
        // Arrange
        var accountDto = new AccountDTO { AccountId = 1, Password = "testpassword" };
        var id = 1;
        _mockRepository.Setup(r => r.UpdateAccount(It.IsAny<Account>())).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateAccount(id, accountDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    [Fact]
    public async Task SendMailResetPassword_WithNonExistingUser_ReturnsBadRequest()
    {
        // Arrange
        var email = "nonexistinguser@test.com";

        // Act
        var result = await _controller.SendMailResetPassword(email);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task SendMailResetPassword_WithExistingUserButNoAccount_ReturnsBadRequest()
    {
        // Arrange
        var email = "existinguser@test.com";
        var fullname = "hung";
        var account = new Account();
        _mockContext.Accounts.Add(account);
        await _mockContext.SaveChangesAsync();

        var user = new User { Email = email, FullName = fullname, AccountId = account.AccountId };
        _mockContext.Users.Add(user);
        await _mockContext.SaveChangesAsync();

        // Act
        var result = await _controller.SendMailResetPassword(email);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }


    [Fact]
    public async Task SendMailResetPassword_WithValidUserAndAccount_ReturnsOk()
    {
        // Arrange
        var email = "validuser@test.com";
        var account = new Account();
        _mockContext.Accounts.Add(account);
        await _mockContext.SaveChangesAsync();

        var user = new User { Email = email, AccountId = account.AccountId };
        _mockContext.Users.Add(user);
        await _mockContext.SaveChangesAsync();

        // Act
        var result = await _controller.SendMailResetPassword(email);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }


}




