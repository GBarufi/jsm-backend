using JSM.Application.Core;
using JSM.Application.Dtos.Users;

namespace JSM.Application.Queries.Users
{
    public record GetUsersQuery : PaginatedRequest<GetUsersResponse>
    {
    }
}
