using CsvHelper.Configuration;
using JSM.Application.Dtos.Users;

namespace JSM.Application.Mappers.Users
{
    public class UserCsvMapper : ClassMap<UserDto>
    {
        public UserCsvMapper()
        {
            Map(x => x.Gender).Index(0);
            Map(x => x.Name!.Title).Index(1);
            Map(x => x.Name!.First).Index(2);
            Map(x => x.Name!.Last).Index(3);
            Map(x => x.Location!.Street).Index(4);
            Map(x => x.Location!.City).Index(5);
            Map(x => x.Location!.State).Index(6);
            Map(x => x.Location!.PostCode).Index(7);
            Map(x => x.Location!.Coordinates!.Latitude).Index(8);
            Map(x => x.Location!.Coordinates!.Longitude).Index(9);
            Map(x => x.Location!.Timezone!.Offset).Index(10);
            Map(x => x.Location!.Timezone!.Description).Index(11);
            Map(x => x.Email).Index(12);
            Map(x => x.Dob!.Date).Index(13);
            Map(x => x.Dob!.Age).Index(14);
            Map(x => x.Registered!.Date).Index(15);
            Map(x => x.Registered!.Age).Index(16);
            Map(x => x.Phone).Index(17);
            Map(x => x.Cell).Index(18);
            Map(x => x.Picture!.Large).Index(19);
            Map(x => x.Picture!.Medium).Index(20);
            Map(x => x.Picture!.Thumbnail).Index(21);
        }
    }
}
