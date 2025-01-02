namespace JSM.Application.Dtos.Users
{
    public record GetUsersResponse
    {
        public required string Type { get; init; }
        public required string Gender { get; init; }
        public required UserName Name { get; init; }
        public required UserLocation Location { get; init; }
        public required string Email { get; init; }
        public required DateTime Birthday { get; init; }
        public required DateTime Registered { get; init; }
        public required string[] TelephoneNumbers { get; init; }
        public required string[] MobileNumbers { get; init; }
        public required UserPicture Picture { get; init; }
        public required string Nationality { get; init; }

        public record UserName
        {
            public required string Title { get; init; }
            public required string First { get; init; }
            public required string Last { get; init; }
        }

        public record UserLocation
        {
            public required string Region { get; init; }
            public required string Street { get; init; }
            public required string City { get; init; }
            public required string State { get; init; }
            public required string PostCode { get; init; }
            public required UserLocationCoordinates Coordinates { get; init; }
            public required UserLocationTimezone Timezone { get; init; }
        }

        public record UserLocationCoordinates
        {
            public required string Latitude { get; init; }
            public required string Longitude { get; init; }
        }

        public record UserLocationTimezone
        {
            public required string Offset { get; init; }
            public required string Description { get; init; }
        }

        public record UserPicture
        {
            public required string Large { get; init; }
            public required string Medium { get; init; }
            public required string Thumbnail { get; init; }
        }
    }
}
