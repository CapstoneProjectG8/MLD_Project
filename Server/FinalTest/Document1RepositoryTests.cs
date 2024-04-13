using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class Document1RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document1Repository _repository;

        public Document1RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new Document1Repository(_context);
        }

        public async Task InitializeDatabase()
        {
            // Clean up the database here
            _context.Document1s.RemoveRange(_context.Document1s);
            await _context.SaveChangesAsync();
        }


        [Fact]
        public async Task AddDocument1Test()
        {
            await InitializeDatabase();
            var document1 = new Document1 { Name = "Test" };
            var result = await _repository.AddDocument1(document1);

            Assert.NotNull(result);
            // Assert other properties here
        }

        [Fact]
        public async Task DeleteDocument1Test()
        {
            var document1 = new Document1 { Name = "Test" };
            var addedDocument1 = await _repository.AddDocument1(document1);

            var result = await _repository.DeleteDocument1(addedDocument1.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocument1s_ReturnsAllDocument1s_StableDatabase()
        {
            // Arrange
            await InitializeDatabase();
            var document1 = new Document1 { Name = "Test Doc1" };
            var document2 = new Document1 { Name = "Test Doc2" };

            // Add documents to the stable database
            await _repository.AddDocument1(document1);
            await _context.SaveChangesAsync();

            await _repository.AddDocument1(document2);
            await _context.SaveChangesAsync();

            // Assert data persistence
            var allDocsInContext = _context.Document1s.ToList();
            Assert.Equal(2, allDocsInContext.Count);
            Assert.Contains(allDocsInContext, d => d.Name == "Test Doc1");
            Assert.Contains(allDocsInContext, d => d.Name == "Test Doc2");

            // Act
            var result = await _repository.GetAllDocument1s();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, d => d.Name == "Test Doc1");
            Assert.Contains(result, d => d.Name == "Test Doc2");
        }



        [Fact]
        public async Task GetDocument1ByIdTest()
        {   

            var document1 = new Document1 { Name = "Test" };
            var addedDocument1 = await _repository.AddDocument1(document1);

            var result = await _repository.GetDocument1ById(addedDocument1.Id);

            Assert.NotNull(result);
            // Assert other properties here
        }

        [Fact]
        public async Task UpdateDocument1Test()
        {
            await InitializeDatabase();
            var document1 = new Document1 { Name = "Test" };
            var addedDocument1 = await _repository.AddDocument1(document1);

            // Update properties of addedDocument1 here
            var result = await _repository.UpdateDocument1(addedDocument1);

            Assert.True(result);
        }

        // ... other tests ...
    }
}
