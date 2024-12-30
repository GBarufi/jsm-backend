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
                    .Must(x => BeIncludedInEnumDescriptions<LocationRegion>(x!));
            });

            When(x => !string.IsNullOrEmpty(x.State), () =>
            {
                RuleFor(x => x.State)
                    .Must(x => BeIncludedInEnumDescriptions<LocationState>(x!));
            });

            When(x => !string.IsNullOrEmpty(x.Type), () =>
            {
                RuleFor(x => x.Type)
                    .Must(x => BeIncludedInEnumDescriptions<UserType>(x!));
            });
        }

        private static bool BeIncludedInEnumDescriptions<T>(string value) where T : struct, Enum
        {
            return Enum.GetNames(typeof(T)).Select(x => x.ToLower()).Contains(value.ToLower());
        }
    }
}
