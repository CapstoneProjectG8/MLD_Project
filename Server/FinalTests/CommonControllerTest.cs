//using Xunit;
//using Moq;
//using Microsoft.AspNetCore.Mvc;
//using Project_MLD.Controllers;
//using Project_MLD.Service.Interface;
//using AutoMapper;
//using System.Collections.Generic;
//namespace ControllerTest;
//public class CommonControllerTests
//{
//    [Fact]
//    public async Task GetDocumentByUserId_ReturnsOkResult_WhenDocumentExists()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var mockMapper = new Mock<IMapper>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, mockMapper.Object);
//        int userId = 8;
//        int docType = 1;
//        int approveId = 1;

//        // Act
//        var result = await controller.GetDocumentByUserId(userId, docType, approveId);

//        // Assert
//        Assert.IsType<OkObjectResult>(result);
//    }

//    [Fact]
//    public async Task GetDocumentByUserId_ReturnsNotFoundResult_WhenDocumentDoesNotExist()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var mockMapper = new Mock<IMapper>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, mockMapper.Object);
//        int userId = 3;
//        int docType = 2;
//        int approveId = 2;

//        // Act
//        var result = await controller.GetDocumentByUserId(userId, docType, approveId);

//        // Assert
//        Assert.IsType<NotFoundObjectResult>(result);
//    }

//    [Fact]
//    public async Task GetDocumentByUserId_ReturnsBadRequestResult_WhenDocTypeDoesNotExist()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var mockMapper = new Mock<IMapper>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, mockMapper.Object);
//        int userId = 8;
//        int docType = 6; // DocType 6 does not exist
//        int approveId = 1;

//        // Act
//        var result = await controller.GetDocumentByUserId(userId, docType, approveId);

//        // Assert
//        Assert.IsType<BadRequestObjectResult>(result);
//    }

//    [Fact]
//    public async Task DeleteDocumentByDocumentId_ReturnsNoContentResult_WhenDocumentExists()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, null);
//        int docType = 1;
//        int docId = 3;

//        // Act
//        var result = await controller.DeleteDocumentByDocumentId(docType, docId);

//        // Assert
//        Assert.IsType<NoContentResult>(result);
//    }

//    [Fact]
//    public async Task DeleteDocumentByDocumentId_ReturnsNotFoundResult_WhenDocumentDoesNotExist()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, null);
//        int docType = 1;
//        int docId = 3;

//        // Act
//        var result = await controller.DeleteDocumentByDocumentId(docType, docId);

//        // Assert
//        Assert.IsType<NotFoundObjectResult>(result);
//    }

//    [Fact]
//    public async Task DeleteDocumentByDocumentId_ReturnsBadRequestResult_WhenDocTypeDoesNotExist()
//    {
//        // Arrange
//        var mockDocument1Repository = new Mock<IDocument1Repository>();
//        var controller = new CommonController(mockDocument1Repository.Object, null, null, null, null, null);
//        int docType = 6; // DocType 6 does not exist
//        int docId = 3;

//        // Act
//        var result = await controller.DeleteDocumentByDocumentId(docType, docId);

//        // Assert
//        Assert.IsType<BadRequestObjectResult>(result);
//    }
//}
