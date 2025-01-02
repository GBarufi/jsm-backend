using JSM.Domain.Enums;
using JSM.Domain.Models;
using JSM.UnitTests.Helpers.Fakers;

namespace JSM.UnitTests.Tests.Domain.Models
{
    public class UserTest
    {
        [Fact]
        public void Constructor_ShouldSetAllUserPropertiesCorrectly()
        {
            // Arrange
            var expectedResult = UserFaker.Generate();

            // Act
            var user = new User(
                expectedResult.Gender,
                expectedResult.Title,
                expectedResult.FirstName,
                expectedResult.LastName,
                expectedResult.Email,
                expectedResult.Birthday,
                expectedResult.Registered,
                expectedResult.TelephoneNumbers.First(),
                expectedResult.MobileNumbers.First(),
                expectedResult.Nationality,
                expectedResult.Location!,
                expectedResult.Portrait!
            );

            // Assert
            Assert.Equal(expectedResult.Gender, user.Gender);
            Assert.Equal(expectedResult.Title, user.Title);
            Assert.Equal(expectedResult.FirstName, user.FirstName);
            Assert.Equal(expectedResult.LastName, user.LastName);
            Assert.Equal(expectedResult.Email, user.Email);
            Assert.Equal(expectedResult.Birthday, user.Birthday);
            Assert.Equal(expectedResult.Registered, user.Registered);

            Assert.Single(user.TelephoneNumbers);
            Assert.Equal(expectedResult.TelephoneNumbers.First(), user.TelephoneNumbers.First());

            Assert.Single(user.MobileNumbers);
            Assert.Equal(expectedResult.MobileNumbers.First(), user.MobileNumbers.First());

            Assert.Equal(expectedResult.Nationality, user.Nationality);
            Assert.Equal(expectedResult.Location, user.Location);
            Assert.Equal(expectedResult.Portrait, user.Portrait);
        }

        [Fact]
        public void Constructor_WhenCoordinatesMatchAUserOfNormalType_ShouldSetUserTypeToNormal()
        {
            // Arrange
            var latitude = "-54.7774";
            var longitude = "-34.0164";

            // Act
            var normalTypeUser = GenerateUserWithPredefinedCoordinates(latitude, longitude);

            // Assert
            Assert.Equal(UserType.Normal, normalTypeUser.Type);
        }

        [Fact]
        public void Constructor_WhenCoordinatesMatchAUserOfHardType_ShouldSetUserTypeToHard()
        {
            // Arrange
            var latitude = "-52.9976";
            var longitude = "-23.9664";

            // Act
            var hardTypeUser = GenerateUserWithPredefinedCoordinates(latitude, longitude);

            // Assert
            Assert.Equal(UserType.Hard, hardTypeUser.Type);
        }

        [Fact]
        public void Constructor_WhenCoordinatesMatchAUserOfSpecialType_ShouldSetUserTypeToSpecial()
        {
            // Arrange
            var latitude = "-46.3618";
            var longitude = "-15.4115";

            // Act
            var specialTypeUser = GenerateUserWithPredefinedCoordinates(latitude, longitude);

            // Assert
            Assert.Equal(UserType.Special, specialTypeUser.Type);
        }

        [Fact]
        public void Constructor_WhenCoordinatesDoNotMatchAnyUserType_ShouldSetUserTypeToLaborious()
        {
            // Arrange
            var latitude = "-46.9519";
            var longitude = "-57.4496";

            // Act
            var laboriousTypeUser = GenerateUserWithPredefinedCoordinates(latitude, longitude);

            // Assert
            Assert.Equal(UserType.Laborious, laboriousTypeUser.Type);
        }

        private static User GenerateUserWithPredefinedCoordinates(string latitude, string longitude)
        {
            var model = UserFaker.Generate();

            return new User(
                model.Gender,
                model.Title,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Birthday,
                model.Registered,
                model.TelephoneNumbers.First(),
                model.MobileNumbers.First(),
                model.Nationality,
                new UserLocation(
                    model.Location!.Street,
                    model.Location!.City,
                    model.Location!.State,
                    model.Location!.PostCode,
                    latitude,
                    longitude,
                    model.Location!.TimezoneOffset,
                    model.Location!.TimezoneDescription
                ),
                model.Portrait!
            );
        }
    }
}
