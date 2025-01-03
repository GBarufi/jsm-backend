using JSM.Application.Dtos.Users;
using JSM.Domain.Extensions;
using JSM.UnitTests.Helpers.Fakers;
using static JSM.Application.Dtos.Users.UserInputDto;

namespace JSM.UnitTests.Helpers
{
    internal static class UserInputDtoExtensions
    {
        internal static UserInputDto PopulateEmptyValuesWithFakeData(this UserInputDto dto)
        {
            var fakeData = UserFaker.Generate();

            return new UserInputDto
            {
                Gender = dto.Gender is null ? fakeData.Gender.GetDisplayName() : dto.Gender,
                Name = new UserInputName
                {
                    Title = dto.Name is not null && dto.Name.Title is null ? fakeData.Title : dto.Name?.Title,
                    First = dto.Name is not null && dto.Name.First is null ? fakeData.FirstName : dto.Name?.First,
                    Last = dto.Name is not null && dto.Name.Last is null ? fakeData.LastName : dto.Name?.Last
                },
                Location = new UserInputLocation
                {
                    Street = dto.Location is not null && dto.Location.Street is null ? fakeData.Location!.Street : dto.Location?.Street,
                    City = dto.Location is not null && dto.Location.City is null ? fakeData.Location!.City : dto.Location?.City,
                    State = dto.Location is not null && dto.Location.State is null ? fakeData.Location!.State : dto.Location?.State,
                    PostCode = dto.Location is not null && dto.Location.PostCode is null ? fakeData.Location!.PostCode : dto.Location?.PostCode,
                    Coordinates = new UserInputLocationCoordinates
                    {
                        Latitude = dto.Location is not null
                                && dto.Location.Coordinates is not null
                                && dto.Location.Coordinates.Latitude is null ? fakeData.Location!.Latitude : dto.Location?.Coordinates?.Latitude,

                        Longitude = dto.Location is not null
                                 && dto.Location.Coordinates is not null
                                 && dto.Location.Coordinates.Longitude is null ? fakeData.Location!.Longitude : dto.Location?.Coordinates?.Longitude
                    },
                    Timezone = new UserInputLocationTimezone
                    {
                        Offset = dto.Location is not null
                              && dto.Location.Timezone is not null
                              && dto.Location.Timezone.Offset is null ? fakeData.Location!.TimezoneOffset : dto.Location?.Timezone?.Offset,

                        Description = dto.Location is not null
                                   && dto.Location.Timezone is not null
                                   && dto.Location.Timezone.Description is null ? fakeData.Location!.TimezoneDescription : dto.Location?.Timezone?.Description
                    }
                },
                Email = dto.Email is null ? fakeData.Email : dto.Email,
                Dob = new UserInputDate
                {
                    Date = dto.Dob is not null && dto.Dob.Date.HasValue ? dto.Dob?.Date : fakeData.Birthday,
                    Age = 30
                },
                Registered = new UserInputDate
                {
                    Date = dto.Registered is not null && dto.Registered.Date.HasValue ? dto.Registered?.Date : fakeData.Registered,
                    Age = 30
                },
                Phone = dto.Phone is null ? fakeData.TelephoneNumbers.First() : dto.Phone,
                Cell = dto.Cell is null ? fakeData.TelephoneNumbers.First() : dto.Cell,
                Picture = new UserInputPicture
                {
                    Large = dto.Picture is not null && dto.Picture.Large is null ? fakeData.Portrait!.Large : dto.Picture?.Large,
                    Medium = dto.Picture is not null && dto.Picture.Medium is null ? fakeData.Portrait!.Medium : dto.Picture?.Medium,
                    Thumbnail = dto.Picture is not null && dto.Picture.Thumbnail is null ? fakeData.Portrait!.Thumbnail : dto.Picture?.Thumbnail
                }
            };
        }
    }
}
