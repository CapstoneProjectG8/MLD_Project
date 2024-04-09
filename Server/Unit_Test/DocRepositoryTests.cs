using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace Project_MLD.Tests
{
    public class DocRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly DocRepository _repository;

        public DocRepositoryTests()
        {
         
            _context = new MldDatabaseContext();
            _repository = new DocRepository(_context);
        }
        [Fact]
        public async Task AddDoc_ReturnsNewDoc()
        {
            // Arrange
            var doc = new Doc
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddDoc(doc);

            // Assert
            Assert.Equal(doc, result);
        }

        [Fact]
        public async Task DeleteDoc_ReturnsTrueWhenExists()
        {
            // Arrange
            var doc = new Doc
            {
                // Initialize properties here
            };
            var added = await _repository.AddDoc(doc);

            // Act
            var result = await _repository.DeleteDoc(added.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocs_ReturnsAllDocs()
        {
            // Arrange
            var doc1 = new Doc
            {
                // Initialize properties here
            };
            var doc2 = new Doc
            {
                // Initialize properties here
            };
            await _repository.AddDoc(doc1);
            await _repository.AddDoc(doc2);

            // Act
            var result = await _repository.GetAllDocs();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetDocById_ReturnsDocWhenExists()
        {
            // Arrange
            var doc = new Doc
            {
                // Initialize properties here
            };
            var added = await _repository.AddDoc(doc);

            // Act
            var result = await _repository.GetDocById(added.Id);

            // Assert
            Assert.Equal(doc, result);
        }
    }
}
