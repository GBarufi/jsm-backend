using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Dtos.Users;
using JSM.UnitTests.Helpers;

namespace JSM.UnitTests.Tests.Application.Commands.Users
{
    public class CreateUsersFromJsonCommandTest
    {
        [Fact]
        public void IsValid_WhenCommandIsValid_ShouldReturnTrue()
        {
            // Arrange
            var dto = new UserInputDto().PopulateEmptyValuesWithFakeData();
            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Arrange
            var isValid = command.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_WhenCommandIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            var command = new CreateUsersFromJsonCommand();

            // Arrange
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserGenderIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto { Gender = string.Empty }.PopulateEmptyValuesWithFakeData();
            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTitleIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Name = new UserInputDto.UserInputName
                {
                    Title = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserFirstNameIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Name = new UserInputDto.UserInputName
                {
                    First = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLastNameIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Name = new UserInputDto.UserInputName
                {
                    Last = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationStreetIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Street = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationCityIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    City = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationStateIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    State = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationPostCodeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    PostCode = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLatitudeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Coordinates = new UserInputDto.UserInputLocationCoordinates
                    {
                        Latitude = string.Empty
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLatitudeIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Coordinates = new UserInputDto.UserInputLocationCoordinates
                    {
                        Latitude = "InvalidLatitude"
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLongitudeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Coordinates = new UserInputDto.UserInputLocationCoordinates
                    {
                        Longitude = string.Empty
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLongitudeIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Coordinates = new UserInputDto.UserInputLocationCoordinates
                    {
                        Longitude = "InvalidLongitude"
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationTimezoneOffsetIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Timezone = new UserInputDto.UserInputLocationTimezone
                    {
                        Offset = string.Empty
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationTimezoneDescriptionIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Location = new UserInputDto.UserInputLocation
                {
                    Timezone = new UserInputDto.UserInputLocationTimezone
                    {
                        Description = string.Empty
                    }
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserEmailIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto { Email = string.Empty }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserBirthdayIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Dob = new UserInputDto.UserInputDate
                {
                    Date = DateTime.MinValue
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserRegisteredDateIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Registered = new UserInputDto.UserInputDate
                {
                    Date = DateTime.MinValue
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTelephoneNumberIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto { Phone = string.Empty }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserMobileNumberIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto { Cell = string.Empty }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLargePictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Picture = new UserInputDto.UserInputPicture
                {
                    Large = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserMediumPictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Picture = new UserInputDto.UserInputPicture
                {
                    Medium = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserThumbnailPictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var dto = new UserInputDto
            {
                Picture = new UserInputDto.UserInputPicture
                {
                    Thumbnail = string.Empty
                }
            }.PopulateEmptyValuesWithFakeData();

            var command = new CreateUsersFromJsonCommand { UsersList = [dto] };

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }
    }
}
