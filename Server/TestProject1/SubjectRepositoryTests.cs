using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class SubjectRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly SubjectRepository _repository;

        public SubjectRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new SubjectRepository(_context);
        }

        [Fact]
        public async Task AddSubject_ReturnsNewSubject()
        {
            // Arrange
            var subject = new Subject
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddSubject(subject);

            // Assert
            Assert.Equal(subject, result);

            // Clean up
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteSubject_ReturnsTrue_WhenSubjectExists()
        {
            // Arrange
            var subject = new Subject { Name = "Test Subject" };
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteSubject(subject.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllSubjects_ReturnsAllSubjects_WhenCalled()
        {
            // Arrange
            var subject = new Subject { Name = "Test Subject" };
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllSubjects();

            // Assert
            Assert.Contains(subject, result);

            // Clean up
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetSubjectById_ReturnsSubject_WhenSubjectExists()
        {
            // Arrange
            var subject = new Subject { Name = "Test Subject" };
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetSubjectById(subject.Id);

            // Assert
            Assert.Equal(subject, result);

            // Clean up
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateSubject_ReturnsTrue_WhenSubjectExists()
        {
            // Arrange
            var subject = new Subject { Name = "Test Subject" };
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            subject.Name = "Updated Subject";

            // Act
            var result = await _repository.UpdateSubject(subject);

            // Assert
            Assert.True(result);

            // Clean up
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
