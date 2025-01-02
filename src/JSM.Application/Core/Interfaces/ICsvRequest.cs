namespace JSM.Application.Core.Interfaces
{
    public interface ICsvRequest
    {
        public byte[]? Content { get; init; }
        abstract bool IsValid(ICsvHelper csvHelper);
    }
}
