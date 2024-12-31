using Bogus;
using Bogus.Extensions;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;

namespace JSM.UnitTests.Domain.Fakers
{
    public class UserLocationFaker
    {
        public static UserLocation Generate()
        {
            var faker = new Faker();

            return new UserLocation(
                faker.Address.StreetAddress(),
                faker.Address.City(),
                faker.Random.Enum<LocationState>().GetDisplayName(),
                faker.Address.ZipCode(),
                faker.Address.Latitude().ToString(),
                faker.Address.Longitude().ToString(),
                $"{faker.Random.Int(-5, 5)}:00",
                faker.Random.Words(3).ClampLength(null, 60)
            );
        }
    }
}
