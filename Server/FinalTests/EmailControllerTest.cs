//using Xunit;
//using Moq;
//using Microsoft.AspNetCore.Mvc;
//using Project_MLD.Controllers;
//using Project_MLD.Utils.GenerateCode;
//using Project_MLD.Utils.GmailSender;
//using IEmailSender = Project_MLD.Utils.GmailSender.IEmailSender;
//namespace ControllerTest;
//public class EmailControllerTests
//{
//    [Fact]
//    public async Task SendEmail_ReturnsOkResult_WhenEmailIsSentSuccessfully()
//    {
//        // Arrange
//        var mockEmailSender = new Mock<IEmailSender>();
//        var mockMailBody = new Mock<IMailBody>();
//        var mockGenerateCode = new Mock<IGenerateCode>();
//        var controller = new EmailController(mockEmailSender.Object, mockMailBody.Object, mockGenerateCode.Object);
//        string receiver = "test@example.com";

//        // Act
//        var result = await controller.SendEmail(receiver);

//        // Assert
//        Assert.IsType<OkObjectResult>(result);
//    }

//    [Fact]
//    public async Task SendEmail_ReturnsBadRequestResult_WhenExceptionIsThrown()
//    {
//        // Arrange
//        var mockEmailSender = new Mock<IEmailSender>();
//        var mockMailBody = new Mock<IMailBody>();
//        var mockGenerateCode = new Mock<IGenerateCode>();
//        mockEmailSender.Setup(m => m.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
//        var controller = new EmailController(mockEmailSender.Object, mockMailBody.Object, mockGenerateCode.Object);
//        string receiver = "test@example.com";

//        // Act
//        var result = await controller.SendEmail(receiver);

//        // Assert
//        Assert.IsType<BadRequestObjectResult>(result);
//    }

//    [Fact]
//    public async Task SendEmail_CallsGenerateCodeAndSendEmailAsync_WhenCalled()
//    {
//        // Arrange
//        var mockEmailSender = new Mock<IEmailSender>();
//        var mockMailBody = new Mock<IMailBody>();
//        var mockGenerateCode = new Mock<IGenerateCode>();
//        var controller = new EmailController(mockEmailSender.Object, mockMailBody.Object, mockGenerateCode.Object);
//        string receiver = "test@example.com";

//        // Act
//        await controller.SendEmail(receiver);

//        // Assert
//        mockGenerateCode.Verify(m => m.GenerateRandomCode(), Times.Once);
//        mockEmailSender.Verify(m => m.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
//    }
//}
