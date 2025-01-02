using CsvHelper.Configuration;
using JSM.Application.Dtos.Users;

namespace JSM.UnitTests.Helpers.Mappers
{
    internal class UserCsvMapperWithWrongOrder : ClassMap<UserInputDto>
    {
        private UserCsvMapperWithWrongOrder()
        {
            Map(x => x.Name!.Title).Index(0).Name("name__title");
            Map(x => x.Name!.First).Index(1).Name("name__first");
            Map(x => x.Name!.Last).Index(2).Name("name__last");
            Map(x => x.Gender).Index(3).Name("gender");
            Map(x => x.Location!.Street).Index(4).Name("location__street");
            Map(x => x.Location!.City).Index(5).Name("location__city");
            Map(x => x.Location!.State).Index(6).Name("location__state");
            Map(x => x.Location!.PostCode).Index(7).Name("location__postcode");
            Map(x => x.Location!.Coordinates!.Latitude).Index(8).Name("location__coordinates__latitude");
            Map(x => x.Location!.Coordinates!.Longitude).Index(9).Name("location__coordinates__longitude");
            Map(x => x.Location!.Timezone!.Offset).Index(10).Name("location__timezone__offset");
            Map(x => x.Location!.Timezone!.Description).Index(11).Name("location__timezone__description");
            Map(x => x.Email).Index(12).Name("email");
            Map(x => x.Dob!.Date).Index(13).Name("dob__date");
            Map(x => x.Dob!.Age).Index(14).Name("dob__age");
            Map(x => x.Registered!.Date).Index(15).Name("registered__date");
            Map(x => x.Registered!.Age).Index(16).Name("registered__age");
            Map(x => x.Phone).Index(17).Name("phone");
            Map(x => x.Cell).Index(18).Name("cell");
            Map(x => x.Picture!.Large).Index(19).Name("picture__large");
            Map(x => x.Picture!.Medium).Index(20).Name("picture__medium");
            Map(x => x.Picture!.Thumbnail).Index(21).Name("picture__thumbnail");
        }
    }
}
