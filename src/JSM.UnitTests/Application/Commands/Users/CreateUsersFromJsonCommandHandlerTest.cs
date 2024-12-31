using JSM.Application.Commands.Users.CreateUser;
using JSM.Persistence.Contexts;
using JSM.UnitTests.Configurations;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JSM.UnitTests.Application.Commands.Users
{
    public class CreateUsersFromJsonCommandHandlerTest
    {
        private readonly CreateUsersFromJsonCommandHandler _handler;

        public CreateUsersFromJsonCommandHandlerTest()
        {
            var _dbContextFactoryMock = new Mock<IDbContextFactory<JsmContext>>();

            _dbContextFactoryMock
                .Setup(x => x.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(JsmContextFactory.CreateInMemory);

            _handler = new CreateUsersFromJsonCommandHandler(_dbContextFactoryMock.Object);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasInformedCorrectly_ShouldCreateUser()
        {
            // Arrange
            var command = CreateUsersFromJsonCommandTest.GenerateCommandFromFakeModel();

            // Act
            var response = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, response);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasNotInformedCorrectly_ShouldThrowsException()
        {
            // Arrange
            var command = CreateUsersFromJsonCommandTest.GenerateCommandFromFakeModel(validGender: false);

            // Act
            async Task executeHandler() => await _handler.Handle(command, new CancellationToken());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(executeHandler);
        }
    }
}
