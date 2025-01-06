using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Core.Interfaces;
using JSM.Application.Dtos.Users;
using JSM.Application.Mappers.Users;
using JSM.Persistence.Contexts;
using JSM.UnitTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace JSM.UnitTests.Tests.Application.Commands.Users
{
    public class CreateUsersFromCsvCommandHandlerTest
    {
        private readonly CreateUsersFromCsvCommandHandler _handler;
        private readonly Mock<ICsvHelper> _csvHelperMock = new();

        public CreateUsersFromCsvCommandHandlerTest()
        {
            var _dbContextFactoryMock = new Mock<IDbContextFactory<JsmContext>>();

            _dbContextFactoryMock
                .Setup(x => x.CreateDbContextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => JsmContextFactory.CreateInMemory());

            _handler = new CreateUsersFromCsvCommandHandler(_dbContextFactoryMock.Object, _csvHelperMock.Object);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasInformedCorrectly_ShouldCreateUser()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand { Content = Convert.FromBase64String("VmFsaWRCeXRlQXJyYXlDb250ZW50Rm9yVGVzdA==") };
            var dto = new UserInputDto().PopulateEmptyValuesWithFakeData();

            _csvHelperMock.Setup(x => x.ImportCsv<UserInputDto, UserCsvMapper>(It.IsAny<byte[]>()))
                .Returns(() => [dto]);

            // Act
            var response = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, response);
        }

        [Fact]
        public async Task Handle_WhenUserDataWasNotInformedCorrectly_ShouldThrowsException()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand { Content = Convert.FromBase64String("SW52YWxpZEJ5dGVBcnJheUNvbnRlbnRGb3JUZXN0") };

            #pragma warning disable CS8625
            var dto = new UserInputDto { Name = null }.PopulateEmptyValuesWithFakeData();
            #pragma warning restore CS8625

            _csvHelperMock.Setup(x => x.ImportCsv<UserInputDto, UserCsvMapper>(It.IsAny<byte[]>()))
                .Returns(() => [dto]);

            // Act
            async Task executeHandler() => await _handler.Handle(command, new CancellationToken());

            // Assert
            await Assert.ThrowsAnyAsync<Exception>(executeHandler);
        }
    }
}
