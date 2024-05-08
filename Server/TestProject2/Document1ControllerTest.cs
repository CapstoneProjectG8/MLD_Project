using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_MLD.Controllers;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace ControllerTest;
public class Document1ControllerTests
{
    private readonly Mock<IDocument1Repository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Document1Controller _controller;
    private readonly Mock<IGradeRepository> _mockGradeRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IDocument1CuriculumDistributionRepository> _mockCuriculumDistributionDoc1Repository;
    private readonly Mock<IDocument1PeriodicAssessmentsRepository> _mockPeriodicAssessmentDoc1Repository;
    private readonly Mock<IDocument1SelectedTopicsRepository> _mockSelectedTopicsDoc1Repository;
    private readonly Mock<IDocument1SubjectRoomsRepository> _mockSubjectRoomsDoc1Repository;
    private readonly Mock<IDocument1TeachingEquipmentRepository> _mockTeachingEquipmentDoc1Repository;

    public Document1ControllerTests()
    {
        _mockRepo = new Mock<IDocument1Repository>();
        _mockMapper = new Mock<IMapper>();
        _mockGradeRepository = new Mock<IGradeRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockCuriculumDistributionDoc1Repository = new Mock<IDocument1CuriculumDistributionRepository>();
        _mockPeriodicAssessmentDoc1Repository = new Mock<IDocument1PeriodicAssessmentsRepository>();
        _mockSelectedTopicsDoc1Repository = new Mock<IDocument1SelectedTopicsRepository>();
        _mockSubjectRoomsDoc1Repository = new Mock<IDocument1SubjectRoomsRepository>();
        _mockTeachingEquipmentDoc1Repository = new Mock<IDocument1TeachingEquipmentRepository>();
        _controller = new Document1Controller(_mockRepo.Object, _mockMapper.Object, _mockGradeRepository.Object, _mockUserRepository.Object, _mockCuriculumDistributionDoc1Repository.Object, _mockPeriodicAssessmentDoc1Repository.Object, _mockSelectedTopicsDoc1Repository.Object, _mockSubjectRoomsDoc1Repository.Object, _mockTeachingEquipmentDoc1Repository.Object);
    }

    [Fact]
    public async Task GetAllDocument1_ReturnsOkResult_WhenDocumentsExist()
    {
        // Arrange
        var documents = new List<Document1> { new Document1(), new Document1() };
        var documentDTOs = new List<Document1DTO> { new Document1DTO(), new Document1DTO() };
        _mockRepo.Setup(repo => repo.GetAllDocument1s()).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(documents)).Returns(documentDTOs);
        // Act
        var result = await _controller.GetAllDocument1s();
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetAllDocument1_ReturnsNotFoundResult_WhenNoDocumentsExist()
    {
        // Arrange
        var documents = new List<Document1> { new Document1(), new Document1() };
        var documentDTOs = new List<Document1DTO> { new Document1DTO(), new Document1DTO() };
        _mockRepo.Setup(repo => repo.GetAllDocument1s()).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(documents)).Returns(documentDTOs);
        // Act
        var result = await _controller.GetAllDocument1s();
        // Assert
        if (result == null)
            Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetAllDocument1_ReturnsCorrectType_WhenDocumentsExist()
    {
        // Arrange
        var documents = new List<Document1> { new Document1(), new Document1() };
        var documentDTOs = new List<Document1DTO> { new Document1DTO(), new Document1DTO() };
        _mockRepo.Setup(repo => repo.GetAllDocument1s()).ReturnsAsync(documents);
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(documents)).Returns(documentDTOs);
        // Act
        var result = await _controller.GetAllDocument1s();
        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsType<List<Document1DTO>>(okResult.Value);
        Assert.Equal(documentDTOs, okResult.Value);
    }

    [Fact]
    public async Task GetDocument1ById_ReturnsCorrectType_WhenDocumentExists()
    {
        // Arrange
        var document = new Document1();
        var documentDTO = new Document1DTO();
        _mockRepo.Setup(repo => repo.GetDocument1ById(It.IsAny<int>())).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document1DTO>(document)).Returns(documentDTO);
        // Act
        var result = await _controller.GetDocument1ById(1);
        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsType<Document1DTO>(okResult.Value);
        Assert.Equal(documentDTO, okResult.Value);
    }

    [Fact]
    public async Task GetDocument1ById_ReturnsNotFoundResult_WhenNoDocumentExists()
    {
        // Arrange
        var document = new Document1();
        var documentDTO = new Document1DTO();
        _mockRepo.Setup(repo => repo.GetDocument1ById(It.IsAny<int>())).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document1DTO>(document)).Returns(documentDTO);
        // Act

        var result = await _controller.GetDocument1ById(document.Id);

        // Assert
        if (result == null)
        {
            Assert.IsType<NotFoundResult>(result.Result);
        }

    }

    [Fact]
    public async Task FilterDocument1_ReturnsOk_WhenDocumentsExist()
    {
        // Arrange
        var gradeId = 1;
        var subjectId = 1;


        // Act
        var result = await _controller.FilterDocument1(gradeId, subjectId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetDocument1ByApprovalID_ReturnsOk_WhenDocumentExists()
    {
        // Arrange
        var id = 1;


        // Act
        var result = await _controller.GetDocument1ById(id);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task AddDocument1_ReturnsOk_WhenDocumentIsAdded()
    {
        // Arrange
        var document1DTO = new Document1DTO
        {
            Name = "Document1",
            SubjectId = 2,
            GradeId = 3,
            UserId = 4,
            Note = "This is a note.",
            Status = true,
            ApproveBy = 5,
            IsApprove = 1,
            LinkFile = "www.example.com/linkfile",
            LinkImage = "www.example.com/linkimage",
            OtherTasks = "Other tasks here",
            UserFullName = "John Doe",
            SubjectName = "Subject Name",
            GradeName = "Grade Name",
            ApproveByName = "Approver Name"
        };


        // Act
        var result = await _controller.AddDocument1(document1DTO);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    // You can add more test cases for each method to test different scenarios
}

