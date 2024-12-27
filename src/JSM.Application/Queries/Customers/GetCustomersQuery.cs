using JSM.Application.Core;
using JSM.Application.Dtos.Customers;

namespace JSM.Application.Queries.Customers
{
    public record GetCustomersQuery : PaginatedRequest<GetCustomersResponse>
    {
    }
}
