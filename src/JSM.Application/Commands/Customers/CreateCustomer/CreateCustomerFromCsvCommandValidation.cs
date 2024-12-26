using FluentValidation;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromCsvCommandValidation : AbstractValidator<CreateCustomerFromCsvCommand>
    {
        public CreateCustomerFromCsvCommandValidation()
        {
            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
