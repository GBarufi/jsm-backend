namespace JSM.Application.Dtos.Users
{
    public record UserInputDto
    {
        /// <example>female</example>
        public string? Gender { get; init; }
        public UserInputName Name { get; init; } = new();
        public UserInputLocation Location { get; init; } = new();
        public string? Email { get; init; }
        public UserInputDate Dob { get; init; } = new();
        public UserInputDate Registered { get; init; } = new();
        public string? Phone { get; init; }
        public string? Cell { get; init; }

        public UserInputPicture Picture { get; init; } = new();

        public record UserInputName
        {
            public string? Title { get; init; }
            public string? First { get; init; }
            public string? Last { get; init; }
        }

        public record UserInputLocation
        {
            /// <example>1771 Rua Rui Barbosa</example>
            public string? Street { get; init; }

            /// <example>São Vicente</example>
            public string? City { get; init; }

            /// <example>Piauí</example>
            public string? State { get; init; }

            /// <example>37787</example>
            public string? PostCode { get; init; }

            public UserInputLocationCoordinates Coordinates { get; init; } = new();
            public UserInputLocationTimezone Timezone { get; init; } = new();
        }

        public record UserInputLocationCoordinates
        {
            /// <example>-81.4170</example>
            public string? Latitude { get; init; }

            /// <example>-97.9945</example>
            public string? Longitude { get; init; }
        }

        public record UserInputLocationTimezone
        {
            /// <example>-2:00</example>
            public string? Offset { get; init; }
            public string? Description { get; init; }
        }

        public record UserInputDate
        {
            public DateTime? Date { get; init; }
            public int? Age { get; init; }
        }

        public record UserInputPicture
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
