using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_MLD.Controllers;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    public class CurriculumDistributionControllerTests
    {
        private readonly Mock<ICurriculumDistributionRepository> _mockRepository;
        private readonly CurriculumDistributionController _controller;

        public CurriculumDistributionControllerTests()
        {
            _mockRepository = new Mock<ICurriculumDistributionRepository>();
            _controller = new CurriculumDistributionController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllCurriculumDistributions_ReturnsOkResultWithCurriculumDistributions()
        {
            // Arrange
            var curriculumDistributions = new List<CurriculumDistribution> { new CurriculumDistribution(), new CurriculumDistribution() };
            _mockRepository.Setup(r => r.GetAllCurriculumDistributions()).ReturnsAsync(curriculumDistributions);

            // Act
            var result = await _controller.GetAllCurriculumDistributions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(curriculumDistributions, okResult.Value);
        }

        [Fact]
        public async Task GetCurriculumDistributionById_WithExistingId_ReturnsOkResultWithCurriculumDistribution()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution();
            _mockRepository.Setup(r => r.GetCurriculumDistributionById(It.IsAny<int>())).ReturnsAsync(curriculumDistribution);

            // Act
            var result = await _controller.GetCurriculumDistributionById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(curriculumDistribution, okResult.Value);
        }

        [Fact]
        public async Task GetCurriculumDistributionById_WithNonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetCurriculumDistributionById(It.IsAny<int>())).ReturnsAsync((CurriculumDistribution)null);

            // Act
            var result = await _controller.GetCurriculumDistributionById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddCurriculumDistribution_WithValidCurriculumDistribution_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var curriculumDistribution = new CurriculumDistribution();
            _mockRepository.Setup(r => r.AddCurriculumDistribution(It.IsAny<CurriculumDistribution>())).ReturnsAsync(curriculumDistribution);

            // Act
            var result = await _controller.AddCurriculumDistribution(curriculumDistribution);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(curriculumDistribution, createdAtActionResult.Value);
        }
    }
}
