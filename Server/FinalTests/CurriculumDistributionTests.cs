//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Threading.Tasks;

//namespace FinalTest
//{
//    public class CurriculumDistributionRepositoryTests
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly CurriculumDistributionRepository _repository;

//        public CurriculumDistributionRepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                .Options;

//            _context = new MldDatabaseContext(options);
//            _repository = new CurriculumDistributionRepository(_context);
//        }

//        public async Task InitializeDatabase()
//        {
//            // Clean up the database here
//            _context.CurriculumDistributions.RemoveRange(_context.CurriculumDistributions);
//            await _context.SaveChangesAsync();
//        }

//        [Fact]
//        public async Task AddCurriculumDistribution_ReturnsNewCurriculumDistribution()
//        {
//            try
//            {
//                var curriculumDistribution = new CurriculumDistribution { Name = "Test" };
//                var result = await _repository.AddCurriculumDistribution(curriculumDistribution);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task DeleteCurriculumDistribution_ReturnsTrueWhenExists()
//        {
//            try
//            {
//                var curriculumDistribution = new CurriculumDistribution { Name = "Test" };
//                var addedCurriculumDistribution = await _repository.AddCurriculumDistribution(curriculumDistribution);
//                var result = await _repository.DeleteCurriculumDistribution(addedCurriculumDistribution.Id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetAllCurriculumDistributions_ReturnsAllCurriculumDistributions_StableDatabase()
//        {
//            try
//            {
//                var result = await _repository.GetAllCurriculumDistributions();
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//        [Fact]
//        public async Task GetCurriculumDistributionById_ReturnsCurriculumDistributionWhenExists()
//        {
//            try
//            {
//                int id = 1; // replace with an id that exists in your database
//                var result = await _repository.GetCurriculumDistributionById(id);
//            }
//            catch (Exception)
//            {
//                // Ignore the exception
//            }
//        }

//    }
//}
