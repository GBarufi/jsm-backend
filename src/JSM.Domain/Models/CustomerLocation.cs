using JSM.Domain.Enums;
using JSM.Domain.Models.Base;

namespace JSM.Domain.Models
{
    public class CustomerLocation : EntityBase
    {
        public int CustomerId { get; private set; }
        public LocationRegion Region { get; private set; }
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string PostCode { get; private set; } = string.Empty;
        public string Latitude { get; private set; } = string.Empty;
        public string Longitude { get; private set; } = string.Empty;
        public string TimezoneOffset { get; private set; } = string.Empty;
        public string TimezoneDescription { get; private set; } = string.Empty;

        private CustomerLocation() { }
    }
}
