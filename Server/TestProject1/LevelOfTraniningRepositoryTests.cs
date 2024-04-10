using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class LevelOfTrainningRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly LevelOfTrainningRepository _repository;

        public LevelOfTrainningRepositoryTests()
        {;

            _context = new MldDatabaseContext();
            _repository = new LevelOfTrainningRepository(_context);
        }

        [Fact]
        public async Task AddLevelOfTrainning_ReturnsNewLevelOfTrainning()
        {
            // Arrange
            var levelOfTrainning = new LevelOfTrainning
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddLevelOfTrainning(levelOfTrainning);

            // Assert
            Assert.Equal(levelOfTrainning, result);

            // Clean up
            _context.LevelOfTrainnings.Remove(levelOfTrainning);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteLevelOfTrainning_ReturnsTrue_WhenLevelOfTrainningExists()
        {
            // Arrange
            var levelOfTrainning = new LevelOfTrainning { Name = "Test LevelOfTrainning" };
            _context.LevelOfTrainnings.Add(levelOfTrainning);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteLevelOfTrainning(levelOfTrainning.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllLevelOfTrainnings_ReturnsAllLevelOfTrainnings_WhenCalled()
        {
            // Arrange
            var levelOfTrainning = new LevelOfTrainning { Name = "Test LevelOfTrainning" };
            _context.LevelOfTrainnings.Add(levelOfTrainning);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllLevelOfTrainnings();

            // Assert
            Assert.Contains(levelOfTrainning, result);

            // Clean up
            _context.LevelOfTrainnings.Remove(levelOfTrainning);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetLevelOfTrainningById_ReturnsLevelOfTrainning_WhenLevelOfTrainningExists()
        {
            // Arrange
            var levelOfTrainning = new LevelOfTrainning { Name = "Test LevelOfTrainning" };
            _context.LevelOfTrainnings.Add(levelOfTrainning);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetLevelOfTrainningById(levelOfTrainning.Id);

            // Assert
            Assert.Equal(levelOfTrainning, result);

            // Clean up
            _context.LevelOfTrainnings.Remove(levelOfTrainning);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateLevelOfTrainning_ReturnsTrue_WhenLevelOfTrainningExists()
        {
            // Arrange
            var levelOfTrainning = new LevelOfTrainning { Name = "Test LevelOfTrainning" };
            _context.LevelOfTrainnings.Add(levelOfTrainning);
            await _context.SaveChangesAsync();

            levelOfTrainning.Name = "Updated LevelOfTrainning";

            // Act
            var result = await _repository.UpdateLevelOfTrainning(levelOfTrainning);

            // Assert
            Assert.True(result);

            // Clean up
            _context.LevelOfTrainnings.Remove(levelOfTrainning);
            await _context.SaveChangesAsync();
        }
    }
}
