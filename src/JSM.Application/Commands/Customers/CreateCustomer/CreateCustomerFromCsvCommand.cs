using JSM.Application.Core;
using System.ComponentModel.DataAnnotations;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public record CreateCustomerFromCsvCommand : RequestBase<int>
    {
        public string? Content { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerFromCsvCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
