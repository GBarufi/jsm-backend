using FluentValidation;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;

namespace JSM.Application.Commands.Users.CreateUser
{
    public class CreateUsersFromJsonValidation : AbstractValidator<CreateUsersFromJsonCommand>
    {
        public CreateUsersFromJsonValidation()
        {
            RuleFor(x => x.UsersList)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.UsersList)
                .ChildRules(user =>
                {
                    user.RuleFor(x => x.Gender).NotEmpty().Must(x => BeIncludedInEnumDisplayNames<UserGender>(x!));

                    user.RuleFor(x => x.Name).NotNull();
                    user.RuleFor(x => x.Name.Title).NotEmpty();
                    user.RuleFor(x => x.Name.First).NotEmpty();
                    user.RuleFor(x => x.Name.Last).NotEmpty();

                    user.RuleFor(x => x.Location).NotNull();
                    user.RuleFor(x => x.Location.Street).NotEmpty();
                    user.RuleFor(x => x.Location.City).NotEmpty();
                    user.RuleFor(x => x.Location.State).NotEmpty().Must(x => BeIncludedInEnumDisplayNames<LocationState>(x!));
                    user.RuleFor(x => x.Location.PostCode).NotEmpty();

                    user.RuleFor(x => x.Location.Coordinates).NotNull();
                    user.RuleFor(x => x.Location.Coordinates.Latitude).NotEmpty().Must(x => BeAValidDouble(x!));
                    user.RuleFor(x => x.Location.Coordinates.Longitude).NotEmpty().Must(x => BeAValidDouble(x!));

                    user.RuleFor(x => x.Location.Timezone).NotNull();
                    user.RuleFor(x => x.Location.Timezone.Offset).NotEmpty();
                    user.RuleFor(x => x.Location.Timezone.Description).NotEmpty();

                    user.RuleFor(x => x.Dob).NotNull();
                    user.RuleFor(x => x.Dob.Date).NotNull().Must(x => BeAValidDate(x!.Value));

                    user.RuleFor(x => x.Registered).NotNull();
                    user.RuleFor(x => x.Registered.Date).NotNull().Must(x => BeAValidDate(x!.Value));

                    user.RuleFor(x => x.Email).NotEmpty();
                    user.RuleFor(x => x.Phone).NotEmpty();
                    user.RuleFor(x => x.Cell).NotEmpty();

                    user.RuleFor(x => x.Picture).NotNull();
                    user.RuleFor(x => x.Picture.Large).NotEmpty();
                    user.RuleFor(x => x.Picture.Medium).NotEmpty();
                    user.RuleFor(x => x.Picture.Thumbnail).NotEmpty();
                });
        }

        private static bool BeIncludedInEnumDisplayNames<T>(string value) where T : struct, Enum
        {
            if (value is null)
                return false;

            return Enum.GetValues<T>()
                .Select(x => x.GetDisplayName().ToLower()).ToList()
                .Contains(value.ToLower());
        }

        private static bool BeAValidDouble(string value) => double.TryParse(value, out _);

        private static bool BeAValidDate(DateTime value) => value > DateTime.MinValue;
    }
}
