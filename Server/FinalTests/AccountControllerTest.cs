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

public class AccountControllerTests
{
    private readonly Mock<IAccountRepository> _mockRepository;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly AccountController _controller;
    private Mock<MldDatabaseContext> _context;



    public AccountControllerTests()
    {
        var options = new DbContextOptionsBuilder<MldDatabaseContext>()
               .UseSqlServer("ConnectionStrings")
                /*seSqlServer("ConnectionStrings")*/
                .Options;

         _context = new Mock<MldDatabaseContext>(options);
        _mockRepository = new Mock<IAccountRepository>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _controller = new AccountController(null, _mockRepository.Object, _context.Object , null, _mockPasswordHasher.Object, null, null, null);
    }

    //public void Dispose()
    //{
    //    _context.Database.EnsureDeleted();
    //}
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

    //[Fact]
    //public async Task SendMailResetPassword_ReturnsBadRequest_WhenUserNotFound()
    //{
    //    // Arrange
    //    _context.Setup(x => x.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
    //        .ReturnsAsync((User)null);

    //    // Act
    //    var result = await _controller.SendMailResetPassword("test@mail.com");

    //    // Assert
    //    Assert.IsType<BadRequestObjectResult>(result);
    //}

    //[Fact]
    //public async Task SendMailResetPassword_ReturnsBadRequest_WhenAccountNotFound()
    //{
    //    // Arrange
    //    _context.Setup(x => x.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
    //        .ReturnsAsync(new User());
    //    _context.Setup(x => x.Accounts.Where(It.IsAny<Expression<Func<Account, bool>>>()).FirstOrDefaultAsync())
    //        .ReturnsAsync((Account)null);

    //    // Act
    //    var result = await _controller.SendMailResetPassword("test@mail.com");

    //    // Assert
    //    Assert.IsType<BadRequestObjectResult>(result);
    //}

    //[Fact]
    //public async Task SendMailResetPassword_ReturnsOk_WhenMailSentSuccessfully()
    //{
    //    // Arrange
    //    _context.Setup(x => x.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
    //        .ReturnsAsync(new User());
    //    _context.Setup(x => x.Accounts.Where(It.IsAny<Expression<Func<Account, bool>>>()).FirstOrDefaultAsync())
    //        .ReturnsAsync(new Account());
    //    _codeGenerate.Setup(x => x.GenerateRandomCode()).Returns("123456");
    //    _mockPasswordHasher.Setup(x => x.Hash(It.IsAny<string>())).Returns("hashedpassword");
    //    _emailSender.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
    //        .Returns(Task.CompletedTask);

    //    // Act
    //    var result = await _controller.SendMailResetPassword("test@mail.com");

    //    // Assert
    //    Assert.IsType<OkObjectResult>(result);
    //}


}


