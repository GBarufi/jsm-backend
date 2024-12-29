using JSM.Application.Core.Utils;
using JSM.Domain.Enums;
using JSM.Domain.Extensions;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromJsonCommandHandler : IRequestHandler<CreateCustomerFromJsonCommand, int>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;

        public CreateCustomerFromJsonCommandHandler(IDbContextFactory<JsmContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<int> Handle(CreateCustomerFromJsonCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var customersToAdd = request.CustomersList;

            foreach (var customer in customersToAdd)
            {
                var newCustomer = new Customer(
                    customer.Gender!.GetEnumValueFromDisplayName<CustomerGender>(),
                    customer.Name.Title!,
                    customer.Name.First!,
                    customer.Name.Last!,
                    customer.Email!,
                    customer.Dob.Date!.Value,
                    customer.Registered.Date!.Value,
                    PhoneUtils.ConvertToE164(customer.Phone!),
                    PhoneUtils.ConvertToE164(customer.Cell!),
                    CustomerNationality.BR,
                    new CustomerLocation(
                        customer.Location.Street!,
                        customer.Location.City!,
                        customer.Location.State!,
                        customer.Location.PostCode!,
                        customer.Location.Coordinates.Latitude!,
                        customer.Location.Coordinates.Longitude!,
                        customer.Location.Timezone.Offset!,
                        customer.Location.Timezone.Description!
                    ),
                    new CustomerPortrait(
                        customer.Picture.Large!,
                        customer.Picture.Medium!,
                        customer.Picture.Thumbnail!
                    )
                );

                await dbContext.Customers.AddAsync(newCustomer, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
