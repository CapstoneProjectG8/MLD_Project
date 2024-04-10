using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace TestProject1
{
    public class Document2RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document2Repository _repository;

        public Document2RepositoryTests()
        {
            _context = new MldDatabaseContext();
            _repository = new Document2Repository(_context);
        }

        [Fact]
        public async Task AddDocument2_ReturnsNewDocument2()
        {
            // Arrange
            var document2 = new Document2
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddDocument2(document2);

            // Assert
            Assert.Equal(document2, result);
        }

        [Fact]
        public async Task DeleteDocument2_ReturnsTrue_WhenDocument2Exists()
        {
            // Arrange
            var document2 = new Document2 { Name = "Test Document2" };
            _context.Document2s.Add(document2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteDocument2(document2.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocument2s_ReturnsAllDocument2s_WhenCalled()
        {
            // Arrange
            var document2 = new Document2 { Name = "Test Document2" };
            _context.Document2s.Add(document2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllDocument2s();

            // Assert
            Assert.Contains(document2, result);
        }

        [Fact]
        public async Task GetDocument2ById_ReturnsDocument2_WhenDocument2Exists()
        {
            // Arrange
            var document2 = new Document2 { Name = "Test Document2" };
            _context.Document2s.Add(document2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetDocument2ById(document2.Id);

            // Assert
            Assert.Equal(document2, result);
        }

    }
}
