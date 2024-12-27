namespace JSM.Application.Core
{
    public record PaginatedRequest<T> : RequestBase<PaginatedResponse<T>>
    {
        public int? Page { get; init; } = 0;

        public int? Size { get; init; } = 10;

        public override bool IsValid() => true;
    }
}
