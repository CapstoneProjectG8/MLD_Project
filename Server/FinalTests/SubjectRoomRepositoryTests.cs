//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FinalTest
//{
//    public class SubjectRoomRepositoryTests
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly SubjectRoomRepository _repository;

//        public SubjectRoomRepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                .Options;
//            _context = new MldDatabaseContext(options);
//            _repository = new SubjectRoomRepository(_context);
//        }

//        [Fact]
//        public async Task AddSubjectRoom_ReturnsNewSubjectRoom()
//        {
//            // Arrange
//            var subjectRoom = new SubjectRoom
//            {
//                // Initialize properties here
//            };

//            // Act
//            var result = await _repository.AddSubjectRoom(subjectRoom);

//            // Assert
//            Assert.Equal(subjectRoom, result);

//            // Clean up
//            _context.SubjectRooms.Remove(subjectRoom);
//            await _context.SaveChangesAsync();
//        }

//        [Fact]
//        public async Task DeleteSubjectRoom_ReturnsTrue_WhenSubjectRoomExists()
//        {
//            // Arrange
//            var subjectRoom = new SubjectRoom { Name = "Test SubjectRoom" };
//            _context.SubjectRooms.Add(subjectRoom);
//            await _context.SaveChangesAsync();

//            // Act
//            var result = await _repository.DeleteSubjectRoom(subjectRoom.Id);

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public async Task GetAllSubjectRooms_ReturnsAllSubjectRooms_WhenCalled()
//        {
//            // Arrange
//            var subjectRoom = new SubjectRoom { Name = "Test SubjectRoom" };
//            _context.SubjectRooms.Add(subjectRoom);
//            await _context.SaveChangesAsync();

//            // Act
//            var result = await _repository.GetAllSubjectRooms();

//            // Assert
//            Assert.Contains(subjectRoom, result);

//            // Clean up
//            _context.SubjectRooms.Remove(subjectRoom);
//            await _context.SaveChangesAsync();
//        }

//        [Fact]
//        public async Task GetSubjectRoomById_ReturnsSubjectRoom_WhenSubjectRoomExists()
//        {
//            // Arrange
//            var subjectRoom = new SubjectRoom { Name = "Test SubjectRoom" };
//            _context.SubjectRooms.Add(subjectRoom);
//            await _context.SaveChangesAsync();

//            // Act
//            var result = await _repository.GetSubjectRoomById(subjectRoom.Id);

//            // Assert
//            Assert.Equal(subjectRoom, result);

//            // Clean up
//            _context.SubjectRooms.Remove(subjectRoom);
//            await _context.SaveChangesAsync();
//        }

//        [Fact]
//        public async Task UpdateSubjectRoom_ReturnsTrue_WhenSubjectRoomExists()
//        {
//            // Arrange
//            var subjectRoom = new SubjectRoom { Name = "Test SubjectRoom" };
//            _context.SubjectRooms.Add(subjectRoom);
//            await _context.SaveChangesAsync();

//            subjectRoom.Name = "Updated SubjectRoom";

//            // Act
//            var result = await _repository.UpdateSubjectRoom(subjectRoom);

//            // Assert
//            Assert.True(result);

//            // Clean up
//            _context.SubjectRooms.Remove(subjectRoom);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
