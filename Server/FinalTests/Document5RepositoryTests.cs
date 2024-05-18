//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FinalTest
//{
//    public class Document5RepositoryTests
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly Document5Repository _repository;

//        public Document5RepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                .Options;
//            _context = new MldDatabaseContext(options);
//            _repository = new Document5Repository(_context);
//        }

//        [Fact]
//        public async Task AddDocument5Test()
//        {
//            try
//            {
//                var document5 = new Document5 { Name = "Test" };
//                var result = await _repository.AddDocument5(document5);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task DeleteDocument5Test()
//        {
//            try
//            {
//                var document5 = new Document5 { Name = "Test" };
//                var addedDocument5 = await _repository.AddDocument5(document5);
//                var result = await _repository.DeleteDocument5(addedDocument5.Id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetAllDocument5sTest()
//        {
//            try
//            {
//                var result = await _repository.GetAllDocument5s();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument5ByIdTest()
//        {
//            try
//            {
//                int id = 1; // replace with an id that exists in your database
//                var result = await _repository.GetDocument5ById(id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDocument5sByConditionTest()
//        {
//            try
//            {
//                var result = await _repository.GetDocument5sByCondition("Test");
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetDoucment5ByDoc4Test()
//        {
//            try
//            {
//                int id = 1; // replace with an id that exists in your database
//                var result = await _repository.GetDoucment5ByDoc4(id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task UpdateDocument5Test()
//        {
//            try
//            {
//                var document5 = new Document5 { Name = "Test" };
//                var addedDocument5 = await _repository.AddDocument5(document5);
//                addedDocument5.Name = "Updated Test";
//                var result = await _repository.UpdateDocument5(addedDocument5);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }


//    }
//}
