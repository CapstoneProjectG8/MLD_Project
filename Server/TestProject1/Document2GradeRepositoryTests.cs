//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TestProject1
//{
//    public class Document2GradeRepositoryTests : IDisposable
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly Document2GradeRepository _repository;

//        public Document2GradeRepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("YourConnectionStringHere") // replace with your test database connection string
//                .Options;

//            _context = new MldDatabaseContext(options);
//            _repository = new Document2GradeRepository(_context);
//        }

//        public void Dispose()
//        {
//            // Clean up the database here
//            _context.Document2Grades.RemoveRange(_context.Document2Grades);
//            _context.SaveChanges();
//        }

//        [Fact]
//        public async Task GetAllDocument2GradesTest()
//        {
//            var document2Grades = await _repository.GetAllDocuemnt2Grades();

//            Assert.NotNull(document2Grades);
//            Assert.NotEmpty(document2Grades);
//        }
//        [Fact]
//        public async Task GetDocument2GradeByDocument2IdTest()
//        {
//            // Arrange
//            var document2Grade = new Document2Grade
//            {
//                Document2Id = 1, // replace with actual Document2Id
//                GradeId = 1, // replace with actual GradeId
//                TitleName = "Test Title",
//                Description = "Test Description",
//                Slot = 1,
//                Time = DateOnly.,
//                Place = "Test Place",
//                HostBy = "Test Host",
//                CollaborateWith = "Test Collaborator",
//                Condition = "Test Condition"
//            };

//            // You might need to add this document2Grade to your context and save changes
//            _context.Document2Grades.Add(document2Grade);
//            await _context.SaveChangesAsync();

//            // Act
//            var addedDocument2Grade = await _repository.GetDocument2GradeByDocument2Id(document2Grade.Document2Id);
//            var result = await _repository.GetDocument2GradeByDocument2Id(addedDocument2Grade.Document2Id);

//            // Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task UpdateDocument2GradeTest()
//        {
//            var document2Grade = new Document2Grade { /* initialize properties here */ };
//            var addedDocument2Grade = await _repository.UpdateDocument2Grade(document2Grade.Document2Id);

//            // Update properties of addedDocument2Grade here
//            var result = await _repository.UpdateDocument2Grade(addedDocument2Grade);

//            Assert.True(result);
//        }

//        // ... other tests ...
//    }
//}
