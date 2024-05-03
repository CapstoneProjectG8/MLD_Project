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
    private readonly Mock<IUserRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new UserController(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllUser_ReturnsOk()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetAllUsers()).ReturnsAsync(new List<User>());

        // Act
        var result = await _controller.GetAllUser();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetUserById_WithExistingId_ReturnsOk()
    {
        // Arrange
        var id = 1;
        _mockRepository.Setup(r => r.GetUserById(id)).ReturnsAsync(new User());

        // Act
        var result = await _controller.GetUserById(id);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetUserById_WithNonExistingId_ReturnsNotFound()
    {
        // Arrange
        var id = 1;
        _mockRepository.Setup(r => r.GetUserById(id)).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GetUserById(id);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddUser_WithValidUser_ReturnsOk()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1, FirstName = "Test", LastName = "User" };
        _mockRepository.Setup(r => r.AddUser(It.IsAny<User>())).ReturnsAsync(new User());
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(new User());

        // Act
        var result = await _controller.AddUser(userDto);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task UpdateUser_WithMismatchedId_ReturnsBadRequest()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1 };
        var id = 2;

        // Act
        var result = await _controller.UpdateUser(id, userDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateUser_WithValidUser_ReturnsNoContent()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1 };
        var id = 1;
        _mockRepository.Setup(r => r.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(new User());

        // Act
        var result = await _controller.UpdateUser(id, userDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
    [Fact]
    public async Task UpdateUser_WithNonExistingUser_ReturnsNotFound()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1 };
        var id = 1;
        _mockRepository.Setup(r => r.UpdateUser(It.IsAny<User>())).ReturnsAsync(false);
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(new User());

        // Act
        var result = await _controller.UpdateUser(id, userDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_WithExistingUser_ReturnsNoContent()
    {
        // Arrange
        var userDto = new UserDTO { Id = 1 };
        var id = 1;
        _mockRepository.Setup(r => r.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserDTO>())).Returns(new User());

        // Act
        var result = await _controller.UpdateUser(id, userDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

}
