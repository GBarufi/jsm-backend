namespace JSM.Application.Dtos.Customers
{
    public record GetCustomersResponse
    {
        public required string Type { get; init; }
        public required string Gender { get; init; }
        public required CustomerName Name { get; init; }
        public required CustomerLocation Location { get; init; }
        public required string Email { get; init; }
        public required DateTime Birthday { get; init; }
        public required DateTime Registered { get; init; }
        public required string[] TelephoneNumbers { get; init; }
        public required string[] MobileNumbers { get; init; }
        public required CustomerPicture Picture { get; init; }
        public required string Nationality { get; init; }

        public record CustomerName
        {
            public required string Title { get; init; }
            public required string First { get; init; }
            public required string Last { get; init; }
        }

        public record CustomerLocation
        {
            public required string Region { get; init; }
            public required string Street { get; init; }
            public required string City { get; init; }
            public required string State { get; init; }
            public required string PostCode { get; init; }
            public required CustomerLocationCoordinates Coordinates { get; init; }
            public required CustomerLocationTimezone Timezone { get; init; }
        }

        public record CustomerLocationCoordinates
        {
            public required string Latitude { get; init; }
            public required string Longitude { get; init; }
        }

        public record CustomerLocationTimezone
        {
            public required string Offset { get; init; }
            public required string Description { get; init; }
        }

        public record CustomerPicture
        {
            public required string Large { get; init; }
            public required string Medium { get; init; }
            public required string Thumbnail { get; init; }
        }
    }
}
