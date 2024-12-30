using JSM.Application.Core;
using JSM.Application.Dtos.Users;

namespace JSM.Application.Queries.Users
{
    public record GetUsersQuery : PaginatedRequest<GetPaginatedUsersResponse>
    {
        public string? Name { get; init; } = string.Empty;
        public string? Region { get; init; } = string.Empty;
        public string? State { get; init; } = string.Empty;
        public string? City { get; init; } = string.Empty;

        public override bool IsValid()
        {
            ValidationResult = new GetUsersQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
