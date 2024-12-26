using MediatR;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromCsvCommandHandler : IRequestHandler<CreateCustomerFromCsvCommand, int>
    {
        public async Task<int> Handle(CreateCustomerFromCsvCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return 1;
        }
    }
}
