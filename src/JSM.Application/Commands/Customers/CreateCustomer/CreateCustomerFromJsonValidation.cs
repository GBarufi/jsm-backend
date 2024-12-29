using FluentValidation;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromJsonValidation : AbstractValidator<CreateCustomersFromJsonCommand>
    {
        public CreateCustomerFromJsonValidation()
        {
            RuleForEach(x => x.CustomersList)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .ChildRules(customer =>
                {
                    customer.RuleFor(x => x.Gender)
                            .NotEmpty()
                            .Must(x => BeIncludedInEnumDisplayNames<CustomerGender>(x!));

                    customer.RuleFor(x => x.Name).NotNull();
                    customer.RuleFor(x => x.Name.Title).NotEmpty();
                    customer.RuleFor(x => x.Name.First).NotEmpty();
                    customer.RuleFor(x => x.Name.Last).NotEmpty();

                    customer.RuleFor(x => x.Location).NotNull();
                    customer.RuleFor(x => x.Location.Street).NotEmpty();
                    customer.RuleFor(x => x.Location.City).NotEmpty();
                    customer.RuleFor(x => x.Location.State).NotEmpty();
                    customer.RuleFor(x => x.Location.PostCode).NotEmpty();

                    customer.RuleFor(x => x.Location.Coordinates).NotNull();
                    customer.RuleFor(x => x.Location.Coordinates.Latitude).NotEmpty().Must(x => BeAValidDouble(x!));
                    customer.RuleFor(x => x.Location.Coordinates.Longitude).NotEmpty().Must(x => BeAValidDouble(x!));

                    customer.RuleFor(x => x.Location.Timezone).NotNull();
                    customer.RuleFor(x => x.Location.Timezone.Offset).NotEmpty();
                    customer.RuleFor(x => x.Location.Timezone.Description).NotEmpty();

                    customer.RuleFor(x => x.Dob).NotNull();
                    customer.RuleFor(x => x.Dob.Date).NotNull().Must(x => BeAValidDate(x!.Value));

                    customer.RuleFor(x => x.Registered).NotNull();
                    customer.RuleFor(x => x.Registered.Date).NotNull().Must(x => BeAValidDate(x!.Value));

                    customer.RuleFor(x => x.Email).NotEmpty();
                    customer.RuleFor(x => x.Phone).NotEmpty();
                    customer.RuleFor(x => x.Cell).NotEmpty();

                    customer.RuleFor(x => x.Picture).NotNull();
                    customer.RuleFor(x => x.Picture.Large).NotEmpty();
                    customer.RuleFor(x => x.Picture.Medium).NotEmpty();
                    customer.RuleFor(x => x.Picture.Thumbnail).NotEmpty();
                });
        }

        private static bool BeIncludedInEnumDisplayNames<T>(string value) where T : struct, Enum
        {
            return Enum.GetValues<T>()
                .Select(x => x.GetDisplayName().ToLower()).ToList()
                .Contains(value);
        }

        private static bool BeAValidDouble(string value) => double.TryParse(value, out _);

        private static bool BeAValidDate(DateTime value) => value > DateTime.MinValue;
    }
}
