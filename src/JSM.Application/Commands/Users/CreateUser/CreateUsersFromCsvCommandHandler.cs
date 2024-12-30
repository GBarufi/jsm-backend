using JSM.Application.Core.Interfaces;
using JSM.Application.Core.Utils;
using JSM.Application.Dtos.Users;
using JSM.Application.Mappers.Users;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Commands.Users.CreateUser
{
    public class CreateUsersFromCsvCommandHandler : IRequestHandler<CreateUsersFromCsvCommand, int>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;
        private readonly ICsvHelper _csvHelper;

        public CreateUsersFromCsvCommandHandler(IDbContextFactory<JsmContext> dbContextFactory, ICsvHelper csvHelper)
        {
            _dbContextFactory = dbContextFactory;
            _csvHelper = csvHelper;
        }

        public async Task<int> Handle(CreateUsersFromCsvCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var csvData = _csvHelper.ImportCsv<UserDto, UserCsvMapper>(request.Content!).ToList();

            foreach (var csvRow in csvData)
            {
                var newUser = new User(
                    csvRow.Gender!.GetEnumValueFromDisplayName<UserGender>(),
                    csvRow.Name.Title,
                    csvRow.Name.First,
                    csvRow.Name.Last,
                    csvRow.Email,
                    (DateTime)csvRow.Dob.Date,
                    (DateTime)csvRow.Registered.Date,
                    PhoneUtils.ConvertToE164(csvRow.Phone),
                    PhoneUtils.ConvertToE164(csvRow.Cell),
                    UserNationality.BR,
                    new UserLocation(
                        csvRow.Location.Street,
                        csvRow.Location.City,
                        csvRow.Location.State,
                        csvRow.Location.PostCode,
                        csvRow.Location.Coordinates.Latitude,
                        csvRow.Location.Coordinates.Longitude,
                        csvRow.Location.Timezone.Offset,
                        csvRow.Location.Timezone.Description
                    ),
                    new UserPortrait(
                        csvRow.Picture.Large,
                        csvRow.Picture.Medium,
                        csvRow.Picture.Thumbnail
                    )
                );

                await dbContext.Users.AddAsync(newUser, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
