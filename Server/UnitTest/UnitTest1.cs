using Moq;
using Project_MLD.Service.Interface;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Login_ValidCredentials_ReturnsOkWithToken()
        {

            // Arrange
            var mockRepo = new Mock<IAccountRepository>();
            var mockUser = new User { FullName = "Test User", Email = "test@example.com", Account = new Account { Username = "testuser", Password = "P@ssw0rd!", Role = new Role { RoleName = "User" } } };
            mockRepo.Setup(r => r.GetAccountByUsername(It.IsAny<string>())).ReturnsAsync(mockUser.Account);
            var passwordHasher = new Mock<IPasswordHasher>();
            passwordHasher.Setup(p => p.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var controller = new AccountController(Mock.Of<IConfiguration>(), mockRepo.Object, Mock.Of<MldDatabaseContext>(), Mock.Of<IMapper>(), passwordHasher.Object);
            var loginDto = new AccountDTO { Username = "testuser", Password = "P@ssw0rd!" };

            // Act
            var result = await controller.Login(loginDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value); // Ensure a token is returned
        }
    }
}