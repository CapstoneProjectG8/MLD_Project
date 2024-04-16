using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest
{
    public class TeachingEquipmentRepositoryTests
    {
        private readonly MldDatabaseContext _context;
        private readonly TeachingEquipmentRepository _repository;

        public TeachingEquipmentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;
            _context = new MldDatabaseContext(options);
            _repository = new TeachingEquipmentRepository(_context);
        }

        [Fact]
        public async Task AddTeachingEquipment_ReturnsNewTeachingEquipment()
        {
            // Arrange
            var teachingEquipment = new TeachingEquipment
            {
                // Initialize properties here
            };

            // Act
            var result = await _repository.AddTeachingEquipment(teachingEquipment);

            // Assert
            Assert.Equal(teachingEquipment, result);

            // Clean up
            _context.TeachingEquipments.Remove(teachingEquipment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteTeachingEquipment_ReturnsTrue_WhenTeachingEquipmentExists()
        {
            // Arrange
            var teachingEquipment = new TeachingEquipment { Name = "Test TeachingEquipment" };
            _context.TeachingEquipments.Add(teachingEquipment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteTeachingEquipment(teachingEquipment.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllTeachingEquipments_ReturnsAllTeachingEquipments_WhenCalled()
        {
            // Arrange
            var teachingEquipment = new TeachingEquipment { Name = "Test TeachingEquipment" };
            _context.TeachingEquipments.Add(teachingEquipment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllTeachingEquipments();

            // Assert
            Assert.Contains(teachingEquipment, result);

            // Clean up
            _context.TeachingEquipments.Remove(teachingEquipment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetTeachingEquipmentById_ReturnsTeachingEquipment_WhenTeachingEquipmentExists()
        {
            // Arrange
            var teachingEquipment = new TeachingEquipment { Name = "Test TeachingEquipment" };
            _context.TeachingEquipments.Add(teachingEquipment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetTeachingEquipmentById(teachingEquipment.Id);

            // Assert
            Assert.Equal(teachingEquipment, result);

            // Clean up
            _context.TeachingEquipments.Remove(teachingEquipment);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task UpdateTeachingEquipment_ReturnsTrue_WhenTeachingEquipmentExists()
        {
            // Arrange
            var teachingEquipment = new TeachingEquipment { Name = "Test TeachingEquipment" };
            _context.TeachingEquipments.Add(teachingEquipment);
            await _context.SaveChangesAsync();

            teachingEquipment.Name = "Updated TeachingEquipment";

            // Act
            var result = await _repository.UpdateTeachingEquipment(teachingEquipment);

            // Assert
            Assert.True(result);

            // Clean up
            _context.TeachingEquipments.Remove(teachingEquipment);
            await _context.SaveChangesAsync();
        }
    }
}
