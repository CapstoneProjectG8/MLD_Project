using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Document5RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document5Repository _repository;

        public Document5RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new Document5Repository(_context);
        }

        [Fact]
        public async Task AddDocument5_ReturnsNewDocument5()
        {
            // Arrange
            var document5 = new Document5
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddDocument5(document5);

            // Assert
            Assert.Equal(document5, result);

            // Clean up
            _context.Document5s.Remove(document5);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteDocument5_ReturnsTrue_WhenDocument5Exists()
        {
            // Arrange
            var document5 = new Document5 { Name = "Test Document5" };
            _context.Document5s.Add(document5);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteDocument5(document5.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocument5s_ReturnsAllDocument5s_WhenCalled()
        {
            // Arrange
            var document5 = new Document5 { Name = "Test Document5" };
            _context.Document5s.Add(document5);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllDocument5s();

            // Assert
            Assert.Contains(document5, result);

            // Clean up
            _context.Document5s.Remove(document5);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetDocument5ById_ReturnsDocument5_WhenDocument5Exists()
        {
            // Arrange
            var document5 = new Document5 { Name = "Test Document5" };
            _context.Document5s.Add(document5);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetDocument5ById(document5.Id);

            // Assert
            Assert.Equal(document5, result);

            // Clean up
            _context.Document5s.Remove(document5);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetDocument5sByCondition_ReturnsDocument5s_WhenConditionIsMet()
        {
            // Arrange
            var document5 = new Document5 { Name = "Test Document5" };
            _context.Document5s.Add(document5);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetDocument5sByCondition("Test");

            // Assert
            Assert.Contains(document5, result);

            // Clean up
            _context.Document5s.Remove(document5);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateDocument5_ReturnsTrue_WhenDocument5Exists()
        {
            // Arrange
            var document5 = new Document5 { Name = "Test Document5" };
            _context.Document5s.Add(document5);
            await _context.SaveChangesAsync();

            document5.Name = "Updated Document5";

            // Act
            var result = await _repository.UpdateDocument5(document5);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Document5s.Remove(document5);
            await _context.SaveChangesAsync();
        }

    }
}
