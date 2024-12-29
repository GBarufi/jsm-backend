namespace JSM.Application.Dtos.Customers
{
    public record CustomerDto
    {
        /// <example>female</example>
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
            /// <example>1771 Rua Rui Barbosa</example>
            public string? Street { get; init; }

            /// <example>São Vicente</example>
            public string? City { get; init; }

            /// <example>Piauí</example>
            public string? State { get; init; }

            /// <example>37787</example>
            public string? PostCode { get; init; }

            public CustomerLocationCoordinates Coordinates { get; init; } = new();
            public CustomerLocationTimezone Timezone { get; init; } = new();
        }

        public record CustomerLocationCoordinates
        {
            /// <example>-81.4170</example>
            public string? Latitude { get; init; }

            /// <example>-97.9945</example>
            public string? Longitude { get; init; }
        }

        public record CustomerLocationTimezone
        {
            /// <example>-2:00</example>
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
            /// <example>https://randomuser.me/api/portraits/women/18.jpg</example>
            public string? Large { get; init; }

            /// <example>https://randomuser.me/api/portraits/med/women/18.jpg</example>
            public string? Medium { get; init; }

            /// <example>https://randomuser.me/api/portraits/thumb/women/18.jpg</example>
            public string? Thumbnail { get; init; }
        }
    }
}
