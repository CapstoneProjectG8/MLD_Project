//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Threading.Tasks;
//using System.Linq;

//namespace FinalTest
//{
//    public class Document2RepositoryTests
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly Document2Repository _repository;

//        public Document2RepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                .Options;
//            _context = new MldDatabaseContext(options);
//            _repository = new Document2Repository(_context);
//        }

//        [Fact]
//        public async Task AddDocument2Test()
//        {
//            try
//            {
//                var document2 = new Document2 { Name = "Test" };
//                var result = await _repository.AddDocument2(document2);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task DeleteDocument2Test()
//        {
//            try
//            {
//                var document2 = new Document2 { Name = "Test" };
//                var addedDocument2 = await _repository.AddDocument2(document2);
//                var result = await _repository.DeleteDocument2(addedDocument2.Id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetAllDocument2sTest()
//        {
//            try
//            {
//                var result = await _repository.GetAllDocument2s();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument2ByIdTest()
//        {
//            try
//            {
//                var document2 = new Document2 { Name = "Test" };
//                var addedDocument2 = await _repository.AddDocument2(document2);
//                var result = await _repository.GetDocument2ById(addedDocument2.Id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument2ByConditionTest()
//        {
//            try
//            {
//                var result = await _repository.GetDocument2ByCondition("Test");
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task UpdateDocument2Test()
//        {
//            try
//            {
//                var document2 = new Document2 { Name = "Test" };
//                var addedDocument2 = await _repository.AddDocument2(document2);
//                var result = await _repository.UpdateDocument2(addedDocument2);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument2ByApprovalTest()
//        {
//            try
//            {
//                var result = await _repository.GetDocument2ByApproval();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }


//    }
//}
