using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CurriculumDistributionRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly CurriculumDistributionRepository _repository;

        public CurriculumDistributionRepositoryTests()
        {
            _context = new MldDatabaseContext();
            _repository = new CurriculumDistributionRepository(_context);
        }

        [Fact]
        public async Task AddCurriculumDistribution_ReturnsNewCurriculumDistribution()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Assert
            Assert.Equal(curriculumDistribution, result);
        }
        [Fact]
        public async Task DeleteCurriculumDistribution_ReturnsTrueWhenExists()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution
            {
                // Initialize properties here
            };
            var added = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Act
            var result = await _repository.DeleteCurriculumDistribution(added.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllCurriculumDistributions_ReturnsAllCurriculumDistributions()
        {
            // Arrange
            var curriculumDistribution1 = new CurriculumDistribution
            {
                // Initialize properties here
            };
            var curriculumDistribution2 = new CurriculumDistribution
            {
                // Initialize properties here
            };
            await _repository.AddCurriculumDistribution(curriculumDistribution1);
            await _repository.AddCurriculumDistribution(curriculumDistribution2);

            // Act
            var result = await _repository.GetAllCurriculumDistributions();

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async Task GetCurriculumDistributionById_ReturnsCurriculumDistributionWhenExists()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution
            {
                // Initialize properties here
            };
            var added = await _repository.AddCurriculumDistribution(curriculumDistribution);

            // Act
            var result = await _repository.GetCurriculumDistributionById(added.Id);

            // Assert
            Assert.Equal(curriculumDistribution, result);
        }

        [Fact]
        public async Task UpdateCurriculumDistribution_ReturnsTrueWhenExists()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution
            {
                // Initialize properties here
            };
            var added = await _repository.AddCurriculumDistribution(curriculumDistribution);
            added.Name = "New Value";  // Change some property

            // Act
            var result = await _repository.UpdateCurriculumDistribution(added);

            // Assert
            Assert.True(result);
        }
    }
}