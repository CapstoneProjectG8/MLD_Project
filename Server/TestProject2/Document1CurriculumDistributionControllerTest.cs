using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_MLD.Controllers;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace ControllerTest;
public class Document1CuriculumDistributionControllerTests
{
    private readonly Mock<IDocument1CuriculumDistributionRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Document1CuriculumDistributionController _controller;

    public Document1CuriculumDistributionControllerTests()
    {
        _mockRepository = new Mock<IDocument1CuriculumDistributionRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new Document1CuriculumDistributionController(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetDocument1CuriculumDistributionByDocument1ID_WithExistingId_ReturnsOkResultWithCurriculumDistributions()
    {
        // Arrange
        var curriculumDistributions = new List<Document1CurriculumDistribution> { new Document1CurriculumDistribution(), new Document1CurriculumDistribution() };
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO> { new Document1CurriculumDistributionDTO(), new Document1CurriculumDistributionDTO() };
        _mockRepository.Setup(r => r.GetCurriculumDistributionByDocument1Id(It.IsAny<int>())).ReturnsAsync(curriculumDistributions);
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistributionDTO>>(It.IsAny<List<Document1CurriculumDistribution>>())).Returns(curriculumDistributionsDto);

        // Act
        var result = await _controller.GetDocument1CuriculumDistributionByDocument1ID(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(curriculumDistributionsDto, okResult.Value);
    }

    [Fact]
    public async Task AddDocument1CurriculumDistribution_WithValidCurriculumDistribution_ReturnsOkResult()
    {
        // Arrange
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO> { new Document1CurriculumDistributionDTO(), new Document1CurriculumDistributionDTO() };
        var curriculumDistributions = new List<Document1CurriculumDistribution> { new Document1CurriculumDistribution(), new Document1CurriculumDistribution() };
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistribution>>(It.IsAny<List<Document1CurriculumDistributionDTO>>())).Returns(curriculumDistributions);
        _mockRepository.Setup(r => r.AddDocument1CurriculumDistribution(It.IsAny<List<Document1CurriculumDistribution>>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.AddDocument1CurriculumDistribution(curriculumDistributionsDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task DeleteDocument1CurriculumDistribution_WithValidCurriculumDistribution_ReturnsOkResult()
    {
        // Arrange
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO> { new Document1CurriculumDistributionDTO(), new Document1CurriculumDistributionDTO() };
        var curriculumDistributions = new List<Document1CurriculumDistribution> { new Document1CurriculumDistribution(), new Document1CurriculumDistribution() };
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistribution>>(It.IsAny<List<Document1CurriculumDistributionDTO>>())).Returns(curriculumDistributions);
        _mockRepository.Setup(r => r.DeleteDocument1CurriculumDistribution(It.IsAny<List<Document1CurriculumDistribution>>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteDocument1CurriculumDistribution(curriculumDistributionsDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    [Fact]
    public async Task GetDocument1CuriculumDistributionByDocument1ID_ReturnsOkResultWithEmptyList_WhenRepositoryReturnsEmptyList()
    {
        // Arrange
        var curriculumDistributions = new List<Document1CurriculumDistribution>();
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO>();
        _mockRepository.Setup(r => r.GetCurriculumDistributionByDocument1Id(It.IsAny<int>())).ReturnsAsync(curriculumDistributions);
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistributionDTO>>(It.IsAny<List<Document1CurriculumDistribution>>())).Returns(curriculumDistributionsDto);

        // Act
        var result = await _controller.GetDocument1CuriculumDistributionByDocument1ID(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(curriculumDistributionsDto, okResult.Value);
    }

    [Fact]
    public async Task AddDocument1CurriculumDistribution_ReturnsStatusCode500_WhenRepositoryThrowsException()
    {
        // Arrange
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO> { new Document1CurriculumDistributionDTO(), new Document1CurriculumDistributionDTO() };
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistribution>>(It.IsAny<List<Document1CurriculumDistributionDTO>>())).Returns(new List<Document1CurriculumDistribution>());
        _mockRepository.Setup(r => r.AddDocument1CurriculumDistribution(It.IsAny<List<Document1CurriculumDistribution>>())).ThrowsAsync(new Exception());

        // Act
        var result = await _controller.AddDocument1CurriculumDistribution(curriculumDistributionsDto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
    }

    [Fact]
    public async Task DeleteDocument1CurriculumDistribution_ReturnsStatusCode500_WhenRepositoryThrowsException()
    {
        // Arrange
        var curriculumDistributionsDto = new List<Document1CurriculumDistributionDTO> { new Document1CurriculumDistributionDTO(), new Document1CurriculumDistributionDTO() };
        _mockMapper.Setup(m => m.Map<List<Document1CurriculumDistribution>>(It.IsAny<List<Document1CurriculumDistributionDTO>>())).Returns(new List<Document1CurriculumDistribution>());
        _mockRepository.Setup(r => r.DeleteDocument1CurriculumDistribution(It.IsAny<List<Document1CurriculumDistribution>>())).ThrowsAsync(new Exception());

        // Act
        var result = await _controller.DeleteDocument1CurriculumDistribution(curriculumDistributionsDto);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
    }

}
