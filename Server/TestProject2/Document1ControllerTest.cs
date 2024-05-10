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
        var document = new Document1();
        var documentDTO = new Document1DTO();
        _mockRepo.Setup(repo => repo.GetDocument1ById(It.IsAny<int>())).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document1DTO>(document)).Returns(documentDTO);
        var id = 3;


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
            GradeId = 1,
            UserId = 6,
            Note = "This is a note.",
            Status = true,
            ApproveBy = 4,
            IsApprove = 1,
            LinkFile = "www.example.com/linkfile",
            LinkImage = "www.example.com/linkimage",
            OtherTasks = "Other tasks here",
            UserFullName = "John Doe",
            SubjectName = "Subject Name",
            GradeName = "Grade Name",
            ApproveByName = "Approver Name"
        };

        var document = new Document1
        {
            Name = document1DTO.Name,
            SubjectId = document1DTO.SubjectId,
            GradeId = document1DTO.GradeId,
            UserId = document1DTO.UserId,
            Note = document1DTO.Note,
            Status = document1DTO.Status,
            ApproveBy = document1DTO.ApproveBy,
            IsApprove = document1DTO.IsApprove,
            CreatedDate = document1DTO.CreatedDate,
            LinkFile = document1DTO.LinkFile,
            LinkImage = document1DTO.LinkImage,
            OtherTasks = document1DTO.OtherTasks
            // Assuming you handle the mapping of the collections and navigation properties elsewhere
        };

        _mockRepo.Setup(r => r.AddDocument1(It.IsAny<Document1>())).ReturnsAsync(document);
        _mockMapper.Setup(mapper => mapper.Map<Document1DTO>(document)).Returns(document1DTO);
        // Act
        var result = await _controller.AddDocument1(document1DTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Document1DTO>(okResult.Value);

        Assert.Equal(document1DTO.Name, returnValue.Name);
        Assert.Equal(document1DTO.SubjectId, returnValue.SubjectId);
        Assert.Equal(document1DTO.GradeId, returnValue.GradeId);
        Assert.Equal(document1DTO.UserId, returnValue.UserId);
        Assert.Equal(document1DTO.Note, returnValue.Note);
        Assert.Equal(document1DTO.Status, returnValue.Status);
        Assert.Equal(document1DTO.ApproveBy, returnValue.ApproveBy);
        Assert.Equal(document1DTO.IsApprove, returnValue.IsApprove);
        Assert.Equal(document1DTO.LinkFile, returnValue.LinkFile);
        Assert.Equal(document1DTO.LinkImage, returnValue.LinkImage);
        Assert.Equal(document1DTO.OtherTasks, returnValue.OtherTasks);
        // Add more assertions as needed
    }


    [Fact]
    public async Task AddDocument1_ReturnsBadRequest_WhenExceptionIsThrown()
    {
        // Arrange
        var document1DTO = new Document1DTO
        {
            Name = "Document1",
            SubjectId = 2,
            GradeId = 1,
            UserId = 6,
            Note = "This is a note.",
            Status = true,
            ApproveBy = 4,
            IsApprove = 1,
            LinkFile = "www.example.com/linkfile",
            LinkImage = "www.example.com/linkimage",
            OtherTasks = "Other tasks here",
            UserFullName = "John Doe",
            SubjectName = "Subject Name",
            GradeName = "Grade Name",
            ApproveByName = "Approver Name"
        };

        // Setup your repository mock to throw an exception when AddDocument1 is called
        _mockRepo.Setup(r => r.AddDocument1(It.IsAny<Document1>())).Throws(new Exception("Test exception"));

        // Act
        var result = await _controller.AddDocument1(document1DTO);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Can not add Error, Test exception", badRequestResult.Value);
    }
    [Fact]
    public async Task GetAllDoc1sWithCondition_ReturnsAllDocuments_WhenStatusAndIsApproveAreNull()
    {
        // Arrange
        var document = new Document1();
        var expectedDocuments = new List<Document1DTO> { /* Populate with expected data */ };
        _mockRepo.Setup(r => r.GetAllDoc1sWithCondition(null, null)).Returns(Task.FromResult(expectedDocuments as IEnumerable<Document1>));
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(It.IsAny<IEnumerable<Document1>>())).Returns(expectedDocuments);
        _mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(new User { FirstName = "Test", LastName = "User" }));

        // Act
        var result = await _controller.GetAllDoc1sWithCondition(null, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualDocuments = Assert.IsType<List<Document1DTO>>(okResult.Value);
        Assert.Equal(expectedDocuments, actualDocuments);
    }

    [Fact]
    public async Task GetAllDoc1sWithCondition_ReturnsFilteredDocuments_WhenStatusIsProvided()
    {
        // Arrange
        var document = new Document1();
        var expectedDocuments = new List<Document1DTO> { /* Populate with expected data */ };
        _mockRepo.Setup(r => r.GetAllDoc1sWithCondition(true, null)).Returns(Task.FromResult(expectedDocuments as IEnumerable<Document1>));
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(It.IsAny<IEnumerable<Document1>>())).Returns(expectedDocuments);
        _mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(new User { FirstName = "Test", LastName = "User" }));

        // Act
        var result = await _controller.GetAllDoc1sWithCondition(true, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualDocuments = Assert.IsType<List<Document1DTO>>(okResult.Value);
        Assert.Equal(expectedDocuments, actualDocuments);
    }

    [Fact]
    public async Task GetAllDoc1sWithCondition_ReturnsFilteredDocuments_WhenIsApproveIsProvided()
    {
        // Arrange
        var document = new Document1();
        var expectedDocuments = new List<Document1DTO> { /* Populate with expected data */ };
        _mockRepo.Setup(r => r.GetAllDoc1sWithCondition(null, 1)).Returns(Task.FromResult(expectedDocuments as IEnumerable<Document1>));
        _mockMapper.Setup(mapper => mapper.Map<List<Document1DTO>>(It.IsAny<IEnumerable<Document1>>())).Returns(expectedDocuments);
        _mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(new User { FirstName = "Test", LastName = "User" }));

        // Act
        var result = await _controller.GetAllDoc1sWithCondition(null, 1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualDocuments = Assert.IsType<List<Document1DTO>>(okResult.Value);
        Assert.Equal(expectedDocuments, actualDocuments);
    }

    [Fact]
    public async Task DeleteDocument1_ReturnsNotFound_WhenDocumentDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(r => r.DeleteDocument1(It.IsAny<int>())).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteDocument1(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task DeleteDocument1_ReturnsNoContent_WhenDocumentExists()
    {
        // Arrange
        _mockRepo.Setup(r => r.DeleteDocument1(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteDocument1(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteDocument1_CallsDeleteDocument1_Once()
    {
        // Arrange
        _mockRepo.Setup(r => r.DeleteDocument1(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteDocument1(1);

        // Assert
        _mockRepo.Verify(r => r.DeleteDocument1(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public async Task UpdateDocument1_ReturnsBadRequest_WhenUpdateFails()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateDocument1(new Document1DTO());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateDocument1_ReturnsOk_WhenUpdateSucceeds()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateDocument1(new Document1DTO());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<OkObjectResult>(okResult);
        Assert.Equal(okResult, response);
    }

    [Fact]
    public async Task UpdateDocument1_CallsUpdateDocument1_Once()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateDocument1(new Document1DTO());

        // Assert
        _mockRepo.Verify(r => r.UpdateDocument1(It.IsAny<Document1>()), Times.Once);
    }
    [Fact]
    public async Task GetTotalClassAndStudentByGradeId_ReturnsBadRequest_WhenGradeIdIsZero()
    {
        // Act
        var result = await _controller.GetTotalClassAndStudentByGradeId(0);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetTotalClassAndStudentByGradeId_CallsGradeRepositoryMethods_Once()
    {
        // Arrange
        _mockGradeRepository.Setup(r => r.GetTotalClassByGradeId(It.IsAny<int>())).ReturnsAsync(10);
        _mockGradeRepository.Setup(r => r.GetTotalStudentByGradeId(It.IsAny<int>())).ReturnsAsync(100);
        _mockGradeRepository.Setup(r => r.GetTotalStudentSelectedTopicsByGradeId(It.IsAny<int>())).ReturnsAsync(50);

        // Act
        var result = await _controller.GetTotalClassAndStudentByGradeId(1);

        // Assert
        _mockGradeRepository.Verify(r => r.GetTotalClassByGradeId(It.IsAny<int>()), Times.Once);
        _mockGradeRepository.Verify(r => r.GetTotalStudentByGradeId(It.IsAny<int>()), Times.Once);
        _mockGradeRepository.Verify(r => r.GetTotalStudentSelectedTopicsByGradeId(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public async Task GetTeacherInformation_ReturnsBadRequest_WhenSpecializedDepartmentIdIsZero()
    {
        // Act
        var result = await _controller.GetTeacherInformation(0);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task ApproveDocument1_ReturnsBadRequest_WhenUpdateFails()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(false);

        // Act
        var result = await _controller.ApproveDocument1(new Document1DTO());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task ApproveDocument1_ReturnsOk_WhenUpdateSucceeds()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(true);

        // Act
        var result = await _controller.ApproveDocument1(new Document1DTO());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<OkObjectResult>(okResult);
        Assert.Equal(result, response);
    }

    [Fact]
    public async Task ApproveDocument1_CallsUpdateDocument1_Once()
    {
        // Arrange
        _mockRepo.Setup(r => r.UpdateDocument1(It.IsAny<Document1>())).ReturnsAsync(true);

        // Act
        var result = await _controller.ApproveDocument1(new Document1DTO());

        // Assert
        _mockRepo.Verify(r => r.UpdateDocument1(It.IsAny<Document1>()), Times.Once);
    }
    [Fact]
    public async Task GetDocument1ByUserSpecialiedDepartment_ReturnsOk_WhenListIdIsNotEmpty()
    {
        // Arrange
        var expectedDocuments = new List<object> { /* Populate with expected data */ };
        _mockRepo.Setup(r => r.GetDoc1ByUserDepartment(It.IsAny<List<int>>())).ReturnsAsync(expectedDocuments);

        // Act
        var result = await _controller.GetDocument1ByUserSpecialiedDepartment(new List<int> { 1 });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualDocuments = Assert.IsType<List<object>>(okResult.Value);
        Assert.Equal(expectedDocuments, actualDocuments);
    }

    [Fact]
    public async Task GetDocument1ByUserSpecialiedDepartment_CallsGetDoc1ByUserDepartment_Once()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetDoc1ByUserDepartment(It.IsAny<List<int>>())).ReturnsAsync(new List<object>());

        // Act
        var result = await _controller.GetDocument1ByUserSpecialiedDepartment(new List<int> { 1 });

        // Assert
        _mockRepo.Verify(r => r.GetDoc1ByUserDepartment(It.IsAny<List<int>>()), Times.Once);
    }
    [Fact]
    public async Task DeleteDocument1ForeignTableByDocument1ID_ReturnsOk_WhenDeletionIsSuccessful()
    {
        // Arrange
        _mockCuriculumDistributionDoc1Repository.Setup(r => r.DeleteDocument1CurriculumDistributionByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockPeriodicAssessmentDoc1Repository.Setup(r => r.DeleteDocument1PeriodicAssessmentByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockSelectedTopicsDoc1Repository.Setup(r => r.DeleteDocument1SelectedTopicByDoc1Id(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockTeachingEquipmentDoc1Repository.Setup(r => r.DeleteDocument1TeachingEquipmentByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockSubjectRoomsDoc1Repository.Setup(r => r.DeleteDocument1SubjectRoomByDoc1Id(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteDocument1ForeignTableByDocument1ID(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task DeleteDocument1ForeignTableByDocument1ID_ReturnsStatusCode500_WhenExceptionIsThrown()
    {
        // Arrange
        _mockCuriculumDistributionDoc1Repository.Setup(r => r.DeleteDocument1CurriculumDistributionByDoc1ID(It.IsAny<int>())).Throws(new Exception());

        // Act
        var result = await _controller.DeleteDocument1ForeignTableByDocument1ID(1);

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, ((ObjectResult)result).StatusCode);
    }

    [Fact]
    public async Task DeleteDocument1ForeignTableByDocument1ID_CallsDeleteMethods_Once()
    {
        // Arrange
        _mockCuriculumDistributionDoc1Repository.Setup(r => r.DeleteDocument1CurriculumDistributionByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockPeriodicAssessmentDoc1Repository.Setup(r => r.DeleteDocument1PeriodicAssessmentByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockSelectedTopicsDoc1Repository.Setup(r => r.DeleteDocument1SelectedTopicByDoc1Id(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockTeachingEquipmentDoc1Repository.Setup(r => r.DeleteDocument1TeachingEquipmentByDoc1ID(It.IsAny<int>())).Returns(Task.CompletedTask);
        _mockSubjectRoomsDoc1Repository.Setup(r => r.DeleteDocument1SubjectRoomByDoc1Id(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteDocument1ForeignTableByDocument1ID(1);

        // Assert
        _mockCuriculumDistributionDoc1Repository.Verify(r => r.DeleteDocument1CurriculumDistributionByDoc1ID(It.IsAny<int>()), Times.Once);
        _mockPeriodicAssessmentDoc1Repository.Verify(r => r.DeleteDocument1PeriodicAssessmentByDoc1ID(It.IsAny<int>()), Times.Once);
        _mockSelectedTopicsDoc1Repository.Verify(r => r.DeleteDocument1SelectedTopicByDoc1Id(It.IsAny<int>()), Times.Once);
        _mockTeachingEquipmentDoc1Repository.Verify(r => r.DeleteDocument1TeachingEquipmentByDoc1ID(It.IsAny<int>()), Times.Once);
        _mockSubjectRoomsDoc1Repository.Verify(r => r.DeleteDocument1SubjectRoomByDoc1Id(It.IsAny<int>()), Times.Once);
    }

}

