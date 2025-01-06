using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Dtos.Users;
using JSM.Persistence.Contexts;
using JSM.UnitTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JSM.UnitTests.Tests.Application.Commands.Users
{
    public class CreateUsersFromJsonCommandHandlerTest
    {
        private readonly CreateUsersFromJsonCommandHandler _handler;

        public CreateUsersFromJsonCommandHandlerTest()
        {
            var _dbContextFactoryMock = new Mock<IDbContextFactory<JsmContext>>();

            _dbContextFactoryMock
                .Setup(x => x.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => JsmContextFactory.CreateInMemory());

            _handler = new CreateUsersFromJsonCommandHandler(_dbContextFactoryMock.Object);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasInformedCorrectly_ShouldCreateUser()
        {
            // Arrange
            var dto = new UserInputDto().PopulateEmptyValuesWithFakeData();
            var command = new CreateUsersFromJsonCommand
            {
                UsersList = [dto]
            };

            // Act
            var response = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, response);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasNotInformedCorrectly_ShouldThrowsException()
        {
            // Arrange
            #pragma warning disable CS8625
            var dto = new UserInputDto { Name = null }.PopulateEmptyValuesWithFakeData();
            #pragma warning restore CS8625

            var command = new CreateUsersFromJsonCommand
            {
                UsersList = [dto]
            };

            // Act
            async Task executeHandler() => await _handler.Handle(command, new CancellationToken());

            // Assert
            await Assert.ThrowsAnyAsync<Exception>(executeHandler);
        }
    }
}
