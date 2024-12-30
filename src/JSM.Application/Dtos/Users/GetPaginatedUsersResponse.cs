using JSM.Application.Core;

namespace JSM.Application.Dtos.Users
{
    public class GetPaginatedUsersResponse : PaginatedResponse<GetUsersResponse>
    {
        public GetPaginatedUsersResponse(
            List<GetUsersResponse>? data,
            int totalItems,
            int currentPage,
            int pageSize) : base(data, totalItems, currentPage, pageSize) { }

        public List<GetUsersResponse>? Users { get; private set; }

        public override void SetDataToNamedProperty(List<GetUsersResponse>? data)
        {
            Users = data;
        }
    }
}
