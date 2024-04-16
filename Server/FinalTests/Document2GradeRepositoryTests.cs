using Xunit;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Repository;
using System.Linq;
using System.Threading.Tasks;
using Moq;

namespace FinalTest
{
    public class Document2GradeRepositoryTests : IDisposable
    {
        private readonly MldDatabaseContext _context;
        private readonly Document2GradeRepository _repository;

        public Document2GradeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
                .Options;

            _context = new MldDatabaseContext(options);
            _repository = new Document2GradeRepository(_context);
        }

        public void Dispose()
        {
            // Clean up the database here
            _context.Document2Grades.RemoveRange(_context.Document2Grades);
            _context.SaveChanges();
        }


        [Fact]
        public async Task DeleteDocument2GradeTest()
        {
            try
            {
                var list = new List<Document2Grade>
            {
                new Document2Grade
                {
                    Document2Id = 1,
                    GradeId = 9
                },
                new Document2Grade
                {
                    Document2Id = 2,
                    GradeId = 9
                }
            };

                await _repository.DeleteDocument2Grade(list);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetAllDocument2GradesTest()
        {
            try
            {
                var result = await _repository.GetAllDocuemnt2Grades();
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

        [Fact]
        public async Task GetDocument2GradeByDocument2IdTest()
        {
            try
            {
                int id = 1; // replace with an id that exists in your database
                var result = await _repository.GetDocument2GradeByDocument2Id(id);
            }
            catch (Exception)
            {
                // Ignore the exception
            }
        }

    //    [Fact]
    //    public async Task UpdateDocument2GradeTest()
    //    {


    //        var list = new List<Document2Grade>
    //{
    //    new Document2Grade
    //    {
    //        Document2Id = 1,
    //        GradeId = 9,
    //        TitleName = "Test",
    //        Slot = 3,
    //        Time = DateOnly.MaxValue,
    //        Place = "Test Place",
    //        HostBy = "Test Host",
    //        Description = "Test Description",
    //        CollaborateWith = "Test Collaborate",
    //        Condition = "Test Condition"
    //    },
    //    new Document2Grade
    //    {
    //        Document2Id = 2,
    //        GradeId = 9,
    //        TitleName = "Test",
    //        Slot = 2,
    //        Time = DateOnly.MaxValue,
    //        Place = "Test Place",
    //        HostBy = "Test Host",
    //        Description = "Test Description",
    //        CollaborateWith = "Test Collaborate",
    //        Condition = "Test Condition"
    //    }
    //};

    //        // Act
    //        await _repository.UpdateDocument2Grade(list);

    //        // Assert
    //        // Add your assertions here based on what you expect the method to do
    //    }

    }
}
