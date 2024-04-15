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

<<<<<<< HEAD
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
=======
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
>>>>>>> 5bbb1ea1cec9a404b7a2890cee7b60abae09cdba

//            // Update properties of addedDocument2Grade here
//            var result = await _repository.UpdateDocument2Grade(addedDocument2Grade);

//            Assert.True(result);
//        }

<<<<<<< HEAD
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
=======
//        // ... other tests ...
//    }
//}
>>>>>>> 5bbb1ea1cec9a404b7a2890cee7b60abae09cdba
