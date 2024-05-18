using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_MLD.Controllers;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace ControllerTest;
public class UserControllerTests
{
    private Mock<IUserRepository> _mockRepo;
    private Mock<IMapper> _mockMapper;
    private UserController _controller;

    public UserControllerTests()
    {
        _mockRepo = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new UserController(_mockRepo.Object, _mockMapper.Object);
    }

    // Test cases for GetAllUsers method
    [Fact]
    public async Task GetAllUsers_ReturnsOkResult_WhenUsersExist()
    {
        // Arrange
        var users = new List<User> { new User(), new User() };
        _mockRepo.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOkResult_WithEmptyList_WhenNoUsersExist()
    {
        // Arrange
        var users = new List<User>();
        var userDtos = new List<UserDTO>();
        _mockRepo.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);
        _mockMapper.Setup(mapper => mapper.Map<List<UserDTO>>(It.IsAny<List<User>>())).Returns(userDtos);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Empty(returnValue);
    }


    [Fact]
    public async Task GetAllUsers_ReturnsCorrectType_WhenUsersExist()
    {
        // Arrange
        var users = new List<User> { new User(), new User() };
        _mockRepo.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        Assert.IsAssignableFrom<ActionResult<IEnumerable<UserDTO>>>(result);
    }

    // Test cases for GetUserById method
    [Fact]
    public async Task GetUserById_ReturnsOkResult_WhenUserExists()
    {
        // Arrange
        var user = new User();
        _mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).ReturnsAsync(user);

        // Act
        var result = await _controller.GetUserById(1);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetUserById_ReturnsNotFoundObjectResult_WhenUserDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GetUserById(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetUserById_ReturnsCorrectType_WhenUserExists()
    {
        // Arrange
        var user = new User();
        _mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).ReturnsAsync(user);

        // Act
        var result = await _controller.GetUserById(1);

        // Assert
        Assert.IsAssignableFrom<ActionResult<UserDTO>>(result);
    }

    // Test cases for AddUser method
    [Fact]
    public async Task AddUser_ReturnsOkResult_WhenUserIsAdded()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>())).ReturnsAsync(new User());

        // Act
        var result = await _controller.AddUser(user);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task AddUser_ThrowsException_WhenUserCannotBeAdded()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>())).Throws(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.AddUser(user));
    }

    [Fact]
    public async Task AddUser_ReturnsCorrectType_WhenUserIsAdded()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>())).ReturnsAsync(new User());

        // Act
        var result = await _controller.AddUser(user);

        // Assert
        Assert.IsAssignableFrom<ActionResult<User>>(result);
    }

    // Test cases for UpdateUser method
    [Fact]
    public async Task UpdateUser_ReturnsOkResult_WhenUserIsUpdated()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateUser(user);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ReturnsBadRequestResult_WhenUserCannotBeUpdated()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.UpdateUser(It.IsAny<User>())).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateUser(user);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateUser_ThrowsException_WhenExceptionOccurs()
    {
        // Arrange
        var user = new UserDTO();
        _mockRepo.Setup(repo => repo.UpdateUser(It.IsAny<User>())).Throws(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.UpdateUser(user));
    }

}
