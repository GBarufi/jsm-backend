using Bogus;
using JSM.Domain.Enums;
using JSM.Domain.Models;

namespace JSM.UnitTests.Helpers.Fakers
{
    public class UserFaker
    {
        public static User Generate()
        {
            var faker = new Faker();
            var userGender = faker.Random.Enum<UserGender>();

            return new User(
                userGender,
                userGender == UserGender.F ? "Miss" : faker.PickRandom("Mr", "Mrs"),
                faker.Person.FirstName,
                faker.Person.LastName,
                faker.Person.Email,
                faker.Person.DateOfBirth,
                faker.Person.DateOfBirth.AddYears(-1),
                faker.Phone.PhoneNumber("(##) ####-####"),
                faker.Phone.PhoneNumber("(##) ####-####"),
                UserNationality.BR,
                UserLocationFaker.Generate(),
                UserPortraitFaker.Generate(userGender)
            );
        }
    }
}
