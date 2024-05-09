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

namespace TestProject2
{
    public class CurriculumDistributionControllerTest
    {
       



        [Fact]
        public async Task GetAllCurriculumDistributions_ShouldReturnOkResult_WhenCurriculumsExist()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);

            // Act
            var result = await controller.GetAllCurriculumDistributions();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetCurriculumDistributionById_ShouldReturnOkResult_WhenCurriculumExists()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);
            int id = 1;

            // Act
            var result = await controller.GetCurriculumDistributionById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetCurriculumDistributionById_ShouldReturnNotFoundResult_WhenCurriculumDoesNotExist()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);
            int id = 1;

            // Act
            var result = await controller.GetCurriculumDistributionById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddCurriculumDistribution_ShouldReturnCreatedAtActionResult_WhenCurriculumIsAddedSuccessfully()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);
            var cd = new CurriculumDistribution();

            // Act
            var result = await controller.AddCurriculumDistribution(cd);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task AddCurriculumDistribution_ShouldReturnBadRequestResult_WhenCurriculumIsNotAdded()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);
            var cd = new CurriculumDistribution();

            // Act
            var result = await controller.AddCurriculumDistribution(cd);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task AddCurriculumDistribution_ShouldReturnBadRequestResult_WhenExceptionIsThrown()
        {
            // Arrange
            var mockRepo = new Mock<ICurriculumDistributionRepository>();
            var controller = new CurriculumDistributionController(mockRepo.Object);
            var cd = new CurriculumDistribution();

            // Act
            var result = await controller.AddCurriculumDistribution(cd);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

    }
}
