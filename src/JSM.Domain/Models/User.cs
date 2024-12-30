using JSM.Domain.Enums;
using JSM.Domain.Models.Base;
using JSM.Domain.Strategies.User;
using System.Globalization;

namespace JSM.Domain.Models
{
    public class User : EntityBase
    {
        public UserType Type { get; private set; }
        public UserGender Gender { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }
        public DateTime Registered { get; private set; }
        public string[] TelephoneNumbers { get; private set; } = [];
        public string[] MobileNumbers { get; private set; } = [];
        public UserNationality Nationality { get; private set; }

        public UserLocation? Location { get; private set; }
        public UserPortrait? Portrait { get; private set; }

        private User() { }

        public User(
            UserGender gender,
            string title,
            string firstName,
            string lastName,
            string email,
            DateTime birthday,
            DateTime registered,
            string telephoneNumber,
            string mobileNumber,
            UserNationality nationality,
            UserLocation location,
            UserPortrait portrait)
        {
            Type = GetTypeAccordingToCoordinates(location.Latitude, location.Longitude);
            Gender = gender;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Registered = registered;
            TelephoneNumbers = [telephoneNumber];
            MobileNumbers = [mobileNumber];
            Nationality = nationality;
            Location = location;
            Portrait = portrait;
        }

        private static UserType GetTypeAccordingToCoordinates(string latitude, string longitude)
        {
            var userTypeStrategies = new List<IUserTypeStrategy> {
                new SpecialUserStrategy(),
                new HardUserStrategy(),
                new NormalUserStrategy()
            };

            foreach (var strategy in userTypeStrategies)
            {
                var parsedLatitude = double.Parse(latitude, CultureInfo.InvariantCulture);
                var parsedLongitude = double.Parse(longitude, CultureInfo.InvariantCulture);

                if (strategy.UserBelongsToType(parsedLatitude, parsedLongitude))
                    return strategy.Type;
            }

            return UserType.Laborious;
        }
    }
}
