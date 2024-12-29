namespace JSM.Application.Dtos.Customers
{
    public record CustomerDto
    {
        public string? Gender { get; init; }
        public CustomerName Name { get; init; } = new();
        public CustomerLocation Location { get; init; } = new();
        public string? Email { get; init; }
        public CustomerDate Dob { get; init; } = new();
        public CustomerDate Registered { get; init; } = new();
        public string? Phone { get; init; }
        public string? Cell { get; init; }
        public CustomerPicture Picture { get; init; } = new();

        public record CustomerName
        {
            public string? Title { get; init; }
            public string? First { get; init; }
            public string? Last { get; init; }
        }

        public record CustomerLocation
        {
            public string? Street { get; init; }
            public string? City { get; init; }
            public string? State { get; init; }
            public string? PostCode { get; init; }
            public CustomerLocationCoordinates Coordinates { get; init; } = new();
            public CustomerLocationTimezone Timezone { get; init; } = new();
        }

        public record CustomerLocationCoordinates
        {
            public string? Latitude { get; init; }
            public string? Longitude { get; init; }
        }

        public record CustomerLocationTimezone
        {
            public string? Offset { get; init; }
            public string? Description { get; init; }
        }

        public record CustomerDate
        {
            public DateTime? Date { get; init; }
            public int? Age { get; init; }
        }

        public record CustomerPicture
        {
            public string? Large { get; init; }
            public string? Medium { get; init; }
            public string? Thumbnail { get; init; }
        }
    }
}
