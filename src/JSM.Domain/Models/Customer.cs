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
        public string[] TelephoneNumbers { get; private set; } = [];
        public string[] MobileNumbers { get; private set; } = [];
        public CustomerNationality Nationality { get; private set; }

        public CustomerLocation? Location { get; private set; }
        public CustomerPortrait? Portrait { get; private set; }

        private Customer() { }
    }
}
