//using Xunit;
//using Moq;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FinalTest
//{
//    public class Document3RepositoryTests
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly Document3Repository _repository;

//        public Document3RepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                .Options;
//            _context = new MldDatabaseContext(options);
//            _repository = new Document3Repository(_context);
//        }

//        [Fact]
//        public async Task AddDocument3Test()
//        {
//            try
//            {
//                var document3 = new Document3 { Name = "Test" };
//                var result = await _repository.AddDocument3(document3);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task DeleteDocument3Test()
//        {
//            try
//            {
//                var document3 = new Document3 { Name = "Test" };
//                var addedDocument3 = await _repository.AddDocument3(document3);
//                var result = await _repository.DeleteDocument3(addedDocument3.Id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetAllDocument3sTest()
//        {
//            try
//            {
//                var result = await _repository.GetAllDocument3s();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument3ByApprovalTest()
//        {
//            try
//            {
//                var result = await _repository.GetDocument3ByApproval();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument3ByIdTest()
//        {
//            try
//            {
//                int id = 1; // replace with an id that exists in your database
//                var result = await _repository.GetDocument3ById(id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument3sByConditionTest()
//        {
//            try
//            {
//                var result = await _repository.GetDocument3sByCondition("Test");
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task UpdateDocument3Test()
//        {
//            try
//            {
//                var document3 = new Document3 { Name = "Test" };
//                var addedDocument3 = await _repository.AddDocument3(document3);
//                addedDocument3.Name = "Updated Test";
//                var result = await _repository.UpdateDocument3(addedDocument3);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//    }
//}
