using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ProfessionalStandardRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly ProfessionalStandardRepository _repository;

        public ProfessionalStandardRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new ProfessionalStandardRepository(_context);
        }

        [Fact]
        public async Task AddProfessionalStandard_ReturnsNewProfessionalStandard()
        {
            // Arrange
            var professionalStandard = new ProfessionalStandard
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddProfessionalStandard(professionalStandard);

            // Assert
            Assert.Equal(professionalStandard, result);

            // Clean up
            _context.ProfessionalStandards.Remove(professionalStandard);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteProfessionalStandard_ReturnsTrue_WhenProfessionalStandardExists()
        {
            // Arrange
            var professionalStandard = new ProfessionalStandard { Name = "Test ProfessionalStandard" };
            _context.ProfessionalStandards.Add(professionalStandard);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteProfessionalStandard(professionalStandard.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllProfessionalStandards_ReturnsAllProfessionalStandards_WhenCalled()
        {
            // Arrange
            var professionalStandard = new ProfessionalStandard { Name = "Test ProfessionalStandard" };
            _context.ProfessionalStandards.Add(professionalStandard);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllProfessionalStandard();

            // Assert
            Assert.Contains(professionalStandard, result);

            // Clean up
            _context.ProfessionalStandards.Remove(professionalStandard);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetProfessionalStandardById_ReturnsProfessionalStandard_WhenProfessionalStandardExists()
        {
            // Arrange
            var professionalStandard = new ProfessionalStandard { Name = "Test ProfessionalStandard" };
            _context.ProfessionalStandards.Add(professionalStandard);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetProfessionalStandardById(professionalStandard.Id);

            // Assert
            Assert.Equal(professionalStandard, result);

            // Clean up
            _context.ProfessionalStandards.Remove(professionalStandard);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateProfessionalStandard_ReturnsTrue_WhenProfessionalStandardExists()
        {
            // Arrange
            var professionalStandard = new ProfessionalStandard { Name = "Test ProfessionalStandard" };
            _context.ProfessionalStandards.Add(professionalStandard);
            await _context.SaveChangesAsync();

            professionalStandard.Name = "Updated ProfessionalStandard";

            // Act
            var result = await _repository.UpdateProfessionalStandard(professionalStandard);

            // Assert
            Assert.True(result);

            // Clean up
            _context.ProfessionalStandards.Remove(professionalStandard);
            await _context.SaveChangesAsync();
        }
    }
}
