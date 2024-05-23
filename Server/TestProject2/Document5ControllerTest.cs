using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Controllers;
using Project_MLD.Service.Interface;
using Project_MLD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Document5ControllerTests
{
    private readonly Mock<IDocument5Repository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Document5Controller _controller;

    public Document5ControllerTests()
    {
        _mockRepository = new Mock<IDocument5Repository>();
        _mockMapper = new Mock<IMapper>();

        _controller = new Document5Controller(
            _mockRepository.Object,
            _mockMapper.Object
        );
    }

    [Fact]
    public async Task GetAllDocument5s_ReturnsOkResult_WithListOfDocument5DTO()
    {
        // Arrange
        var document5List = new List<Document5> { new Document5() };
        var document5DTOList = new List<Document5DTO> { new Document5DTO() };

        _mockRepository.Setup(repo => repo.GetAllDocument5s()).ReturnsAsync(document5List);
        _mockMapper.Setup(mapper => mapper.Map<List<Document5DTO>>(document5List)).Returns(document5DTOList);

        // Act
        var result = await _controller.GetAllDocument5s();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Document5DTO>>(okResult.Value);
        Assert.Equal(document5DTOList.Count, returnValue.Count);
    }
    [Fact]
    public async Task GetDocument5ById_ReturnsOkResult_WithDocument5DTO()
    {
        // Arrange
        var document5 = new Document5();
        var document5DTO = new Document5DTO();

        _mockRepository.Setup(repo => repo.GetDocument5ById(It.IsAny<int>())).ReturnsAsync(document5);
        _mockMapper.Setup(mapper => mapper.Map<Document5DTO>(document5)).Returns(document5DTO);

        // Act
        var result = await _controller.GetDocument5ById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Document5DTO>(okResult.Value);
        Assert.Equal(document5DTO, returnValue);
    }
    [Fact]
    public async Task GetDoucment5ByDoc4_ReturnsOkResult_WithDocument5DTO()
    {
        // Arrange
        var document5List = new List<Document5> { new Document5() };
        var document5DTOList = new List<Document5DTO> { new Document5DTO() };

        _mockRepository.Setup(repo => repo.GetDoucment5ByDoc4(It.IsAny<int>())).ReturnsAsync(document5List);
        _mockMapper.Setup(mapper => mapper.Map<List<Document5DTO>>(document5List)).Returns(document5DTOList);

        // Act
        var result = await _controller.GetDoucment5ByDoc4(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Document5DTO>>(okResult.Value);
        Assert.Equal(document5DTOList.Count, returnValue.Count);
    }
    [Fact]
    public async Task AddDocument5_ReturnsOkResult_WithDocument5DTO()
    {
        // Arrange
        var document5DTO = new Document5DTO { CreatedDate = DateOnly.FromDateTime(DateTime.Now) };
        var document5 = new Document5();
        var savedDocument5 = new Document5();

        _mockMapper.Setup(mapper => mapper.Map<Document5>(document5DTO)).Returns(document5);
        _mockRepository.Setup(repo => repo.AddDocument5(document5)).ReturnsAsync(savedDocument5);
        _mockMapper.Setup(mapper => mapper.Map<Document5DTO>(savedDocument5)).Returns(document5DTO);

        // Act
        var result = await _controller.AddDocument5(document5DTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Document5DTO>(okResult.Value);
        Assert.Equal(document5DTO, returnValue);
    }
    [Fact]
    public async Task DeleteDocument5_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteDocument5(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteDocument5(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteDocument5_ReturnsNotFound_WhenDocumentNotExists()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteDocument5(It.IsAny<int>())).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteDocument5(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Document 5 Available", notFoundResult.Value);
    }
    [Fact]
    public async Task UpdateDocument5_ReturnsOkResult_WithUpdatedDocument5DTO()
    {
        // Arrange
        var document5DTO = new Document5DTO();
        var document5 = new Document5();

        _mockMapper.Setup(mapper => mapper.Map<Document5>(document5DTO)).Returns(document5);
        _mockRepository.Setup(repo => repo.UpdateDocument5(document5)).ReturnsAsync(true);
        _mockMapper.Setup(mapper => mapper.Map<Document5DTO>(document5)).Returns(document5DTO);

        // Act
        var result = await _controller.UpdateDocument5(document5DTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Document5DTO>(okResult.Value);
        Assert.Equal(document5DTO, returnValue);
    }

    [Fact]
    public async Task UpdateDocument5_ReturnsNotFound_WhenUpdateFails()
    {
        // Arrange
        var document5DTO = new Document5DTO();
        var document5 = new Document5();

        _mockMapper.Setup(mapper => mapper.Map<Document5>(document5DTO)).Returns(document5);
        _mockRepository.Setup(repo => repo.UpdateDocument5(document5)).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateDocument5(document5DTO);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Error Updating", notFoundResult.Value);
    }

}
