using JSM.Application.Dtos.Customers;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Queries.Customers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<GetCustomersResponse>>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;

        public GetCustomersQueryHandler(IDbContextFactory<JsmContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<GetCustomersResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var customers = await dbContext.Customers
                .Include(x => x.Location)
                .Include(x => x.Portrait)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (customers.Count == 0)
                return [];

            var response = customers.Select(x => ConvertModelToResponse(x)).ToList();

            return response;
        }

        private GetCustomersResponse ConvertModelToResponse(Customer x)
        {
            return new GetCustomersResponse
            {
                Type = x.Type.ToString().ToLower(),
                Gender = x.Gender.ToString().ToLower(),
                Name = new GetCustomersResponse.CustomerName
                {
                    Title = x.Title,
                    First = x.FirstName,
                    Last = x.LastName
                },
                Location = new GetCustomersResponse.CustomerLocation
                {
                    Region = x.Location!.Region.ToString().ToLower(),
                    Street = x.Location!.Street,
                    City = x.Location!.City,
                    State = x.Location!.State,
                    PostCode = x.Location!.PostCode,
                    Coordinates = new GetCustomersResponse.CustomerLocationCoordinates
                    {
                        Latitude = x.Location!.Latitude,
                        Longitude = x.Location!.Longitude
                    },
                    Timezone = new GetCustomersResponse.CustomerLocationTimezone
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
                Picture = new GetCustomersResponse.CustomerPicture
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
