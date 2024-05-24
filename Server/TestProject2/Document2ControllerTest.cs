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

namespace ControllerTest
{
    public class Document2ControllerTests
    {
        private readonly Mock<IDocument2Repository> _mockRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<ISpecializedDepartmentRepository> _mockSpecialDepartmentRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<INotificationRepository> _mockNotificationRepository;
        private readonly Document2Controller _controller;

        public Document2ControllerTests()
        {
            _mockRepository = new Mock<IDocument2Repository>();
            _mockMapper = new Mock<IMapper>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockSpecialDepartmentRepository = new Mock<ISpecializedDepartmentRepository>();
            _mockNotificationRepository = new Mock<INotificationRepository>();

            _controller = new Document2Controller(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockUserRepository.Object,
                _mockSpecialDepartmentRepository.Object,
                _mockNotificationRepository.Object);
        }

        [Fact]
        public async Task GetAllDocument2s_ReturnsOkResult_WithListOfDocument2DTOs()
        {
            // Arrange
            var documents = new List<Document2>
            {
                new Document2 { Id = 1, UserId = 1, ApproveBy = 2 },
                new Document2 { Id = 2, UserId = 2, ApproveBy = null }
            };

            var documentDTOs = new List<Document2DTO>
            {
                new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2 },
                new Document2DTO { Id = 2, UserId = 2, ApproveBy = null }
            };

            var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
            var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

            _mockRepository.Setup(repo => repo.GetAllDocument2s()).ReturnsAsync(documents);
            _mockMapper.Setup(mapper => mapper.Map<List<Document2DTO>>(documents)).Returns(documentDTOs);
            _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
            _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

            // Act
            var result = await _controller.GetAllDocument2s();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Document2DTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("John Doe", returnValue[0].UserFullName);
            Assert.Equal("Jane Smith", returnValue[1].UserFullName);
        }

        [Fact]
        public async Task GetAllDoc2sWithCondition_ReturnsOkResult_WithFilteredListOfDocument2DTOs()
        {
            // Arrange
            var documents = new List<Document2>
            {
                new Document2 { Id = 1, UserId = 1, ApproveBy = 2, Status = true },
                new Document2 { Id = 2, UserId = 2, ApproveBy = null, Status = true }
            };

            var documentDTOs = new List<Document2DTO>
            {
                new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2, Status = true },
                new Document2DTO { Id = 2, UserId = 2, ApproveBy = null, Status = true }
            };

            var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
            var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

            _mockRepository.Setup(repo => repo.GetAllDoc2sByCondition(true, null)).ReturnsAsync(documents);
            _mockMapper.Setup(mapper => mapper.Map<List<Document2DTO>>(documents)).Returns(documentDTOs);
            _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
            _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

            // Act
            var result = await _controller.GetAllDoc2sWithCondition(true, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Document2DTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("John Doe", returnValue[0].UserFullName);
            Assert.Equal("Jane Smith", returnValue[1].UserFullName);
        }

        [Fact]
        public async Task GetDocument2ByUserSpecialiedDepartment_ReturnsOkResult_WithDocument2sGroupedByDepartment()
        {
            // Arrange
            var documents = new List<object>
            {
                new { id = 1, document = new List<Document2> { new Document2 { Id = 1, UserId = 1, ApproveBy = 2 } } },
                new { id = 2, document = new List<Document2> { new Document2 { Id = 2, UserId = 2, ApproveBy = null } } }
            };

            var documentDTOs = new List<Document2DTO>
            {
                new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2 },
                new Document2DTO { Id = 2, UserId = 2, ApproveBy = null }
            };

            _mockRepository.Setup(repo => repo.GetDocument2ByUserSpecialiedDepartment(It.IsAny<List<int>>())).ReturnsAsync(documents);
            _mockMapper.Setup(mapper => mapper.Map<List<Document2DTO>>(It.IsAny<IEnumerable<Document2>>())).Returns(documentDTOs);

