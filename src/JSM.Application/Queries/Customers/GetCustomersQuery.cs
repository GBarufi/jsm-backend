using JSM.Application.Core;
using JSM.Application.Dtos.Customers;

namespace JSM.Application.Queries.Customers
{
    public record GetCustomersQuery : RequestBase<List<GetCustomersResponse>>
    {
        public override bool IsValid() => true;
    }
}
