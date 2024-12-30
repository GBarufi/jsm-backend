using JSM.Application.Core;
using JSM.Application.Dtos.Users;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Queries.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PaginatedResponse<GetUsersResponse>>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;

        public GetUsersQueryHandler(IDbContextFactory<JsmContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<PaginatedResponse<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var usersQuery = dbContext.Users
                .Include(x => x.Location)
                .Include(x => x.Portrait)
                .AsNoTracking();

            var users = await usersQuery
                .Skip(request.Page!.Value * request.Size!.Value)
                .Take(request.Size!.Value)
                .Select(x => ConvertModelToResponse(x))
                .ToListAsync(cancellationToken);

            var totalItems = await usersQuery.CountAsync(cancellationToken);

            return new PaginatedResponse<GetUsersResponse>(users, totalItems, request.Page.Value, request.Size.Value);
        }

        private static GetUsersResponse ConvertModelToResponse(User x)
        {
            return new GetUsersResponse
            {
                Type = x.Type.ToString().ToLower(),
                Gender = x.Gender.ToString().ToLower(),
                Name = new GetUsersResponse.UserName
                {
                    Title = x.Title,
                    First = x.FirstName,
                    Last = x.LastName
                },
                Location = new GetUsersResponse.UserLocation
                {
                    Region = x.Location!.Region.ToString().ToLower(),
                    Street = x.Location!.Street,
                    City = x.Location!.City,
                    State = x.Location!.State,
                    PostCode = x.Location!.PostCode,
                    Coordinates = new GetUsersResponse.UserLocationCoordinates
                    {
                        Latitude = x.Location!.Latitude,
                        Longitude = x.Location!.Longitude
                    },
                    Timezone = new GetUsersResponse.UserLocationTimezone
                    {
                        Offset = x.Location!.TimezoneOffset,
                        Description = x.Location!.TimezoneDescription
                    }
                },
                Email = x.Email,
                Birthday = x.Birthday.ToUniversalTime(),
                Registered = x.Registered.ToUniversalTime(),
                TelephoneNumbers = x.TelephoneNumbers,
                MobileNumbers = x.MobileNumbers,
                Picture = new GetUsersResponse.UserPicture
                {
                    Large = x.Portrait!.Large,
                    Medium = x.Portrait!.Medium,
                    Thumbnail = x.Portrait!.Thumbnail
                },
                Nationality = x.Nationality.ToString().ToUpper()
            };
        }
    }
}
