namespace JSM.Application.Dtos.Users
{
    public record UserDto
    {
        /// <example>female</example>
        public string? Gender { get; init; }
        public UserName Name { get; init; } = new();
        public UserLocation Location { get; init; } = new();
        public string? Email { get; init; }
        public UserDate Dob { get; init; } = new();
        public UserDate Registered { get; init; } = new();
        public string? Phone { get; init; }
        public string? Cell { get; init; }

        public UserPicture Picture { get; init; } = new();

        public record UserName
        {
            public string? Title { get; init; }
            public string? First { get; init; }
            public string? Last { get; init; }
        }

        public record UserLocation
        {
            /// <example>1771 Rua Rui Barbosa</example>
            public string? Street { get; init; }

            /// <example>São Vicente</example>
            public string? City { get; init; }

            /// <example>Piauí</example>
            public string? State { get; init; }

            /// <example>37787</example>
            public string? PostCode { get; init; }

            public UserLocationCoordinates Coordinates { get; init; } = new();
            public UserLocationTimezone Timezone { get; init; } = new();
        }

        public record UserLocationCoordinates
        {
            /// <example>-81.4170</example>
            public string? Latitude { get; init; }

            /// <example>-97.9945</example>
            public string? Longitude { get; init; }
        }

        public record UserLocationTimezone
        {
            /// <example>-2:00</example>
            public string? Offset { get; init; }
            public string? Description { get; init; }
        }

        public record UserDate
        {
            public DateTime? Date { get; init; }
            public int? Age { get; init; }
        }

        public record UserPicture
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
