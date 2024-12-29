using JSM.Application.Core;
using JSM.Application.Dtos.Customers;
using Newtonsoft.Json;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public record CreateCustomersFromJsonCommand : RequestBase<int>
    {
        [JsonProperty("Results")]
        public List<CustomerCsvDto>? CustomersList { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerFromJsonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
