using System;
using System.Threading.Tasks;
using GuestHibajelentesEvvegi.Controllers;
using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using GuestHibajelentesEvvegi.Services;
using GuestHibajelentesEvvegi.SignalRHubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GuestHibajelentesEvvegiTesting
{
    public class LinesmanControllerTests
    {
        private readonly AppDbContext _context;
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<IHubContext<ErrorHub>> _mockHubContext;
        private readonly Mock<ILoggingService> _mockLoggingService;
        private readonly LinesmanController _controller;

        public LinesmanControllerTests()
        {
            // Use an in-memory database for testing
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique database for every test
                .Options;

            _context = new AppDbContext(options);

            // Mock dependencies
            _mockUserManager = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            _mockHubContext = new Mock<IHubContext<ErrorHub>>();
            var mockClients = new Mock<IHubClients>();
            var mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);
            _mockHubContext.Setup(hub => hub.Clients).Returns(mockClients.Object);

            _mockLoggingService = new Mock<ILoggingService>();

            // Initialize the controller
            _controller = new LinesmanController(
                _context,
                _mockUserManager.Object,
                _mockHubContext.Object,
                _mockLoggingService.Object
            );
        }

        [Fact]
        public async Task AddNewError_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var model = new AddErrorDto
            {
                description = "Test error",
                submitted_by = "submitter",
                assigned_to = "assignee",
                machine_id = 1
            };

            var submittingUser = new User { Id = "user123", UserName = "submitter" };
            var assignedUser = new User { Id = "user456", UserName = "assignee" };
            var machine = new Machine
            {
                Id = 1,
                status = Status_machine.functional,
                hall = "Hall A",
                name = "Machine 1"
            };

            // Seed data into the in-memory database
            _context.Users.Add(submittingUser);
            _context.Users.Add(assignedUser);
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            _mockUserManager.Setup(um => um.FindByNameAsync("submitter")).ReturnsAsync(submittingUser);
            _mockUserManager.Setup(um => um.FindByNameAsync("assignee")).ReturnsAsync(assignedUser);

            // Act
            var result = await _controller.AddNewError(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = okResult.Value as dynamic;

            Assert.NotNull(response);

            var error = await _context.Errors.FirstOrDefaultAsync();
            Assert.NotNull(error);
            Assert.Equal("Test error", error.description);
            Assert.Equal("user123", error.submitted_by);
            Assert.Equal("user456", error.assigned_to);
        }

        [Fact]
        public async Task GetErrorDetails_ValidId_ReturnsOkResult()
        {
            // Arrange
            var error = new Error
            {
                Id = 1,
                description = "Test error",
                submitted_by = "user123",
                machine_id = 1,
                assigned_to = "user456",
                created_at = DateTime.Now
            };

            var submittingUser = new User { Id = "user123", UserName = "submitter" };
            var assignedUser = new User { Id = "user456", UserName = "assignee" };
            var machine = new Machine
            {
                Id = 1,
                name = "Machine A",
                hall = "Hall A", // Ensure required fields are set
                status = Status_machine.functional
            };

            // Seed data into the in-memory database
            _context.Errors.Add(error);
            _context.Users.Add(submittingUser);
            _context.Users.Add(assignedUser);
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            _mockUserManager.Setup(um => um.FindByIdAsync("user123")).ReturnsAsync(submittingUser);
            _mockUserManager.Setup(um => um.FindByIdAsync("user456")).ReturnsAsync(assignedUser);

            // Act
            var result = await _controller.GetErrorDetails(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = okResult.Value as dynamic;

            Assert.NotNull(response);
        }
    }
}