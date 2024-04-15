using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class SpecializedDepartmentRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly SpecializedDepartmentRepository _repository;

        public SpecializedDepartmentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new SpecializedDepartmentRepository(_context);
        }

        [Fact]
        public async Task AddSpecializedDepartment_ReturnsNewSpecializedDepartment()
        {
            // Arrange
            var specializedDepartment = new SpecializedDepartment
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddSpecializedDepartment(specializedDepartment);

            // Assert
            Assert.Equal(specializedDepartment, result);

            // Clean up
            _context.SpecializedDepartments.Remove(specializedDepartment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteSpecializedDepartment_ReturnsTrue_WhenSpecializedDepartmentExists()
        {
            // Arrange
            var specializedDepartment = new SpecializedDepartment { Name = "Test SpecializedDepartment" };
            _context.SpecializedDepartments.Add(specializedDepartment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteSpecializedDepartment(specializedDepartment.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllSpecializedDepartments_ReturnsAllSpecializedDepartments_WhenCalled()
        {
            // Arrange
            var specializedDepartment = new SpecializedDepartment { Name = "Test SpecializedDepartment" };
            _context.SpecializedDepartments.Add(specializedDepartment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllSpecializedDepartment();

            // Assert
            Assert.Contains(specializedDepartment, result);

            // Clean up
            _context.SpecializedDepartments.Remove(specializedDepartment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetSpecializedDepartmentById_ReturnsSpecializedDepartment_WhenSpecializedDepartmentExists()
        {
            // Arrange
            var specializedDepartment = new SpecializedDepartment { Name = "Test SpecializedDepartment" };
            _context.SpecializedDepartments.Add(specializedDepartment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetSpecializedDepartmentById(specializedDepartment.Id);

            // Assert
            Assert.Equal(specializedDepartment, result);

            // Clean up
            _context.SpecializedDepartments.Remove(specializedDepartment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateSpecializedDepartment_ReturnsTrue_WhenSpecializedDepartmentExists()
        {
            // Arrange
            var specializedDepartment = new SpecializedDepartment { Name = "Test SpecializedDepartment" };
            _context.SpecializedDepartments.Add(specializedDepartment);
            await _context.SaveChangesAsync();

            specializedDepartment.Name = "Updated SpecializedDepartment";

            // Act
            var result = await _repository.UpdateSpecializedDepartment(specializedDepartment);

            // Assert
            Assert.True(result);

            // Clean up
            _context.SpecializedDepartments.Remove(specializedDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
