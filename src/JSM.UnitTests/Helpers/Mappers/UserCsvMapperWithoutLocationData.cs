using CsvHelper.Configuration;
using JSM.Application.Dtos.Users;

namespace JSM.UnitTests.Helpers.Mappers
{
    internal class UserCsvMapperWithoutLocationData : ClassMap<UserInputDto>
    {
        private UserCsvMapperWithoutLocationData()
        {
            Map(x => x.Gender).Index(0).Name("gender");
            Map(x => x.Name!.Title).Index(1).Name("name__tile");
            Map(x => x.Name!.First).Index(2).Name("name__first");
            Map(x => x.Name!.Last).Index(3).Name("name__last");
            Map(x => x.Email).Index(4).Name("email");
            Map(x => x.Dob!.Date).Index(5).Name("dob__date");
            Map(x => x.Dob!.Age).Index(6).Name("dob__age");
            Map(x => x.Registered!.Date).Index(7).Name("registered__date");
            Map(x => x.Registered!.Age).Index(8).Name("registered__age");
            Map(x => x.Phone).Index(9).Name("phone");
            Map(x => x.Cell).Index(10).Name("cell");
            Map(x => x.Picture!.Large).Index(11).Name("picture__large");
            Map(x => x.Picture!.Medium).Index(12).Name("picture__medium");
            Map(x => x.Picture!.Thumbnail).Index(13).Name("picture__thumbnail");
        }
    }
}
