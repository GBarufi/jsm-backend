using JSM.Application.Core.Extensions;
using JSM.Application.Dtos.Users;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Queries.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetPaginatedUsersResponse>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;

        public GetUsersQueryHandler(IDbContextFactory<JsmContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<GetPaginatedUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var usersQuery = dbContext.Users
                .Include(x => x.Location)
                .Include(x => x.Portrait)
                .AsNoTracking();

            ApplyFilters(ref usersQuery, request);

            var users = await usersQuery
                .Skip(request.Page!.Value * request.Size!.Value)
                .Take(request.Size!.Value)
                .Select(x => ConvertModelToResponse(x))
                .ToListAsync(cancellationToken);

            var totalItems = await usersQuery.CountAsync(cancellationToken);

            return new GetPaginatedUsersResponse(users, totalItems, request.Page.Value, request.Size.Value);
        }

        private static void ApplyFilters(ref IQueryable<User> query, GetUsersQuery request)
        {
            query = query.WhereIf(!string.IsNullOrEmpty(request.Name), x =>
                x.FirstName.Contains(request.Name!, StringComparison.CurrentCultureIgnoreCase) || x.LastName.Contains(request.Name!, StringComparison.CurrentCultureIgnoreCase));

            query = query.WhereIf(!string.IsNullOrEmpty(request.Region), x =>
                x.Location!.Region == (LocationRegion)Enum.Parse(typeof(LocationRegion), request.Region!, true));

            query = query.WhereIf(!string.IsNullOrEmpty(request.State), x =>
                x.Location!.State.GetEnumValueFromDisplayName<LocationState>() == (LocationState)Enum.Parse(typeof(LocationState), request.State!, true));

            query = query.WhereIf(!string.IsNullOrEmpty(request.City), x =>
                x.Location!.City.Contains(request.City!, StringComparison.CurrentCultureIgnoreCase));

            query = query.WhereIf(!string.IsNullOrEmpty(request.Type), x =>
                x.Type == (UserType)Enum.Parse(typeof(UserType), request.Type!, true));
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
