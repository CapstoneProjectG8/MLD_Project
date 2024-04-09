using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace Project_MLD.Tests
{
    public class ClassRepositoryTests
    {
        private MldDatabaseContext _context;
        private ClassRepository _repo;

        public ClassRepositoryTests()
        {
           

            _context = new MldDatabaseContext();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _repo = new ClassRepository(_context);
        }

        [Fact]
        public async Task GetAllClasses_ShouldReturnAllClasses()
        {
            // Arrange
            var class1 = new Class {Name = "TestClass1" };
            var class2 = new Class { Name = "TestClass2" };
            _context.Classes.AddRange(class1, class2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllClasss();

            // Assert
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
            var result = await _repo.GetClassById(1);

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
            Assert.Equal("UpdatedUser", _context.Classes.Find(1).Name);
        }

        [Fact]
        public async Task DeleteClass_ShouldDeleteClass()
        {
            // Arrange
            var class1 = new Class {  Name = "TestUser" };
            _context.Classes.Add(class1);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.DeleteClass(1);

            // Assert
            Assert.True(result);
            Assert.Null(await _repo.GetClassById(1));
        }
    }
}
