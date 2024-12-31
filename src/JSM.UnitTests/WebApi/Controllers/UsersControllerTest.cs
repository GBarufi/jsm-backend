using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Core;
using JSM.Application.Dtos.Users;
using JSM.Application.Queries.Users;
using JSM.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace JSM.UnitTests.WebApi.Controllers
{
    public class UsersControllerTest
    {
        private readonly UsersController _controller;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly NotificationHandler _notificationHandler;

        public UsersControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _notificationHandler = new NotificationHandler(new Mock<ILogger<NotificationHandler>>().Object);

            _controller = new UsersController(_mediatorMock.Object, _notificationHandler);
        }

        [Fact]
        public async Task GetUsersList_Ok()
        {
            // Arrange
            var command = new GetUsersQuery();

            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetPaginatedUsersResponse());

            // Act
            var response = await _controller.GetUsersList(command);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task AddUser_Ok()
        {
            // Arrange
            var command = new CreateUsersFromJsonCommand();

            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<CreateUsersFromJsonCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int)default);

            // Act
            var response = await _controller.AddUsers(command);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task AddUser_NotOk()
        {
            // Arrange
            var command = new CreateUsersFromJsonCommand();

            await _notificationHandler.Handle(
                new Notification(NotificationKey.Request, "Invalid request"), new CancellationToken());

            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<CreateUsersFromJsonCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int)default);

            // Act
            var response = await _controller.AddUsers(command);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
