using Microsoft.AspNetCore.Mvc;

namespace JSM.Application.Core
{
    public record PaginatedRequest<T> : RequestBase<PaginatedResponse<T>>
    {
        [BindProperty(Name = "pageNumber")]
        public int? Page { get; init; } = 0;

        [BindProperty(Name = "pageSize")]
        public int? Size { get; init; } = 10;

        public override bool IsValid() => true;
    }
}
