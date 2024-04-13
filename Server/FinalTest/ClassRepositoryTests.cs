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
        private ClassRepository _repo;

        public ClassRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repo = new ClassRepository(_context);
        }
        public async Task InitializeDatabase()
        {
            // Clean up the database here
            _context.Classes.RemoveRange(_context.Classes);
            await _context.SaveChangesAsync();
        }


        [Fact]
        public async Task GetAllClasses_ShouldReturnAllClasses()
        {
            // Arrange
            await InitializeDatabase();
            var class1 = new Class { Name = "TestUser1" };
            var class2 = new Class { Name = "TestUser2" };
            _context.Classes.AddRange(class1, class2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllClasss();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }


        [Fact]
        public async Task GetClassById_ShouldReturnClass()
        {
            // Arrange
            var class1 = new Class { Name = "TestUser" };
            _context.Classes.Add(class1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetClassById(class1.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(class1.Name, result.Name);
        }

        [Fact]
        public async Task AddClass_ShouldAddClass()
        {
            // Arrange
            var class1 = new Class {Name = "TestUser" };

            // Act
            var result = await _repo.AddClass(class1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(class1.Name, result.Name);
        }

        [Fact]
        public async Task UpdateClass_ShouldUpdateClass()
        {
            // Arrange
            var class1 = new Class {  Name = "TestUser" };
            _context.Classes.Add(class1);
            await _context.SaveChangesAsync();

            class1. Name = "UpdatedUser";

            // Act
            var result = await _repo.UpdateClass(class1);

            // Assert
            Assert.True(result);
            Assert.Equal("UpdatedUser", _context.Classes.Find(class1.Id).Name);
            
        }

        [Fact]
        public async Task DeleteClass_ShouldDeleteClass()
        {
            // Arrange
            var class1 = new Class {  Name = "TestUser" };
            _context.Classes.Add(class1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.DeleteClass(class1.Id);

            // Assert
            Assert.True(result);
            Assert.Null(await _repo.GetClassById(class1.Id));
        }
    }
}
