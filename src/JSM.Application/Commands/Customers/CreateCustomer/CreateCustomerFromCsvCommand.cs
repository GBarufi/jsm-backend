using JSM.Application.Core;
using JSM.Application.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public record CreateCustomerFromCsvCommand : CsvRequestBase<int>
    {
        public override bool IsValid(ICsvHelper csvHelper)
        {
            ValidationResult = new CreateCustomerFromCsvCommandValidation(csvHelper).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
