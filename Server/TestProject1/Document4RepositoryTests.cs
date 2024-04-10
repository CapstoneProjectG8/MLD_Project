using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Document4RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document4Repository _repository;

        public Document4RepositoryTests()
        {

            _context = new MldDatabaseContext();
            _repository = new Document4Repository(_context);
        }

        [Fact]
        public async Task AddDocument4_ReturnsNewDocument4()
        {
            // Arrange
            var document4 = new Document4
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddDocument4(document4);

            // Assert
            Assert.Equal(document4, result);

            // Clean up
            _context.Document4s.Remove(document4);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetDocument4sByCondition_ReturnsDocument4s_WhenConditionIsMet()
        {
            // Arrange
            var document4 = new Document4 { Name = "Test Document4" };
            _context.Document4s.Add(document4);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetDocument4sByCondition("Test");

            // Assert
            Assert.Contains(document4, result);

            // Clean up
            _context.Document4s.Remove(document4);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateDocument4_ReturnsTrue_WhenDocument4Exists()
        {
            // Arrange
            var document4 = new Document4 { Name = "Test Document4" };
            _context.Document4s.Add(document4);
            await _context.SaveChangesAsync();

            document4.Name = "Updated Document4";

            // Act
            var result = await _repository.UpdateDocument4(document4);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Document4s.Remove(document4);
            await _context.SaveChangesAsync();
        }
    }
}