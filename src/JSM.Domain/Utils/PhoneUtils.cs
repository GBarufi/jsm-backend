
using System.Text.RegularExpressions;

namespace JSM.Domain.Utils
{
    public static partial class PhoneUtils
    {
        public static string ConvertToE164(string phoneNumber, string countryCode = "+55")
        {
            string cleanedNumber = E164Regex().Replace(phoneNumber, string.Empty);

            return $"{countryCode}{cleanedNumber}";
        }

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex E164Regex();
    }
}
