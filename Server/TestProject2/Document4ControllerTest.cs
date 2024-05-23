using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Controllers;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControllerTest
{

        public class Document4ControllerTests
        {
            private readonly Mock<IDocument4Repository> _mockRepository;
            private readonly Mock<IMapper> _mockMapper;
            private readonly Mock<INotificationRepository> _mockNotificationRepository;
            private readonly Mock<IUserRepository> _mockUserRepository;
            private readonly Document4Controller _controller;

            public Document4ControllerTests()
            {
                _mockRepository = new Mock<IDocument4Repository>();
                _mockMapper = new Mock<IMapper>();
                _mockNotificationRepository = new Mock<INotificationRepository>();
                _mockUserRepository = new Mock<IUserRepository>();

                _controller = new Document4Controller(
                    _mockRepository.Object,
                    _mockMapper.Object,
                    _mockNotificationRepository.Object,
                    _mockUserRepository.Object
                );
            }


            [Fact]
            public async Task GetAllDocument4s_ReturnsOkResult_WithListOfDocument4DTO()
            {
                // Arrange
                var documentList = new List<Document4> { new Document4(), new Document4() };
                var documentDtoList = new List<Document4DTO> { new Document4DTO(), new Document4DTO() };

                _mockRepository.Setup(repo => repo.GetAllDocument4s()).ReturnsAsync(documentList);

                _mockMapper.Setup(mapper => mapper.Map<List<Document4DTO>>(It.IsAny<List<Document4>>())).Returns(documentDtoList);

                // Act
                var result = await _controller.GetAllDocument4s();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<Document4DTO>>(okResult.Value);
                Assert.Equal(2, returnValue.Count);
            }

            [Fact]
            public async Task GetDocument4ByUserSpecialiedDepartment_ReturnsOkResult_WithModifiedDocuments()
            {
                // Arrange
                var documentList = new List<object>
            {
                new { SpecializedDepartmentId = 1, Document4s = new List<Document4> { new Document4(), new Document4() } }
            };
                var documentDtoList = new List<Document4DTO> { new Document4DTO(), new Document4DTO() };

                _mockRepository.Setup(repo => repo.GetDocument4ByUserSpecialiedDepartment(It.IsAny<List<int>>())).ReturnsAsync(documentList);
                _mockMapper.Setup(mapper => mapper.Map<List<Document4DTO>>(It.IsAny<List<Document4>>())).Returns(documentDtoList);

                // Act
                var result = await _controller.GetDocument4ByUserSpecialiedDepartment(new List<int> { 1 });

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<object>>(okResult.Value);
                Assert.Single(returnValue);
            }

            [Fact]
            public async Task GetDoc4ById_ReturnsOkResult_WithDocument4()
            {
                // Arrange
                var document = new Document4 { Id = 1 };

                _mockRepository.Setup(repo => repo.GetDocument4ById(It.IsAny<int>())).ReturnsAsync(document);

                // Act
                var result = await _controller.GetDocument4ById(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<Document4>(okResult.Value);
                Assert.Equal(1, returnValue.Id);
            }

            [Fact]
            public async Task GetDocument4sWithCondition_ReturnsOkResult_WithListOfDocument4DTO()
            {
                // Arrange
                var documentList = new List<Document4> { new Document4(), new Document4() };
                var documentDtoList = new List<Document4DTO> { new Document4DTO(), new Document4DTO() };

                _mockRepository.Setup(repo => repo.GetDocument4sWithCondition(It.IsAny<bool?>(), It.IsAny<int?>())).ReturnsAsync(documentList);
                _mockMapper.Setup(mapper => mapper.Map<List<Document4DTO>>(It.IsAny<List<Document4>>())).Returns(documentDtoList);

                // Act
                var result = await _controller.GetDocument4sWithCondition(true, 1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<Document4DTO>>(okResult.Value);
                Assert.Equal(2, returnValue.Count);
            }

            [Fact]
            public async Task AddDocument4_ReturnsOkResult_WithCreatedDocument4DTO()
            {
                // Arrange
                var documentDto = new Document4DTO { Id = 1 };
                var document = new Document4 { Id = 1 };

                _mockMapper.Setup(mapper => mapper.Map<Document4>(It.IsAny<Document4DTO>())).Returns(document);
                _mockRepository.Setup(repo => repo.AddDocument4(It.IsAny<Document4>())).ReturnsAsync(document);
                _mockMapper.Setup(mapper => mapper.Map<Document4DTO>(It.IsAny<Document4>())).Returns(documentDto);

                // Act
                var result = await _controller.AddDocument4(documentDto);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<Document4DTO>(okResult.Value);
                Assert.Equal(1, returnValue.Id);
            }

            //[Fact]
            //public async Task DeleteDocument4_ReturnsNoContentResult_WhenDocumentExists()
            //{
            //    Arrange
            //    _mockRepo.Setup(repo => repo.DeleteDocument4(It.IsAny<int>())).ReturnsAsync(true);
            //    _mockNotificationRepo.Setup(repo => repo.DeleteNotification(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.CompletedTask);

            //    Act
            //   var result = await _controller.DeleteDocument4(1);

            //    Assert
            //    Assert.IsType<NoContentResult>(result);
            //}

            [Fact]
            public async Task UpdateDocument4_ReturnsOkResult_WithUpdatedDocument4()
            {
                // Arrange
                var documentDto = new Document4DTO { Id = 1 };
                var document = new Document4 { Id = 1 };

                _mockMapper.Setup(mapper => mapper.Map<Document4>(It.IsAny<Document4DTO>())).Returns(document);
                _mockRepository.Setup(repo => repo.UpdateDocument4(It.IsAny<Document4>())).ReturnsAsync(true);

                // Act
                var result = await _controller.UpdateDocument4(documentDto);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<object>(okResult.Value);
                Assert.Contains("Update Success", returnValue.ToString());
            }

            [Fact]
            public async Task GetDoc4InformationByDoc4Id_ReturnsOkResult_WithDocument4()
            {
                // Arrange
                var document = new Document4 { Id = 1 };

                _mockRepository.Setup(repo => repo.GetDoc4InformationByDoc4Id(It.IsAny<int>())).ReturnsAsync(document);

                // Act
                var result = await _controller.GetDoc4InformationByDoc4Id(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<Document4>(okResult.Value);
                Assert.Equal(1, returnValue.Id);
            }
        }
    }
