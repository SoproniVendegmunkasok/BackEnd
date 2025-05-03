using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using GuestHibajelentesEvvegi.Controllers;
using GuestHibajelentesEvvegi.Models;
using GuestHibajelentesEvvegi.Services;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.SignalRHubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GuestHibajelentesEvvegiTesting
{
    public class UserControllerTests
    {
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<SignInManager<User>> _mockSignInManager;
        private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AppDbContext _mockContext;
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly Mock<IHubContext<ErrorHub>> _mockHubContext;

        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockUserManager = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),
                null, null, null, null, null, null, null, null);

            _mockSignInManager = new Mock<SignInManager<User>>(
                _mockUserManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                null, null, null, null);

            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null, null, null, null);

            _mockConfiguration = new Mock<IConfiguration>();
            _mockMapper = new Mock<IMapper>();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _mockContext = new AppDbContext(options);
            _mockContext.Database.EnsureDeleted(); 
            _mockContext.Database.EnsureCreated();

            _mockContext.Users.Add(new User { Id = "user123", UserName = "testuser" });
            _mockContext.SaveChanges();

            _mockAuthService = new Mock<IAuthService>();
            _mockAuthService.Setup(auth => auth.GenerateTokens(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
                .Returns(("access_token", "refresh_token"));

            _mockHubContext = new Mock<IHubContext<ErrorHub>>();

            _controller = new UserController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockRoleManager.Object,
                _mockConfiguration.Object,
                _mockMapper.Object,
                _mockContext,
                _mockAuthService.Object,
                _mockHubContext.Object
            );
        }

        [Fact]
        public async Task LoginUser_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Username = "testuser",
                Password = "Test@123"
            };

            var user = new User
            {
                Id = "user123",
                UserName = loginModel.Username
            };

            _mockUserManager.Setup(um => um.FindByNameAsync(loginModel.Username))
                .ReturnsAsync(user);

            _mockUserManager.Setup(um => um.CheckPasswordAsync(user, loginModel.Password))
                .ReturnsAsync(true);

            _mockUserManager.Setup(um => um.GetRolesAsync(user))
                .ReturnsAsync(new[] { "User" });

            var mockHttpContext = new Mock<HttpContext>();
            var mockResponse = new Mock<HttpResponse>();
            var mockCookies = new Mock<IResponseCookies>();

            mockCookies.Setup(c => c.Append(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CookieOptions>()));
            mockResponse.Setup(r => r.Cookies).Returns(mockCookies.Object);
            mockHttpContext.Setup(c => c.Response).Returns(mockResponse.Object);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext.Object
            };

            // Act
            var result = await _controller.LoginUser(loginModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task LoginUser_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Username = "testuser",
                Password = "WrongPassword"
            };

            var user = new User { UserName = loginModel.Username };

            _mockUserManager.Setup(um => um.FindByNameAsync(loginModel.Username)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.CheckPasswordAsync(user, loginModel.Password)).ReturnsAsync(false);

            // Act
            var result = await _controller.LoginUser(loginModel);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task LoginUser_UserNotFound_ReturnsUnauthorizedResult()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Username = "nonexistentuser",
                Password = "Test@123"
            };

            _mockUserManager.Setup(um => um.FindByNameAsync(loginModel.Username)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.LoginUser(loginModel);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}