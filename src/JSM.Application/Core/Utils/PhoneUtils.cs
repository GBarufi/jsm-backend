using System.Text.RegularExpressions;

namespace JSM.Application.Core.Utils
{
    public static partial class PhoneUtils
    {
        public static string ConvertToE164(string phoneNumber, string countryCode = "+55")
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return string.Empty;

            if (!IsValidPhoneNumber(phoneNumber))
                return phoneNumber;

            string cleanedNumber = E164Regex().Replace(phoneNumber, string.Empty);

            return $"{countryCode}{cleanedNumber}";
        }

        public static bool IsValidPhoneNumber(string phoneNumber) => ValidPhoneNumberRegex().Match(phoneNumber).Success;

        [GeneratedRegex(@"^\([0-9]{2}\)\ [0-9]{4}[-][0-9]{4}$")]
        private static partial Regex ValidPhoneNumberRegex();

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex E164Regex();
    }
}
