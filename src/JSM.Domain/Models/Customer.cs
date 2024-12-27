using JSM.Domain.Enums;
using JSM.Domain.Models.Base;
using JSM.Domain.Strategies.Customer;
using System.Globalization;

namespace JSM.Domain.Models
{
    public class Customer : EntityBase
    {
        public CustomerType Type { get; private set; }
        public CustomerGender Gender { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }
        public DateTime Registered { get; private set; }
        public string[] TelephoneNumber { get; private set; } = [];
        public string[] MobileNumber { get; private set; } = [];
        public CustomerNationality Nationality { get; private set; }

        public CustomerLocation? Location { get; private set; }
        public CustomerPortrait? Portrait { get; private set; }

        private Customer() { }

        public Customer(
            CustomerGender gender, 
            string title, 
            string firstName, 
            string lastName, 
            string email, 
            DateTime birthday, 
            DateTime registered, 
            string telephoneNumber, 
            string mobileNumber, 
            CustomerNationality nationality, 
            CustomerLocation location, 
            CustomerPortrait portrait)
        {
            Type = GetTypeAccordingToCoordinates(location.Latitude, location.Longitude);
            Gender = gender;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Registered = registered;
            TelephoneNumber = [telephoneNumber];
            MobileNumber = [mobileNumber];
            Nationality = nationality;
            Location = location;
            Portrait = portrait;
        }

        private CustomerType GetTypeAccordingToCoordinates(string latitude, string longitude)
        {
            var customerTypeStrategies = new List<ICustomerTypeStrategy> {
                new SpecialCustomerStrategy(),
                new HardCustomerStrategy(),
                new NormalCustomerStrategy()
            };

            foreach (var strategy in customerTypeStrategies)
            {
                var parsedLatitude = double.Parse(latitude, CultureInfo.InvariantCulture);
                var parsedLongitude = double.Parse(longitude, CultureInfo.InvariantCulture);

                if (strategy.CustomerBelongsToType(parsedLatitude, parsedLongitude))
                    return strategy.Type;
            }

            return CustomerType.Laborious;
        }
    }
}
