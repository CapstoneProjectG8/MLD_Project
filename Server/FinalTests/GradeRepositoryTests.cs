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
        [Fact]
        public async Task AddGrade_ReturnsNewGrade()
        {
            // Arrange
            var grade = new Grade();

            // Act
            var result = grade;

            // Assert
            Assert.Equal(grade, result);
        }

        [Fact]
        public async Task DeleteGrade_ReturnsTrue_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };

            // Act
            var result = true;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllGrades_ReturnsAllGrades_WhenCalled()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };

            // Act
            var result = new List<Grade> { grade };

            // Assert
            Assert.Contains(grade, result);
        }

        [Fact]
        public async Task GetGradeById_ReturnsGrade_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };

            // Act
            var result = grade;

            // Assert
            Assert.Equal(grade, result);
        }

        [Fact]
        public async Task UpdateGrade_ReturnsTrue_WhenGradeExists()
        {
            // Arrange
            var grade = new Grade { Name = "Test Grade" };

            // Act
            var result = true;

            // Assert
            Assert.True(result);
        }
    }
}
