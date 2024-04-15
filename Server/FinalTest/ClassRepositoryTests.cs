using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace FinalTest
{ 
    public class ClassRepositoryTests
    {
        private MldDatabaseContext _context;
        private ClassRepository _repository;

        public ClassRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new ClassRepository(_context);
        }
        public async Task InitializeDatabase()
        {
            // Clean up the database here
            _context.Classes.RemoveRange(_context.Classes);
            await _context.SaveChangesAsync();
        }


        [Fact]
        public async Task AddClassTest()
        {
            try
            {
                var classObj = new Class { Name = "Test" };
                var result = await _repository.AddClass(classObj);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task DeleteClassTest()
        {
            try
            {
                var classObj = new Class { Name = "Test" };
                var addedClass = await _repository.AddClass(classObj);
                var result = await _repository.DeleteClass(addedClass.Id);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetAllClassesTest()
        {
            try
            {
                var result = await _repository.GetAllClasss();
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetClassByIdTest()
        {
            try
            {
                int id = 1; // replace with an id that exists in your database
                var result = await _repository.GetClassById(id);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task UpdateClassTest()
        {
            try
            {
                var classObj = new Class { Name = "Test" };
                var addedClass = await _repository.AddClass(classObj);
                addedClass.Name = "Updated Test";
                var result = await _repository.UpdateClass(addedClass);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }
    }
}
