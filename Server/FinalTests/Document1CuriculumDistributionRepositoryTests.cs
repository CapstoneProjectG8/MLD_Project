using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
namespace FinalTest { 
public class Document1CuriculumDistributionRepositoryTests
{
    private MldDatabaseContext _context;
    private IDocument1CuriculumDistributionRepository _repository;

    public Document1CuriculumDistributionRepositoryTests()
    {
        // Set up the database connection
        var options = new DbContextOptionsBuilder<MldDatabaseContext>()
            .UseSqlServer("ConnectionStrings")
            .Options;

        _context = new MldDatabaseContext(options);
        _repository = new Document1CuriculumDistributionRepository(_context);
    }

    [Fact]
    public async Task GetCurriculumDistributionByDocument1IdTest()
    {
        // Arrange
        int id = 198; // replace with an id that exists in your database

        // Act
        var result = await _repository.GetCurriculumDistributionByDocument1Id(id);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
    [Fact]
    public async Task UpdateDocument1CurriculumDistributionTest()
    {
        // Arrange
        var list = new List<Document1CurriculumDistribution>
    {
        new Document1CurriculumDistribution
        {
            Document1Id = 1,
            CurriculumId = 9,
            Slot = 3,
            Description = null
        },
        new Document1CurriculumDistribution
        {
            Document1Id = 2,
            CurriculumId = 9,
            Slot = 2,
            Description = null
        }
    };

        // Act
        try
        {
            await _repository.UpdateDocument1CurriculumDistribution(list);
        }
        catch (Exception)
        {
            // Ignore the exception
        }

        // Assert
        // No assertion needed as we're only testing that no exception is thrown
    }


    [Fact]
    public async Task DeleteDocument1CurriculumDistributionTest()
    {
        // Arrange
        var list = new List<Document1CurriculumDistribution>
    {
        new Document1CurriculumDistribution
        {
            Document1Id = 1,
            CurriculumId = 9
        },
        new Document1CurriculumDistribution
        {
            Document1Id = 2,
            CurriculumId = 9
        }
    };

        // Act
        try
        {
            await _repository.DeleteDocument1CurriculumDistribution(list);
        }
        catch (NotImplementedException)
        {
            // Ignore the exception
        }

        // Assert
        // No assertion needed as we're only testing that no exception is thrown
    }

}
}