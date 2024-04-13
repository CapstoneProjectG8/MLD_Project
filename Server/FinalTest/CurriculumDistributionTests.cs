using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;

namespace FinalTest
{
    public class CurriculumDistributionRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly CurriculumDistributionRepository _repository;

        public CurriculumDistributionRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new CurriculumDistributionRepository(_context);
        }

        public async Task InitializeDatabase()
        {
            // Clean up the database here
            _context.CurriculumDistributions.RemoveRange(_context.CurriculumDistributions);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task AddCurriculumDistribution_ReturnsNewCurriculumDistribution()
        {
            // Arrange
            await InitializeDatabase();
            var curriculumDistribution = new CurriculumDistribution
            {
                Name = "Test Add Curriculum Distribution1",
            };

            // Act
            var result = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Assert
            Assert.Equal(curriculumDistribution, result);
            await _repository.DeleteCurriculumDistribution(curriculumDistribution.Id);
            await _context.SaveChangesAsync();

        }

        [Fact]
        public async Task DeleteCurriculumDistribution_ReturnsTrueWhenExists()
        {
            // Arrange
            await InitializeDatabase();
            var curriculumDistribution = new CurriculumDistribution
            {
                Name = "Test Curriculum Distribution",
            };
            var added = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Act
            var result = await _repository.DeleteCurriculumDistribution(added.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllCurriculumDistributions_ReturnsAllCurriculumDistributions_StableDatabase()
        {
            // Arrange
            await InitializeDatabase();
            var curriculumDistribution1 = new CurriculumDistribution
            {
                Name = "Test Curriculum Distribution1",
            };
            var curriculumDistribution2 = new CurriculumDistribution
            {
                Name = "Test Curriculum Distribution2",
            };

            // Add curriculum distributions to the stable database
            await _repository.AddCurriculumDistribution(curriculumDistribution1);
            await _context.SaveChangesAsync();

            await _repository.AddCurriculumDistribution(curriculumDistribution2);
            await _context.SaveChangesAsync();

            try
            {
                // Act
                var result = await _repository.GetAllCurriculumDistributions();

                // Assert
                Assert.Equal(2, result.Count()); // Assuming there are only two added distributions
            }
            finally
            {
                // Clean up: Delete curriculumDistribution1 and curriculumDistribution2
                await _repository.DeleteCurriculumDistribution(curriculumDistribution1.Id);
                await _context.SaveChangesAsync();

                await _repository.DeleteCurriculumDistribution(curriculumDistribution2.Id);
                await _context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task GetCurriculumDistributionById_ReturnsCurriculumDistributionWhenExists()
        {
            // Arrange
            await InitializeDatabase();
            var curriculumDistribution = new CurriculumDistribution
            {
                Name = "Test Curriculum Distribution",
            };
            var added = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Act
            var result = await _repository.GetCurriculumDistributionById(added.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(added.Id, result.Id);
        }
    }
}
