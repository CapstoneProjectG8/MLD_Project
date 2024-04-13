using Microsoft.EntityFrameworkCore;
using Moq;
using Project_MLD.Models;
using Project_MLD.Service.Repository;

namespace FinalTest
{ 
    public class UserRepositoryTests
    {
        private readonly Mock<MldDatabaseContext> _mockContext;
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _mockContext = new Mock<MldDatabaseContext>(options);
            _repository = new UserRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddUser_ReturnsUser_WhenUserIsAdded()
        {
            // Arrange
            var user = new User { Id = 1, Email = "john@edu.com" };
            var mockSet = new Mock<DbSet<User>>();
            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1); // SaveChangesAsync returns number of entries written to the database

            // Act
            var result = await _repository.AddUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Email, result.Email);
            _mockContext.Verify(m => m.Users.Add(It.Is<User>(u => u == user)), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var user = new User { Id = 1, Email = "john@edu.com" };
            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.FindAsync(user.Id)).Returns(new ValueTask<User>(user));
            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.DeleteUser(user.Id);

            // Assert
            Assert.True(result);
            _mockContext.Verify(m => m.Users.Remove(It.Is<User>(u => u == user)), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        [Fact]
        public async Task GetAllUsers_ReturnsAllUsers()
        {
            // Arrange
            var data = new List<User>
            {
                new User { Id = 1, Email = "john@edu.com" },
                new User { Id = 2, Email = "jane@edu.com" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            // Act
            var users = await _repository.GetAllUsers();

            // Assert
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public async Task GetUserById_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Id = 1, Email = "john@edu.com" };
            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.FindAsync(user.Id)).Returns(new ValueTask<User>(user));
            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetUserById(user.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var user = new User { Id = 1, Email = "john@edu.com" };
            var updatedUser = new User { Id = 1, Email = "john_updated@edu.com" };
            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.FindAsync(user.Id)).Returns(new ValueTask<User>(user));
            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.UpdateUser(updatedUser);

            // Assert
            Assert.True(result);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }


    }
}
