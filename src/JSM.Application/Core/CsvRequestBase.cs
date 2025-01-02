using JSM.Application.Core.Interfaces;

namespace JSM.Application.Core
{
    public abstract record CsvRequestBase<T> : RequestBase<T>, ICsvRequest
    {
        public byte[]? Content { get; init; }
        public abstract bool IsValid(ICsvHelper? csvHelper);
        public override sealed bool IsValid() => IsValid(null);
    }
}
