using JSM.Domain.Enums;
using JSM.Domain.Models;
using JSM.UnitTests.Helpers.Fakers;

namespace JSM.UnitTests.Tests.Domain.Models
{
    public class UserPortraitTest
    {
        [Fact]
        public void Constructor_ShouldSetAllPortraitPropertiesCorrectly()
        {
            // Arrange
            var expectedResult = UserPortraitFaker.Generate(UserGender.F);

            // Act
            var portrait = new UserPortrait(expectedResult.Large, expectedResult.Medium, expectedResult.Thumbnail);

            // Assert
            Assert.Equal(expectedResult.Large, portrait.Large);
            Assert.Equal(expectedResult.Medium, portrait.Medium);
            Assert.Equal(expectedResult.Thumbnail, portrait.Thumbnail);
        }
    }
}
