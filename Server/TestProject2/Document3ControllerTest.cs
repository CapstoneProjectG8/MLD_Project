using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_MLD.Controllers;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ControllerTest;

public class Document3ControllerTests
{
    private readonly Mock<IDocument3Repository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IDocument3CurriculumDistributionRepository> _mockCurriculumDistributionRepository;
    private readonly Mock<IDocument3SelectedTopicsRepository> _mockSelectedTopicsRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<INotificationRepository> _mockNotificationRepository;
    private readonly Document3Controller _controller;

    public Document3ControllerTests()
    {
        _mockRepository = new Mock<IDocument3Repository>();
        _mockMapper = new Mock<IMapper>();
        _mockCurriculumDistributionRepository = new Mock<IDocument3CurriculumDistributionRepository>();
        _mockSelectedTopicsRepository = new Mock<IDocument3SelectedTopicsRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockNotificationRepository = new Mock<INotificationRepository>();

        _controller = new Document3Controller(
            _mockRepository.Object,
            _mockMapper.Object,
            _mockCurriculumDistributionRepository.Object,
            _mockSelectedTopicsRepository.Object,
            _mockUserRepository.Object,
            _mockNotificationRepository.Object);
    }
        [Fact]
    public async Task GetAllDocument3s_ReturnsOkResult_WithListOfDocument3DTOs()
    {
        // Arrange
        var documents = new List<Document3>
        {
            new Document3 { Id = 1, UserId = 1, ApproveBy = 2 },
            new Document3 { Id = 2, UserId = 2, ApproveBy = null }
        };

        var documentDTOs = new List<Document3DTO>
        {
            new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2 },
            new Document3DTO { Id = 2, UserId = 2, ApproveBy = null }
        };

        var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

