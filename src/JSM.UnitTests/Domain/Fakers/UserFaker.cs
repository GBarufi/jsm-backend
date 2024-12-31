using Bogus;
using JSM.Domain.Enums;
using JSM.Domain.Models;

namespace JSM.UnitTests.Domain.Fakers
{
    public class UserFaker
    {
        public static User Generate()
        {
            var faker = new Faker();
            var userGender = faker.Random.Enum<UserGender>();

            return new User(
                userGender,
                faker.PickRandom("Mr", "Mrs", "Miss"),
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
