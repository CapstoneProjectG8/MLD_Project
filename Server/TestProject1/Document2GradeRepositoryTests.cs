using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MLD.Tests
{
    public class Document2GradeRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly Document2GradeRepository _repo;

        public Document2GradeRepositoryTests()
        {
           

            _context = new MldDatabaseContext();
            _repo = new Document2GradeRepository(_context);
        }

        [Fact]
        public async Task AddDocument2Grade_ShouldReturnDocument2Grade_WhenDocument2GradeIsAdded()
        {
            //// Arrange
            //var document2Grade = new Document2Grade();

            //// Act
            //var result = await _repo.AddDocument2Grade(document2Grade);

            //// Assert
            //Assert.Equal(document2Grade, result);

            //// Clean up
            //_context.Document2Grades.Remove(document2Grade);
            //await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteDocument2Grade_ShouldReturnTrue_WhenDocument2GradeExists()
        {
            //// Arrange
            //var document2Grade = new Document2Grade ();
            //_context.Document2Grades.Add(document2Grade);
            //await _context.SaveChangesAsync();

            //// Act
            //var result = await _repo.DeleteDocument2Grade(document2Grade.Document2Id);

            //// Assert
            //Assert.True(result);
        }

        [Fact]
        public async Task GetAllDocument2Grades_ShouldReturnAllDocument2Grades_WhenCalled()
        {
            // Arrange
            var document2Grade = new Document2Grade { Document2Id = 1 };
            _context.Document2Grades.Add(document2Grade);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllDocuemnt2Grades();

            // Assert
            Assert.Contains(document2Grade, result);

            // Clean up
            _context.Document2Grades.Remove(document2Grade);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetDocument2GradeById_ShouldReturnDocument2Grade_WhenDocument2GradeExists()
        {
            //// Arrange
            //var document2Grade = new Document2Grade ();
            //_context.Document2Grades.Add(document2Grade);
            //await _context.SaveChangesAsync();

            //// Act
            //var result = await _repo.GetDocument2GradeById(document2Grade.Document2Id);

            //// Assert
            //Assert.Equal(document2Grade, result);

            //// Clean up
            //_context.Document2Grades.Remove(document2Grade);
            //await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateDocument2Grade_ShouldReturnTrue_WhenDocument2GradeExists()
        {
            //// Arrange
            //var document2Grade = new Document2Grade ();
            //_context.Document2Grades.Add(document2Grade);
            //await _context.SaveChangesAsync();

           

            //// Act
            //var result = await _repo.UpdateDocument2Grade(document2Grade);

            //// Assert
            //Assert.True(result);

            //// Clean up
            //_context.Document2Grades.Remove(document2Grade);
            //await _context.SaveChangesAsync();
        }
    }
}
