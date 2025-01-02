using JSM.Domain.Enums;
using JSM.Domain.Extensions;

namespace JSM.UnitTests.Tests.Domain.Extensions
{
    public class EnumExtensionTest
    {
        [Fact]
        public void GetEnumValueFromDisplayName_WhenEnumNameExists_ShouldReturnDisplayName()
        {
            //Arrange
            var expectedResult = LocationState.RS;

            //Act
            var result = "Rio Grande do Sul".GetEnumValueFromDisplayName<LocationState>();

            //Assert
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void GetEnumValueFromDisplayName_WhenEnumNameDoesNotExists_ShouldReturnZero()
        {
            //Arrange
            LocationState expectedResult = 0;

            //Act
            var result = "Invalid State".GetEnumValueFromDisplayName<LocationState>();

            //Assert
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void GetDisplayName_WhenDisplayNameIsDefined_ShouldReturnDisplayName()
        {
            //Arrange
            var enumValue = LocationState.RS;
            var expectedResult = "Rio Grande do Sul";

            //Act
            var result = enumValue.GetDisplayName();

            //Assert
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void GetDisplayName_WhenDisplayNameIsNotDefined_ShouldReturnEmptyString()
        {
            //Arrange
            var enumValue = LocationRegion.South;
            var expectedResult = string.Empty;

            //Act
            var result = enumValue.GetDisplayName();

            //Assert
            Assert.Equal(result, expectedResult);
        }
    }
}
