using Bogus;
using JSM.Domain.Enums;
using JSM.Domain.Models;

namespace JSM.UnitTests.Helpers.Fakers
{
    public class UserPortraitFaker
    {
        public static UserPortrait Generate(UserGender gender)
        {
            var faker = new Faker();
            var baseStr = "https://randomuser.me/api/portraits";
            var genderStr = gender == UserGender.F ? "woman" : "men";
            var portraitCode = faker.Random.Int(1, 100);

            return new UserPortrait(
                $"{baseStr}/{genderStr}/large/{portraitCode}",
                $"{baseStr}/{genderStr}/medium/{portraitCode}",
                $"{baseStr}/{genderStr}/thumnail/{portraitCode}"
            );
        }
    }
}
