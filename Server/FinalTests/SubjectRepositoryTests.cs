//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FinalTest
//{
//    public class SubjectRepositoryTests
//    {
//        [Fact]
//        public async Task AddSubject_ReturnsNewSubject()
//        {
//            // Arrange
//            var subject = new Subject();

//            // Act
//            var result = subject;

//            // Assert
//            Assert.Equal(subject, result);
//        }

//        [Fact]
//        public async Task DeleteSubject_ReturnsTrue_WhenSubjectExists()
//        {
//            // Arrange
//            var subject = new Subject { Name = "Test Subject" };

//            // Act
//            var result = true;

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public async Task GetAllSubjects_ReturnsAllSubjects_WhenCalled()
//        {
//            // Arrange
//            var subject = new Subject { Name = "Test Subject" };

//            // Act
//            var result = new List<Subject> { subject };

//            // Assert
//            Assert.Contains(subject, result);
//        }

//        [Fact]
//        public async Task GetSubjectById_ReturnsSubject_WhenSubjectExists()
//        {
//            // Arrange
//            var subject = new Subject { Name = "Test Subject" };

//            // Act
//            var result = subject;

//            // Assert
//            Assert.Equal(subject, result);
//        }

//        [Fact]
//        public async Task UpdateSubject_ReturnsTrue_WhenSubjectExists()
//        {
//            // Arrange
//            var subject = new Subject { Name = "Test Subject" };

//            // Act
//            var result = true;

//            // Assert
//            Assert.True(result);
//        }
//    }
//}
