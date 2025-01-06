using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Core.Interfaces;
using JSM.Application.Dtos.Users;
using Moq;

namespace JSM.UnitTests.Tests.Application.Commands.Users
{
    public class CreateUsersFromCsvCommandTest
    {
        private readonly Mock<ICsvHelper> _csvHelperMock = new();

        [Fact]
        public void IsValid_WhenCommandContentIsNull_ShouldReturnFalse()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand();

            // Arrange
            var isValid = command.IsValid(_csvHelperMock.Object);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenCommandContentIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand { Content = [] };

            // Arrange
            var isValid = command.IsValid(_csvHelperMock.Object);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenCsvHelperValidationReturnTrue_ShouldReturnTrue()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand
            {
                Content = Convert.FromBase64String("VmFsaWRCeXRlQXJyYXlDb250ZW50Rm9yVGVzdA==")
            };

            _csvHelperMock.Setup(x => x.ValidateCsv<UserInputDto>(It.IsAny<byte[]>(), It.IsAny<string[]>()))
                .Returns(true);

            // Arrange
            var isValid = command.IsValid(_csvHelperMock.Object);

            // Assert
            _csvHelperMock.Verify(x => x.ValidateCsv<UserInputDto>(It.IsAny<byte[]>(), It.IsAny<string[]>()), Times.Exactly(1));
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenCsvHelperValidationReturnFalse_ShouldReturnFalse()
        {
            // Arrange
            var command = new CreateUsersFromCsvCommand
            {
                Content = Convert.FromBase64String("SW52YWxpZEJ5dGVBcnJheUNvbnRlbnRGb3JUZXN0")
            };

            _csvHelperMock.Setup(x => x.ValidateCsv<UserInputDto>(It.IsAny<byte[]>(), It.IsAny<string[]>()))
                .Returns(false);

            // Arrange
            var isValid = command.IsValid(_csvHelperMock.Object);

            // Assert
            _csvHelperMock.Verify(x => x.ValidateCsv<UserInputDto>(It.IsAny<byte[]>(), It.IsAny<string[]>()), Times.Exactly(1));
            Assert.False(isValid);
        }
    }
}
