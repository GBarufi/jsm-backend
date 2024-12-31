using JSM.Application.Commands.Users.CreateUser;
using JSM.Domain.Extensions;
using JSM.UnitTests.Helpers.Fakers;
using static JSM.Application.Dtos.Users.UserInputDto;

namespace JSM.UnitTests.Tests.Application.Commands.Users
{
    public class CreateUsersFromJsonCommandTest
    {
        [Fact]
        public void IsValid_WhenCommandIsValid_ShouldReturnTrue()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel();

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
            var command = GenerateCommandFromFakeModel(validGender: false);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTitleIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(title: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserFirstNameIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(firstName: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLastNameIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(lastName: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationStreetIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(street: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationCityIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(city: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationStateIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(validState: false);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationPostCodeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(postCode: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLatitudeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(latitude: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLatitudeIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(latitude: "InvalidLatitude");

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLongitudeIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(longitude: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationLongitudeIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(longitude: "InvalidLongitude");

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationTimezoneOffsetIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(timezoneOffset: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLocationTimezoneDescriptionIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(timezoneDesc: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserEmailIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(email: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserBirthdayIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(birthday: DateTime.MinValue);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserRegisteredDateIsInvalid_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(registered: DateTime.MinValue);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserTelephoneNumberIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(telephoneNumber: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserMobileNumberIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(mobileNumber: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserLargePictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(largePicture: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserMediumPictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(mediumPicture: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenUserThumbnailPictureIsNotInformed_ShouldReturnFalse()
        {
            // Arrange
            var command = GenerateCommandFromFakeModel(thumbnailPicture: string.Empty);

            // Act
            var isValid = command.IsValid();

            // Assert
            Assert.False(isValid);
        }

        internal static CreateUsersFromJsonCommand GenerateCommandFromFakeModel(
            bool validGender = true,
            string? title = null,
            string? firstName = null,
            string? lastName = null,
            string? street = null,
            string? city = null,
            bool validState = true,
            string? postCode = null,
            string? latitude = null,
            string? longitude = null,
            string? timezoneOffset = null,
            string? timezoneDesc = null,
            string? email = null,
            DateTime? birthday = null,
            DateTime? registered = null,
            string? telephoneNumber = null,
            string? mobileNumber = null,
            string? largePicture = null,
            string? mediumPicture = null,
            string? thumbnailPicture = null)
        {
            var model = UserFaker.Generate();

            return new CreateUsersFromJsonCommand
            {
                UsersList = [
                    new() {
                        Gender = validGender ? model.Gender.GetDisplayName() : null,
                        Name = new UserInputName
                        {
                            Title = title is not null ? title : model.Title,
                            First = firstName is not null ? firstName : model.FirstName,
                            Last = lastName is not null ? lastName : model.LastName
                        },
                        Location = new UserInputLocation
                        {
                            Street = street is not null ? street : model.Location!.Street,
                            City = city is not null ? city : model.Location!.City,
                            State = validState ? model.Location!.State : null,
                            PostCode = postCode is not null ? postCode : model.Location!.PostCode,
                            Coordinates = new UserInputLocationCoordinates {
                                Latitude = latitude is not null ? latitude : model.Location!.Latitude,
                                Longitude = longitude is not null ? longitude : model.Location!.Longitude
                            },
                            Timezone = new UserInputLocationTimezone {
                                Offset = timezoneOffset is not null ? timezoneOffset : model.Location!.TimezoneOffset,
                                Description = timezoneDesc is not null ? timezoneDesc : model.Location!.TimezoneDescription
                            }
                        },
                        Email = email is not null ? email : model.Email,
                        Dob = new UserInputDate {
                            Date = birthday is not null ? birthday : model.Birthday,
                            Age = 30
                        },
                        Registered = new UserInputDate {
                            Date = registered is not null ? registered : model.Registered,
                            Age = 30
                        },
                        Phone = telephoneNumber is not null ? telephoneNumber : model.TelephoneNumbers.First(),
                        Cell = mobileNumber is not null ? mobileNumber : model.TelephoneNumbers.First(),
                        Picture = new UserInputPicture {
                            Large = largePicture is not null ? largePicture : model.Portrait!.Large,
                            Medium = mediumPicture is not null ? mediumPicture : model.Portrait!.Medium,
                            Thumbnail = thumbnailPicture is not null ? thumbnailPicture : model.Portrait!.Thumbnail
                        }
                    }
                ]
            };
        }
    }
}
