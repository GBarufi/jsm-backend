using FluentValidation;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromJsonValidation : AbstractValidator<CreateCustomerFromJsonCommand>
    {
        public CreateCustomerFromJsonValidation()
        {

        }
    }
}