            // Act
            var result = await _controller.GetDocument2ByUserSpecialiedDepartment(new List<int> { 1, 2 });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<object>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetDocument2ById_ReturnsOkResult_WithDocument2DTO()
        {
            // Arrange
            var document = new Document2 { Id = 1, UserId = 1, ApproveBy = 2 };
            var documentDTO = new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2 };
            var user1 = new User { Id = 1, FirstName = "John", LastName = "Doe" };
            var user2 = new User { Id = 2, FirstName = "Jane", LastName = "Smith" };

            _mockRepository.Setup(repo => repo.GetDocument2ById(1)).ReturnsAsync(document);
            _mockMapper.Setup(mapper => mapper.Map<Document2DTO>(document)).Returns(documentDTO);
            _mockUserRepository.Setup(repo => repo.GetUserById(1)).ReturnsAsync(user1);
            _mockUserRepository.Setup(repo => repo.GetUserById(2)).ReturnsAsync(user2);

            // Act
            var result = await _controller.GetDocument2ById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Document2DTO>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
            Assert.Equal("John Doe", returnValue.UserFullName);
            Assert.Equal("Jane Smith", returnValue.ApproveByName);
        }

        [Fact]
        public async Task AddDocument2_ReturnsOkResult_WithCreatedDocument2DTOs()
        {
            // Arrange
            var documentDTOs = new List<Document2DTO>
            {
                new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2 },
                new Document2DTO { Id = 2, UserId = 2, ApproveBy = null }
            };

            var documents = new List<Document2>
            {
                new Document2 { Id = 1, UserId = 1, ApproveBy = 2 },
                new Document2 { Id = 2, UserId = 2, ApproveBy = null }
            };

            _mockMapper.Setup(mapper => mapper.Map<Document2>(documentDTOs[0])).Returns(documents[0]);
            _mockMapper.Setup(mapper => mapper.Map<Document2>(documentDTOs[1])).Returns(documents[1]);
            _mockRepository.Setup(repo => repo.AddDocument2(documents[0])).ReturnsAsync(documents[0]);
            _mockRepository.Setup(repo => repo.AddDocument2(documents[1])).ReturnsAsync(documents[1]);
            _mockMapper.Setup(mapper => mapper.Map<Document2DTO>(documents[0])).Returns(documentDTOs[0]);
            _mockMapper.Setup(mapper => mapper.Map<Document2DTO>(documents[1])).Returns(documentDTOs[1]);

            // Act
            var result = await _controller.AddDocument2(documentDTOs);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Document2DTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task DeleteDocument2_ReturnsNoContent_WhenDocumentExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteDocument2(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteDocument2(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteDocument2_ReturnsNotFound_WhenDocumentDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteDocument2(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteDocument2(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateDocument2_ReturnsOkResult_WithUpdatedDocument2DTO()
        {
            // Arrange
            var documentDTO = new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2 };
            var document = new Document2 { Id = 1, UserId = 1, ApproveBy = 2 };

            _mockMapper.Setup(mapper => mapper.Map<Document2>(documentDTO)).Returns(document);
            _mockRepository.Setup(repo => repo.UpdateDocument2(document)).ReturnsAsync(true);
            _mockMapper.Setup(mapper => mapper.Map<Document2DTO>(document)).Returns(documentDTO);

            // Act
            var result = await _controller.UpdateDocument2(documentDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal("Update Success", returnValue.message);
            Assert.Equal(documentDTO, returnValue.data);
        }

        [Fact]
        public async Task ApproveDocument2_ReturnsOkResult_WithApprovedDocument2DTO()
        {
            // Arrange
            var documentDTO = new Document2DTO { Id = 1, UserId = 1, ApproveBy = 2, Status = true };
            var document = new Document2 { Id = 1, UserId = 1, ApproveBy = 2, Status = true };

            _mockMapper.Setup(mapper => mapper.Map<Document2>(documentDTO)).Returns(document);
            _mockRepository.Setup(repo => repo.UpdateDocument2(document)).ReturnsAsync(true);
            _mockMapper.Setup(mapper => mapper.Map<Document2DTO>(document)).Returns(documentDTO);

            // Act
            var result = await _controller.ApproveDocument2(documentDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal("Update Success", returnValue.message);
            Assert.Equal(documentDTO, returnValue.data);
        }
    }
}
