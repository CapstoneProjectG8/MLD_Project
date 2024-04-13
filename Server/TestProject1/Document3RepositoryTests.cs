using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Document3RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document3Repository _repository;

        public Document3RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new Document3Repository(_context);
        }

        [Fact]
        public async Task AddDocument3_ReturnsNewDocument3()
        {
            // Arrange
            var document3 = new Document3
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddDocument3(document3);

            // Assert
            Assert.Equal(document3, result);
        }

        [Fact]
        public async Task DeleteDocument3_ReturnsTrue_WhenDocument3Exists()
        {
            // Arrange
            var document3 = new Document3 { Name = "Test Document3" };
            _context.Document3s.Add(document3);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteDocument3(document3.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocument3s_ReturnsAllDocument3s_WhenCalled()
        {
            // Arrange
            var document3 = new Document3 { Name = "Test Document3" };
            _context.Document3s.Add(document3);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllDocument3s();

            // Assert
            Assert.Contains(document3, result);
        }

        [Fact]
        public async Task GetDocument3ById_ReturnsDocument3_WhenDocument3Exists()
        {
            // Arrange
            var document3 = new Document3 { Name = "Test Document3" };
            _context.Document3s.Add(document3);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetDocument3ById(document3.Id);

            // Assert
            Assert.Equal(document3, result);
        }
    }
}
