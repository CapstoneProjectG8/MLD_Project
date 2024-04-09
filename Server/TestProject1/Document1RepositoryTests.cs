using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MLD.Tests
{
    public class Document1RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document1Repository _repo;

        public Document1RepositoryTests()
        {
            _context = new MldDatabaseContext();
            _repo = new Document1Repository(_context);
        }

        [Fact]
        public async Task AddDocument1_ShouldReturnDocument1_WhenDocument1IsAdded()
        {
            // Arrange
            var document1 = new Document1 { Name = "Test Document1" };

            // Act
            var result = await _repo.AddDocument1(document1);

            // Assert
            Assert.Equal(document1, result);
        }

        [Fact]
        public async Task GetAllDocument1s_ShouldReturnAllDocument1s_WhenCalled()
        {
            // Arrange
            var document1 = new Document1 {Name = "Test Document1" };
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllDocument1s();

            // Assert
            Assert.Contains(document1, result);

            // Clean up
            _context.Document1s.Remove(document1);
            await _context.SaveChangesAsync();
        }


        [Fact]
        public async Task GetDocument1ById_ShouldReturnDocument1_WhenDocument1Exists()
        {
            // Arrange
            var document1 = new Document1 {  Name = "Test Document1" };
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetDocument1ById(document1.Id);

            // Assert
            Assert.Equal(document1, result);

            // Clean up
            _context.Document1s.Remove(document1);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateDocument1_ShouldReturnTrue_WhenDocument1Exists()
        {
            // Arrange
            var document1 = new Document1 { Name = "Test Document1" };
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();

            document1.Name = "Updated Document1";

            // Act
            var result = await _repo.UpdateDocument1(document1);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Document1s.Remove(document1);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteDocument1_ShouldReturnTrue_WhenDocument1Exists()
        {
            // Arrange
            var document1 = new Document1 {  Name = "Test Document1" };
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.DeleteDocument1(document1.Id);

            // Assert
            Assert.True(result);
        }

    }
}
