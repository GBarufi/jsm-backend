using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Core.Interfaces;
using JSM.Application.Dtos.Users;
using JSM.Domain.Extensions;
using JSM.UnitTests.Helpers.Fakers;
using Moq;
using static JSM.Application.Dtos.Users.UserInputDto;

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

        internal static UserInputDto GenerateUserInputDto(bool missingProperty = false, bool missingValue = false)
        {
            var model = UserFaker.Generate();

            if (missingProperty)
            {
                //DTO without the 'Location' property
                return new UserInputDto
                {
                    Gender = missingProperty ? null : model.Gender.GetDisplayName(),
                    Name = new UserInputName
                    {
                        Title = model.Title,
                        First = model.FirstName,
                        Last = model.LastName,
                    },
                    Email = model.Email,
                    Dob = new UserInputDate
                    {
                        Date = model.Birthday,
                        Age = 30
                    },
                    Registered = new UserInputDate
                    {
                        Date = model.Registered,
                        Age = 30
                    },
                    Phone = model.TelephoneNumbers.First(),
                    Cell = model.MobileNumbers.First(),
                    Picture = new UserInputPicture
                    {
                        Large = model.Portrait!.Large,
                        Medium = model.Portrait!.Medium,
                        Thumbnail = model.Portrait!.Thumbnail
                    }
                };
            }

            return new UserInputDto
            {
                Gender = missingProperty ? null : model.Gender.GetDisplayName(),
                Name = new UserInputName
                {
                    Title = model.Title,
                    First = missingValue ? string.Empty : model.FirstName,
                    Last = missingValue ? string.Empty : model.LastName,
                },
                Location = new UserInputLocation
                {
                    Street = model.Location!.Street,
                    City = model.Location!.City,
                    State = model.Location!.State,
                    PostCode = model.Location!.PostCode,
                    Coordinates = new UserInputLocationCoordinates
                    {
                        Latitude = model.Location!.Latitude,
                        Longitude = model.Location!.Longitude
                    },
                    Timezone = new UserInputLocationTimezone
                    {
                        Offset = model.Location!.TimezoneOffset,
                        Description = model.Location!.TimezoneDescription
                    }
                },
                Email = model.Email,
                Dob = new UserInputDate
                {
                    Date = model.Birthday,
                    Age = 30
                },
                Registered = new UserInputDate
                {
                    Date = model.Registered,
                    Age = 30
                },
                Phone = model.TelephoneNumbers.First(),
                Cell = model.MobileNumbers.First(),
                Picture = new UserInputPicture
                {
                    Large = model.Portrait!.Large,
                    Medium = model.Portrait!.Medium,
                    Thumbnail = model.Portrait!.Thumbnail
                }
            };
        }
    }
}
