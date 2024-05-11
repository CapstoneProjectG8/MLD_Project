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
using Microsoft.OpenApi.Any;
using static Project_MLD.Controllers.AccountController;

namespace ControllerTest;

public class AccountControllerTests
{
    private readonly Mock<IAccountRepository> _mockRepository;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly AccountController _controller;
    private readonly Mock<IEmailSender> _mockEmailSender;
    private readonly Mock<IMailBody> _mockMailBody;
    private readonly Mock<IGenerateCode> _mockCodeGenerate;
    private readonly Mock<IMapper> _mockMapper;

    public AccountControllerTests()
    {

        _mockRepository = new Mock<IAccountRepository>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _mockEmailSender = new Mock<IEmailSender>();
        _mockCodeGenerate = new Mock<IGenerateCode>();
        _mockMailBody = new Mock<IMailBody>();
        _mockMapper = new Mock<IMapper>();
        _controller = new AccountController(_mockRepository.Object, _mockMapper.Object, _mockPasswordHasher.Object, _mockEmailSender.Object, _mockMailBody.Object, _mockCodeGenerate.Object);
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsOkResultWithToken()
    {
        // Arrange
        var loginModel = new LoginModel { Username = "testuser", Password = "testpassword" };
        var user = new User(); // Assuming User is the correct type
        var expectedToken = "testtoken";

        _mockRepository.Setup(r => r.AuthenticateAccountByUser(It.IsAny<string>(), It.IsAny<string>())).Returns(user);
        _mockRepository.Setup(r => r.GenerateToken(It.IsAny<User>())).Returns(expectedToken);

        // Act
        var result = _controller.Login(loginModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedToken, okResult.Value);
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsNotFoundResult()
    {
        // Arrange
        var loginModel = new LoginModel { Username = "testuser", Password = "wrongpassword" };

        _mockRepository.Setup(r => r.AuthenticateAccountByUser(It.IsAny<string>(), It.IsAny<string>())).Returns((User)null);

        // Act
        var result = _controller.Login(loginModel);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public void Login_WithNullUsernameOrPassword_ReturnsBadRequestResult()
    {
        // Arrange
        var loginModel = new LoginModel { Username = null, Password = null };

        // Act
        var result = _controller.Login(loginModel);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }


    [Fact]
    public async Task GetAllAccounts_ReturnsOkResult_WithAllAccounts()
    {
        // Arrange
        var allAccounts = new List<Account> { new Account(), new Account() };
        var allAccountDTOs = new List<AccountDTO> { new AccountDTO(), new AccountDTO() }; // assuming AccountDTO has a parameterless constructor

        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(allAccounts);
        _mockMapper.Setup(mapper => mapper.Map<List<AccountDTO>>(allAccounts)).Returns(allAccountDTOs); // mock the mapper

        // Act
        var result = await _controller.GetAllAccounts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<AccountDTO>>(okResult.Value);
        Assert.Equal(allAccountDTOs.Count, returnValue.Count);
    }


    [Fact]
    public async Task GetAllAccounts_ReturnsEmptyList_WhenNoAccountsExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(new List<Account>());
        _mockMapper.Setup(mapper => mapper.Map<List<AccountDTO>>(It.IsAny<List<Account>>())).Returns(new List<AccountDTO>()); // mock the mapper

        // Act
        var result = await _controller.GetAllAccounts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<AccountDTO>>(okResult.Value);
        Assert.Empty(returnValue);
    }

    [Fact]
    public async Task GetAllAccounts_ReturnsCorrectNumberOfAccounts()
    {
        // Arrange
        var allAccounts = new List<Account> { new Account(), new Account(), new Account() };
        var allAccountDTOs = new List<AccountDTO> { new AccountDTO(), new AccountDTO(), new AccountDTO() }; // assuming AccountDTO has a parameterless constructor

        _mockRepository.Setup(repo => repo.GetAllAccounts()).ReturnsAsync(allAccounts);
        _mockMapper.Setup(mapper => mapper.Map<List<AccountDTO>>(allAccounts)).Returns(allAccountDTOs); // mock the mapper

        // Act
        var result = await _controller.GetAllAccounts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<AccountDTO>>(okResult.Value);
        Assert.Equal(allAccountDTOs.Count, returnValue.Count);
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
    public async Task GetAccountById_ReturnsNotFoundObjectResult_WhenAccountDoesNotExist()
    {
        // Arrange
        var accountId = 1;
        _mockRepository.Setup(repo => repo.GetAccountById(accountId)).ReturnsAsync((Account)null);

        // Act
        var result = await _controller.GetAccountById(accountId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
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
        var accountDTO = new AccountDTO { Username = "testuser", Password = "password", Active = true, CreatedBy = 1, CreatedDate = DateOnly.FromDateTime(DateTime.Now), LoginLast = DateTime.Now, LoginAttempt = 0 };
        var account = new Account
        {
            Username = "testuser",
            Password = "password",
            Active = true,
            CreatedBy = 1,
            CreatedDate = DateOnly.FromDateTime(DateTime.Now),
            RoleId = 1,
            LoginAttempt = 0,
            LoginLast = DateTime.Now,
            Role = new Role(), // assuming Role has a parameterless constructor
            Users = new List<User>() // initialize with an empty list of User
        };

        _mockRepository.Setup(repo => repo.GetAccountByUsername(accountDTO.Username)).Returns((Account)null);
        _mockRepository.Setup(repo => repo.AddAccount(It.IsAny<Account>())).ReturnsAsync(account);
        _mockPasswordHasher.Setup(hasher => hasher.Hash(accountDTO.Password)).Returns("hashedpassword");
        _mockMapper.Setup(mapper => mapper.Map<Account>(accountDTO)).Returns(account);

        // Act
        await _controller.AddAccount(accountDTO);

        // Assert
        _mockRepository.Verify(repo => repo.AddAccount(It.IsAny<Account>()), Times.Once);
    }
    [Fact]
    public async Task UpdateAccount_UpdatesAccount_WhenPasswordIsNotNull()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser", Password = "password" };
        var account = new Account { Username = "testuser", Password = "hashedpassword" };
        _mockPasswordHasher.Setup(hasher => hasher.Hash(accountDTO.Password)).Returns("hashedpassword");
        _mockMapper.Setup(mapper => mapper.Map<Account>(accountDTO)).Returns(account);
        _mockRepository.Setup(repo => repo.UpdateAccount(account)).ReturnsAsync(account);

        // Act
        var result = await _controller.UpdateAccount(accountDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Account>(okResult.Value);
        Assert.Equal(account, returnValue);
    }

    [Fact]
    public async Task UpdateAccount_ReturnsNotFound_WhenAccountDoesNotExist()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser", Password = "password" };
        _mockRepository.Setup(repo => repo.UpdateAccount(It.IsAny<Account>())).ReturnsAsync((Account)null);

        // Act
        var result = await _controller.UpdateAccount(accountDTO);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateAccount_UpdatesAccount_WhenPasswordIsNull()
    {
        // Arrange
        var accountDTO = new AccountDTO { Username = "testuser", Password = null };
        var account = new Account { Username = "testuser", Password = null };
        _mockMapper.Setup(mapper => mapper.Map<Account>(accountDTO)).Returns(account);
        _mockRepository.Setup(repo => repo.UpdateAccount(account)).ReturnsAsync(account);

        // Act
        var result = await _controller.UpdateAccount(accountDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Account>(okResult.Value);
        Assert.Equal(account, returnValue);
    }
    [Fact]
    public async Task SendMailResetPassword_ReturnsBadRequest_WhenUserNotFound()
    {
        // Arrange
        string mail = "testuser@mail.com";
        _mockRepository.Setup(repo => repo.GetUserByEmail(mail)).ReturnsAsync((User)null);

        // Act
        var result = await _controller.SendMailResetPassword(mail);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("User not found.", badRequestResult.Value);
    }

    [Fact]
    public async Task SendMailResetPassword_ReturnsBadRequest_WhenAccountNotFound()
    {
        // Arrange
        string mail = "testuser@mail.com";
        var currentAccount = new User { AccountId = 1 };
        _mockRepository.Setup(repo => repo.GetUserByEmail(mail)).ReturnsAsync(currentAccount);
        _mockRepository.Setup(repo => repo.GetAccountById(currentAccount.AccountId)).ReturnsAsync((Account)null);

        // Act
        var result = await _controller.SendMailResetPassword(mail);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Account not found for the user.", badRequestResult.Value);
    }

    [Fact]
    public async Task SendMailResetPassword_ReturnsOk_WhenMailSentSuccessfully()
    {
        // Arrange
        string mail = "testuser@mail.com";
        var currentAccount = new User { AccountId = 1 };
        var account = new Account { AccountId = 1, Username = "testuser", Password = "password" };
        string codeGenerate = "123456";
        _mockRepository.Setup(repo => repo.GetUserByEmail(mail)).ReturnsAsync(currentAccount);
        _mockRepository.Setup(repo => repo.GetAccountById(currentAccount.AccountId)).ReturnsAsync(account);
        _mockCodeGenerate.Setup(code => code.GenerateRandomCode()).Returns(codeGenerate);
        _mockPasswordHasher.Setup(hasher => hasher.Hash(codeGenerate)).Returns("hashedpassword");
        _mockRepository.Setup(repo => repo.UpdateAccount(account)).ReturnsAsync(account);
        _mockEmailSender.Setup(sender => sender.SendEmailAsync(mail, It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.SendMailResetPassword(mail);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Reset password email sent to " + mail  , okResult.Value);


    }
    [Fact]
    public async Task ChangePassword_ReturnsBadRequest_WhenUserNotFound()
    {
        // Arrange
        string username = "testuser";
        _mockRepository.Setup(repo => repo.GetAccountByUsername(username)).Returns((Account)null);

        // Act
        var result = await _controller.ChangePassword(username, "currentPassword", "newPassword");

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("User not found.", badRequestResult.Value);
    }

    [Fact]
    public async Task ChangePassword_ReturnsBadRequest_WhenCurrentPasswordIncorrect()
    {
        // Arrange
        string username = "testuser";
        var account = new Account { Username = username, Password = "hashedpassword" };
        _mockRepository.Setup(repo => repo.GetAccountByUsername(username)).Returns(account);
        _mockPasswordHasher.Setup(hasher => hasher.VerifyPassword(account.Password, "wrongPassword")).Returns(false);

        // Act
        var result = await _controller.ChangePassword(username, "wrongPassword", "newPassword");

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Incorrect current password.", badRequestResult.Value);
    }

    [Fact]
    public async Task ChangePassword_ReturnsOk_WhenPasswordUpdatedSuccessfully()
    {
        // Arrange
        string username = "testuser";
        var account = new Account { Username = username, Password = "hashedpassword" };
        _mockRepository.Setup(repo => repo.GetAccountByUsername(username)).Returns(account);
        _mockPasswordHasher.Setup(hasher => hasher.VerifyPassword(account.Password, "currentPassword")).Returns(true);
        _mockRepository.Setup(repo => repo.CheckPasswordValidation("newPassword")).Returns(true);
        _mockPasswordHasher.Setup(hasher => hasher.Hash("newPassword")).Returns("hashedNewPassword");
        _mockRepository.Setup(repo => repo.UpdateAccount(account)).ReturnsAsync(account);

        // Act
        var result = await _controller.ChangePassword(username, "currentPassword", "newPassword");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Password updated successfully.", okResult.Value);
    }

}

//[Fact]
//public async Task SendMailResetPassword_WithNonExistingUser_ReturnsBadRequest()
//{
//    // Arrange
//    var email = "nonexistinguser@test.com";

//    // Act
//    var result = await _controller.SendMailResetPassword(email);

//    // Assert
//    Assert.IsType<BadRequestObjectResult>(result);
//}

//[Fact]
//public async Task SendMailResetPassword_WithExistingUserButNoAccount_ReturnsBadRequest()
//{
//    // Arrange
//    var email = "existinguser@test.com";
//    var fullname = "hung";
//    var account = new Account();
//    _mockContext.Accounts.Add(account);
//    await _mockContext.SaveChangesAsync();

//    var user = new User { Email = email, FullName = fullname, AccountId = account.AccountId };
//    _mockContext.Users.Add(user);
//    await _mockContext.SaveChangesAsync();

//    // Act
//    var result = await _controller.SendMailResetPassword(email);

//    // Assert
//    Assert.IsType<BadRequestObjectResult>(result);
//}


//[Fact]
//public async Task SendMailResetPassword_WithValidUserAndAccount_ReturnsOk()
//{
//    // Arrange
//    var email = "validuser@test.com";
//    var account = new Account();
//    _mockContext.Accounts.Add(account);
//    await _mockContext.SaveChangesAsync();

//    var user = new User { Email = email, AccountId = account.AccountId };
//    _mockContext.Users.Add(user);
//    await _mockContext.SaveChangesAsync();

//    // Act
//    var result = await _controller.SendMailResetPassword(email);

//    // Assert
//    var okResult = Assert.IsType<OkObjectResult>(result);
//    Assert.NotNull(okResult.Value);
//}







