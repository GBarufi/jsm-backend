using JSM.Application.Core.Utils;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Commands.Users.CreateUser
{
    public class CreateUsersFromJsonCommandHandler : IRequestHandler<CreateUsersFromJsonCommand, int>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;

        public CreateUsersFromJsonCommandHandler(IDbContextFactory<JsmContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<int> Handle(CreateUsersFromJsonCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var userToAdd = request.UsersList!;

            foreach (var user in userToAdd)
            {
                var newUser = new User(
                    user.Gender!.GetEnumValueFromDisplayName<UserGender>(),
                    user.Name.Title!,
                    user.Name.First!,
                    user.Name.Last!,
                    user.Email!,
                    user.Dob.Date!.Value,
                    user.Registered.Date!.Value,
                    PhoneUtils.ConvertToE164(user.Phone!),
                    PhoneUtils.ConvertToE164(user.Cell!),
                    UserNationality.BR,
                    new UserLocation(
                        user.Location.Street!,
                        user.Location.City!,
                        user.Location.State!,
                        user.Location.PostCode!,
                        user.Location.Coordinates.Latitude!,
                        user.Location.Coordinates.Longitude!,
                        user.Location.Timezone.Offset!,
                        user.Location.Timezone.Description!
                    ),
                    new UserPortrait(
                        user.Picture.Large!,
                        user.Picture.Medium!,
                        user.Picture.Thumbnail!
                    )
                );

                await dbContext.Users.AddAsync(newUser, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
