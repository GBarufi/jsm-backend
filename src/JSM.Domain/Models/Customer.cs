using JSM.Domain.Enums;
using JSM.Domain.Models.Base;

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
        public string TelephoneNumber { get; private set; } = string.Empty;
        public string MobileNumber { get; private set; } = string.Empty;
        public CustomerNationality Nationality { get; private set; }

        public CustomerLocation? Location { get; private set; }
        public CustomerPortrait? Portrait { get; private set; }

        private Customer() { }

        public Customer(
            CustomerType type, 
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
            Type = type;
            Gender = gender;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Registered = registered;
            TelephoneNumber = telephoneNumber;
            MobileNumber = mobileNumber;
            Nationality = nationality;
            Location = location;
            Portrait = portrait;
        }
    }
}
