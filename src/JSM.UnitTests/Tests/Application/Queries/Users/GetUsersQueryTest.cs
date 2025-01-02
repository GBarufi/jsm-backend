using JSM.Application.Queries.Users;

namespace JSM.UnitTests.Tests.Application.Queries.Users
{
    public class GetUsersQueryTest
    {
        [Fact]
        public void IsValid_WhenQueryIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery();

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenSizeIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery { Size = 10 };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenSizeIsZero_ShouldReturnFalse()
        {
            // Arrange
            var command = new GetUsersQuery { Size = 0 };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenPageIsZero_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery { Page = 0 };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenRegionIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery { Region = "South" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenRegionIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = new GetUsersQuery { Region = "Invalid Region" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenStateIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery { State = "RS" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenStateIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = new GetUsersQuery { State = "Invalid State" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTypeIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = new GetUsersQuery { Type = "Laborious" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTypeIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = new GetUsersQuery { Type = "Invalid User Type" };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }
    }
}
