using JSM.Application.Core.Utils;

namespace JSM.UnitTests.Tests.Application.Core.Utils
{
    public class PhoneUtilsTest
    {
        [Fact]
        public void ConvertToE164_ShouldReturnFormattedNumber()
        {
            // Arrange
            var phone = "(11) 9999-9999";

            // Arrange
            var result = PhoneUtils.ConvertToE164(phone);

            // Assert
            Assert.Equal("+551199999999", result);
        }

        [Fact]
        public void ConvertToE164_WhenReceiveCountryCodeParam_ShouldReturnFormattedNumberWithInformedPrefix()
        {
            // Arrange
            var phone = "(11) 9999-9999";

            // Arrange
            var result = PhoneUtils.ConvertToE164(phone, "+99");

            // Assert
            Assert.Equal("+991199999999", result);
        }

        [Theory]
        [InlineData("11 9999-9999")]
        [InlineData("(11) 99999999")]
        [InlineData("(11) 9999-99999")]
        [InlineData("(11) 99999-9999")]
        [InlineData("(999) 9999-9999")]
        [InlineData("9999999999")]
        [InlineData("invalidPhoneNumber")]
        public void ConvertToE164_WhenReceiveInvalidPhone_ShouldReturnPhoneItself(string phoneNumber)
        {
            // Arrange
            var phone = phoneNumber;

            // Arrange
            var result = PhoneUtils.ConvertToE164(phone);

            // Assert
            Assert.Equal(phone, result);
        }

        [Fact]
        public void ConvertToE164_WhenReceiveEmptyString_ShouldDoNothing()
        {
            // Arrange
            var phone = string.Empty;

            // Arrange
            var result = PhoneUtils.ConvertToE164(phone);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ConvertToE164_WhenReceiveNull_ShouldDoNothing()
        {
            // Arrange
            string? phone = null;

            // Arrange
            var result = PhoneUtils.ConvertToE164(phone!);

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}
