using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class RoleRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly RoleRepository _repository;

        public RoleRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new RoleRepository(_context);
        }

        [Fact]
        public async Task AddRole_ReturnsNewRole()
        {
            // Arrange
            var role = new Role
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddRole(role);

            // Assert
            Assert.Equal(role, result);

            // Clean up
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteRole_ReturnsTrue_WhenRoleExists()
        {
            // Arrange
            var role = new Role { RoleName = "Test Role" };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteRole(role.RoleId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllRoles_ReturnsAllRoles_WhenCalled()
        {
            // Arrange
            var role = new Role { RoleName = "Test Role" };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllRoles();

            // Assert
            Assert.Contains(role, result);

            // Clean up
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetRoleById_ReturnsRole_WhenRoleExists()
        {
            // Arrange
            var role = new Role { RoleName = "Test Role" };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetRoleById(role.RoleId);

            // Assert
            Assert.Equal(role, result);

            // Clean up
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateRole_ReturnsTrue_WhenRoleExists()
        {
            // Arrange
            var role = new Role { RoleName = "Test Role" };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            role.RoleName = "Updated Role";

            // Act
            var result = await _repository.UpdateRole(role);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
