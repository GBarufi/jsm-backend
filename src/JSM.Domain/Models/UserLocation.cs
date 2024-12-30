using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models.Base;

namespace JSM.Domain.Models
{
    public class UserLocation : EntityBase
    {
        public int UserId { get; private set; }
        public LocationRegion Region { get; private set; }
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string PostCode { get; private set; } = string.Empty;
        public string Latitude { get; private set; } = string.Empty;
        public string Longitude { get; private set; } = string.Empty;
        public string TimezoneOffset { get; private set; } = string.Empty;
        public string TimezoneDescription { get; private set; } = string.Empty;

        private UserLocation() { }

        public UserLocation(
            string street,
            string city,
            string state,
            string postCode,
            string latitude,
            string longitude,
            string timezoneOffset,
            string timezoneDescription)
        {
            Region = StateRegions[state.GetEnumValueFromDisplayName<LocationState>()];
            Street = street;
            City = city;
            State = state;
            PostCode = postCode;
            Latitude = latitude;
            Longitude = longitude;
            TimezoneOffset = timezoneOffset;
            TimezoneDescription = timezoneDescription;
        }

        private Dictionary<LocationState, LocationRegion> StateRegions = new Dictionary<LocationState, LocationRegion>
        {
            { LocationState.RS, LocationRegion.South },
            { LocationState.SC, LocationRegion.South },
            { LocationState.PR, LocationRegion.South },
            { LocationState.SP, LocationRegion.Southeast },
            { LocationState.RJ, LocationRegion.Southeast },
            { LocationState.MG, LocationRegion.Southeast },
            { LocationState.ES, LocationRegion.Southeast },
            { LocationState.BA, LocationRegion.Northeast },
            { LocationState.PE, LocationRegion.Northeast },
            { LocationState.CE, LocationRegion.Northeast },
            { LocationState.RN, LocationRegion.Northeast },
            { LocationState.PB, LocationRegion.Northeast },
            { LocationState.PI, LocationRegion.Northeast },
            { LocationState.AL, LocationRegion.Northeast },
            { LocationState.SE, LocationRegion.Northeast },
            { LocationState.MA, LocationRegion.Northeast },
            { LocationState.MT, LocationRegion.Midwest },
            { LocationState.MS, LocationRegion.Midwest },
            { LocationState.GO, LocationRegion.Midwest },
            { LocationState.DF, LocationRegion.Midwest },
            { LocationState.AM, LocationRegion.North },
            { LocationState.PA, LocationRegion.North },
            { LocationState.RO, LocationRegion.North },
            { LocationState.AC, LocationRegion.North },
            { LocationState.RR, LocationRegion.North },
            { LocationState.AP, LocationRegion.North },
            { LocationState.TO, LocationRegion.North }
        };
    }
}
