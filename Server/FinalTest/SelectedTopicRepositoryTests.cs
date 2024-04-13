using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class SelectedTopicRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly SelectedTopicRepository _repository;

        public SelectedTopicRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new SelectedTopicRepository(_context);
        }

        [Fact]
        public async Task AddSelectedTopic_ReturnsNewSelectedTopic()
        {
            // Arrange
            var selectedTopic = new SelectedTopic
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddSelectedTopic(selectedTopic);

            // Assert
            Assert.Equal(selectedTopic, result);

            // Clean up
            _context.SelectedTopics.Remove(selectedTopic);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteSelectedTopic_ReturnsTrue_WhenSelectedTopicExists()
        {
            // Arrange
            var selectedTopic = new SelectedTopic { Name = "Test SelectedTopic" };
            _context.SelectedTopics.Add(selectedTopic);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteSelectedTopic(selectedTopic.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllSelectedTopics_ReturnsAllSelectedTopics_WhenCalled()
        {
            // Arrange
            var selectedTopic = new SelectedTopic { Name = "Test SelectedTopic" };
            _context.SelectedTopics.Add(selectedTopic);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllSelectedTopics();

            // Assert
            Assert.Contains(selectedTopic, result);

            // Clean up
            _context.SelectedTopics.Remove(selectedTopic);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetSelectedTopicById_ReturnsSelectedTopic_WhenSelectedTopicExists()
        {
            // Arrange
            var selectedTopic = new SelectedTopic { Name = "Test SelectedTopic" };
            _context.SelectedTopics.Add(selectedTopic);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetSelectedTopicById(selectedTopic.Id);

            // Assert
            Assert.Equal(selectedTopic, result);

            // Clean up
            _context.SelectedTopics.Remove(selectedTopic);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateSelectedTopic_ReturnsTrue_WhenSelectedTopicExists()
        {
            // Arrange
            var selectedTopic = new SelectedTopic { Name = "Test SelectedTopic" };
            _context.SelectedTopics.Add(selectedTopic);
            await _context.SaveChangesAsync();

            selectedTopic.Name = "Updated SelectedTopic";

            // Act
            var result = await _repository.UpdateSelectedTopic(selectedTopic);

            // Assert
            Assert.True(result);

            // Clean up
            _context.SelectedTopics.Remove(selectedTopic);
            await _context.SaveChangesAsync();
        }
    }
}
