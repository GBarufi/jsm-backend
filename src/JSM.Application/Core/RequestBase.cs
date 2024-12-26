using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace JSM.Application.Core
{
    public abstract record RequestBase<T> : IRequest<T>
    {
        [JsonIgnore]
        public virtual ValidationResult? ValidationResult { get; protected set; }

        public abstract bool IsValid();
    }
}
