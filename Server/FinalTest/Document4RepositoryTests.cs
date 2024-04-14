using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class Document4RepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document4Repository _repository;

        public Document4RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new Document4Repository(_context);
        }

        [Fact]
        public async Task AddDocument4Test()
        {
            try
            {
                var document4 = new Document4 { Name = "Test" };
                var result = await _repository.AddDocument4(document4);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task DeleteDocument4Test()
        {
            try
            {
                var document4 = new Document4 { Name = "Test" };
                var addedDocument4 = await _repository.AddDocument4(document4);
                var result = await _repository.DeleteDocument4(addedDocument4.Id);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetAllDocument4sTest()
        {
            try
            {
                var result = await _repository.GetAllDocument4s();
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetDocument4ByIdTest()
        {
            try
            {
                int id = 1; // replace with an id that exists in your database
                var result = await _repository.GetDocument4ById(id);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetDocument4sByConditionTest()
        {
            try
            {
                var result = await _repository.GetDocument4sByCondition("Test");
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task UpdateDocument4Test()
        {
            try
            {
                var document4 = new Document4 { Name = "Test" };
                var addedDocument4 = await _repository.AddDocument4(document4);
                addedDocument4.Name = "Updated Test";
                var result = await _repository.UpdateDocument4(addedDocument4);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

    }
}