        _mockRepository.Setup(repo => repo.GetAllDocument3s()).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document3DTO>>(documents)).Returns(documentDTOs);
        _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
        _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

        // Act
        var result = await _controller.GetAllDocument3s();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Document3DTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
        Assert.Equal("John Doe", returnValue[0].UserFullName);
        Assert.Equal("Jane Smith", returnValue[1].UserFullName);
    }

    [Fact]
    public async Task GetDoc3ById_ReturnsOkResult_WithDocument3DTO()
    {
        // Arrange
        var document = new Document3 { Id = 1, UserId = 1, ApproveBy = 2 };
        var documentDTO = new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2 };
        var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

        _mockRepository.Setup(repo => repo.GetDocument3ById(1)).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document3DTO>(document)).Returns(documentDTO);
        _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
        _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

        // Act
        var result = await _controller.GetDoc3ById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Document3DTO>(okResult.Value);
        Assert.Equal(1, returnValue.Id);
        Assert.Equal("John Doe", returnValue.UserFullName);
        Assert.Equal("Jane Smith", returnValue.ApproveByName);
    }

    [Fact]
    public async Task AddDoc3_ReturnsOkResult_WithCreatedDocument3DTO()
    {
        // Arrange
        var documentDTO = new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2 };
        var document = new Document3 { Id = 1, UserId = 1, ApproveBy = 2 };

        _mockMapper.Setup(mapper => mapper.Map<Document3>(documentDTO)).Returns(document);
        _mockRepository.Setup(repo => repo.AddDocument3(document)).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document3DTO>(document)).Returns(documentDTO);

        // Act
        var result = await _controller.AddDoc3(documentDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Document3DTO>(okResult.Value);
        Assert.Equal(1, returnValue.Id);
    }

    [Fact]
    public async Task DeleteDoc3_ReturnsNoContent_WhenDocumentExists()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteDocument3(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteDoc3(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteDoc3_ReturnsNotFound_WhenDocumentDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteDocument3(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteDoc3(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Document 3 Available", notFoundResult.Value);
    }

    [Fact]
    public async Task GetAllDoc3sWithCondition_ReturnsOkResult_WithFilteredListOfDocument3DTOs()
    {
        // Arrange
        var documents = new List<Document3>
        {
            new Document3 { Id = 1, UserId = 1, ApproveBy = 2, Status = true },
            new Document3 { Id = 2, UserId = 2, ApproveBy = null, Status = true }
        };

        var documentDTOs = new List<Document3DTO>
        {
            new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2, Status = true },
            new Document3DTO { Id = 2, UserId = 2, ApproveBy = null, Status = true }
        };

        var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
        var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

        _mockRepository.Setup(repo => repo.GetAllDoc3sWithCondition(true, null)).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document3DTO>>(documents)).Returns(documentDTOs);
        _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
        _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

        // Act
        var result = await _controller.GetAllDoc3sWithCondition(true, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Document3DTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
        Assert.Equal("John Doe", returnValue[0].UserFullName);
        Assert.Equal("Jane Smith", returnValue[1].UserFullName);
    }

    [Fact]
    public async Task GetDoc3ByUserDepartment_ReturnsOkResult_WithDocument3sGroupedByDepartment()
    {
        // Arrange
        var documents = new List<object>
        {
            new { id = 1, document = new List<Document3> { new Document3 { Id = 1, UserId = 1, ApproveBy = 2 } } },
            new { id = 2, document = new List<Document3> { new Document3 { Id = 2, UserId = 2, ApproveBy = null } } }
        };

        var documentDTOs = new List<Document3DTO>
        {
            new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2 },
            new Document3DTO { Id = 2, UserId = 2, ApproveBy = null }
        };

        _mockRepository.Setup(repo => repo.GetDocument3ByUserSpecialiedDepartment(It.IsAny<List<int>>())).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document3DTO>>(It.IsAny<IEnumerable<Document3>>())).Returns(documentDTOs);

        // Act
        var result = await _controller.GetDoc3ByUserDepartment(new List<int> { 1, 2 });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<object>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task UpdateDoc3_ReturnsOkResult_WithUpdatedDocument3DTO()
    {
        // Arrange
        var documentDTO = new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2 };
        var document = new Document3 { Id = 1, UserId = 1, ApproveBy = 2 };

        _mockMapper.Setup(mapper => mapper.Map<Document3>(documentDTO)).Returns(document);
        _mockRepository.Setup(repo => repo.UpdateDocument3(document)).ReturnsAsync(true);
        _mockMapper.Setup(mapper => mapper.Map<Document3DTO>(document)).Returns(documentDTO);

        // Act
        var result = await _controller.UpdateDoc3(documentDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<dynamic>(okResult.Value);
        Assert.Equal("Update Success", returnValue.message);
        Assert.Equal(documentDTO, returnValue.dataMap);
    }

    [Fact]
    public async Task ApproveDoc3_ReturnsOkResult_WithApprovedDocument3DTO()
    {
        // Arrange
        var documentDTO = new Document3DTO { Id = 1, UserId = 1, ApproveBy = 2, Status = true };
        var document = new Document3 { Id = 1, UserId = 1, ApproveBy = 2, Status = true };

        _mockMapper.Setup(mapper => mapper.Map<Document3>(documentDTO)).Returns(document);
        _mockRepository.Setup(repo => repo.UpdateDocument3(document)).ReturnsAsync(true);
        _mockMapper.Setup(mapper => mapper.Map<Document3DTO>(document)).Returns(documentDTO);

        // Act
        var result = await _controller.ApproveDoc3(documentDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<dynamic>(okResult.Value);
        Assert.Equal("Update Success", returnValue.message);
        Assert.Equal(documentDTO, returnValue.dataMap);
    }

    [Fact]
    public async Task DeleteDoc3ForeignTableByDoc3Id_ReturnsOkResult_WhenDeleteIsSuccessful()
    {
        // Arrange
        _mockCurriculumDistributionRepository.Setup(repo => repo.DeleteDocument3CurriculumDistributionByDoc3Id(1)).Returns(Task.CompletedTask);
        _mockSelectedTopicsRepository.Setup(repo => repo.DeleteDocument3SelectedTopicsbyDoc3Id(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteDoc3ForeignTableByDoc3Id(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Delete Successfully", okResult.Value);
    }

    [Fact]
    public async Task DeleteDoc3ForeignTableByDoc3Id_ReturnsInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        _mockCurriculumDistributionRepository.Setup(repo => repo.DeleteDocument3CurriculumDistributionByDoc3Id(1)).ThrowsAsync(new Exception("Some error"));
        _mockSelectedTopicsRepository.Setup(repo => repo.DeleteDocument3SelectedTopicsbyDoc3Id(1)).ThrowsAsync(new Exception("Some error"));

        // Act
        var result = await _controller.DeleteDoc3ForeignTableByDoc3Id(1);

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Contains("An error occurred while delete Document3 Foreign Table: Some error", statusCodeResult.Value.ToString());
    }
}
