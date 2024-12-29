using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace JSM.Application.Core
{
    public abstract record RequestBase<T> : IRequest<T>
    {
        [JsonIgnore]
        protected virtual ValidationResult? ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
