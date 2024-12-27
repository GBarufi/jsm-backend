namespace JSM.Application.Core
{
    public class PaginatedResponse<T>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }
        public List<T>? Data { get; init; }

        public PaginatedResponse() { }

        public PaginatedResponse(List<T>? data, int totalItems, int currentPage, int pageSize)
        {
            PageNumber = currentPage;
            PageSize = data?.Count ?? 0;
            TotalCount = totalItems;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            Data = data;
        }
    }
}
