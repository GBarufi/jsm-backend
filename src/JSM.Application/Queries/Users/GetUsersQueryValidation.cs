using FluentValidation;
using JSM.Domain.Enums;

namespace JSM.Application.Queries.Users
{
    public class GetUsersQueryValidation : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidation()
        {
            When(x => !string.IsNullOrEmpty(x.Region), () =>
            {
                RuleFor(x => x.Region)
                    .Must(x => BeIncludedInEnumDescriptions<LocationRegion>(x!))
                    .WithMessage($"Invalid region. Valid regions are {string.Join(", ", Enum.GetNames(typeof(LocationRegion)))}");
            });

            When(x => !string.IsNullOrEmpty(x.State), () =>
            {
                RuleFor(x => x.State)
                    .Must(x => BeIncludedInEnumDescriptions<LocationState>(x!))
                    .WithMessage($"Invalid state. Valid states are {string.Join(", ", Enum.GetNames(typeof(LocationState)))}");
            });

            When(x => !string.IsNullOrEmpty(x.Type), () =>
            {
                RuleFor(x => x.Type)
                    .Must(x => BeIncludedInEnumDescriptions<UserType>(x!))
                    .WithMessage($"Invalid user type. Valid types are {string.Join(", ", Enum.GetNames(typeof(UserType)))}");
            });
        }

        private static bool BeIncludedInEnumDescriptions<T>(string value) where T : struct, Enum
        {
            return Enum.GetNames(typeof(T)).Select(x => x.ToLower()).Contains(value.ToLower());
        }
    }
}
