using System.Text.Json.Serialization;

namespace JSM.Application.Core
{
    public abstract class PaginatedResponse<T>
    {
        [JsonPropertyOrder(-4)]
        public int PageNumber { get; init; }

        [JsonPropertyOrder(-3)]
        public int PageSize { get; init; }

        [JsonPropertyOrder(-2)]
        public int TotalCount { get; init; }

        [JsonPropertyOrder(-1)]
        public int TotalPages { get; init; }

        public abstract void SetDataToNamedProperty(List<T>? data);

        public PaginatedResponse() { }

        public PaginatedResponse(List<T>? data, int totalItems, int currentPage, int pageSize)
        {
            PageNumber = currentPage;
            PageSize = data?.Count ?? 0;
            TotalCount = totalItems;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            SetDataToNamedProperty(data);
        }
    }
}
