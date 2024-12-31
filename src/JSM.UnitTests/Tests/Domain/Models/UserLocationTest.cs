using JSM.Domain.Enums;
using JSM.Domain.Models;
using JSM.UnitTests.Helpers.Fakers;

namespace JSM.UnitTests.Tests.Domain.Models
{
    public class UserLocationTest
    {
        [Fact]
        public void Constructor_ShouldSetAllLocationPropertiesCorrectly()
        {
            // Arrange
            var expectedResult = UserLocationFaker.Generate();

            // Act
            var userLocation = new UserLocation(
                expectedResult.Street,
                expectedResult.City,
                expectedResult.State,
                expectedResult.PostCode,
                expectedResult.Latitude,
                expectedResult.Longitude,
                expectedResult.TimezoneOffset,
                expectedResult.TimezoneDescription
            );

            // Assert
            Assert.Equal(expectedResult.Street, userLocation.Street);
            Assert.Equal(expectedResult.City, userLocation.City);
            Assert.Equal(expectedResult.State, userLocation.State);
            Assert.Equal(expectedResult.PostCode, userLocation.PostCode);
            Assert.Equal(expectedResult.Latitude, userLocation.Latitude);
            Assert.Equal(expectedResult.Longitude, userLocation.Longitude);
            Assert.Equal(expectedResult.TimezoneOffset, userLocation.TimezoneOffset);
            Assert.Equal(expectedResult.TimezoneDescription, userLocation.TimezoneDescription);
        }

        [Fact]
        public void Constructor_WhenStateBelongsToSouthRegion_ShouldSetLocationRegionToSouth()
        {
            // Arrange
            var state = "Rio Grande do Sul";

            // Act
            var southRegionLocation = GenerateLocationWithPredefinedState(state);

            // Assert
            Assert.Equal(LocationRegion.South, southRegionLocation.Region);
        }

        [Fact]
        public void Constructor_WhenStateBelongsToSoutheastRegion_ShouldSetLocationRegionToSoutheast()
        {
            // Arrange
            var state = "São Paulo";

            // Act
            var southeastRegionLocation = GenerateLocationWithPredefinedState(state);

            // Assert
            Assert.Equal(LocationRegion.Southeast, southeastRegionLocation.Region);
        }

        [Fact]
        public void Constructor_WhenStateBelongsToNortheastRegion_ShouldSetLocationRegionToNortheast()
        {
            // Arrange
            var state = "Bahia";

            // Act
            var northeastRegionLocation = GenerateLocationWithPredefinedState(state);

            // Assert
            Assert.Equal(LocationRegion.Northeast, northeastRegionLocation.Region);
        }

        [Fact]
        public void Constructor_WhenStateBelongsToMidwestRegion_ShouldSetLocationRegionToMidwest()
        {
            // Arrange
            var state = "Mato Grosso";

            // Act
            var midwestRegionLocation = GenerateLocationWithPredefinedState(state);

            // Assert
            Assert.Equal(LocationRegion.Midwest, midwestRegionLocation.Region);
        }

        [Fact]
        public void Constructor_WhenStateBelongsToNorthRegion_ShouldSetLocationRegionToNorth()
        {
            // Arrange
            var state = "Amazonas";

            // Act
            var northRegionLocation = GenerateLocationWithPredefinedState(state);

            // Assert
            Assert.Equal(LocationRegion.North, northRegionLocation.Region);
        }

        internal static UserLocation GenerateLocationWithPredefinedState(string state)
        {
            var model = UserLocationFaker.Generate();

            return new UserLocation(
                model.Street,
                model.City,
                state,
                model.PostCode,
                model.Latitude,
                model.Longitude,
                model.TimezoneOffset,
                model.TimezoneDescription
            );
        }
    }
}
