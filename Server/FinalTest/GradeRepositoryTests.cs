using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class GradeRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly GradeRepository _repository;

        public GradeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new GradeRepository(_context);
        }

        [Fact]
        public async Task AddGrade_ReturnsNewGrade()
        {
            // Arrange
            var grade = new Grade
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddGrade(grade);

            // Assert
            Assert.Equal(grade, result);

            // Clean up
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteGrade_ReturnsTrue_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteGrade(grade.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllGrades_ReturnsAllGrades_WhenCalled()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllGrades();

            // Assert
            Assert.Contains(grade, result);

            // Clean up
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetGradeById_ReturnsGrade_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetGradeById(grade.Id);

            // Assert
            Assert.Equal(grade, result);

            // Clean up
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateGrade_ReturnsTrue_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            grade.Name = "Updated Grade";

            // Act
            var result = await _repository.UpdateGrade(grade);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}
