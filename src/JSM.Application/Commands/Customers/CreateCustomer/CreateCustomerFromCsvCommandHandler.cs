using MediatR;
using JSM.Application.Core.Interfaces;
using JSM.Application.Mappers.Customers;
using JSM.Application.Dtos;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromCsvCommandHandler : IRequestHandler<CreateCustomerFromCsvCommand, int>
    {
        private readonly ICsvHelper _csvHelper;

        public CreateCustomerFromCsvCommandHandler(ICsvHelper csvHelper)
        {
            _csvHelper = csvHelper;
        }

        public async Task<int> Handle(CreateCustomerFromCsvCommand request, CancellationToken cancellationToken)
        {
            var result = _csvHelper.ImportCsv<CustomerCsvDto, CustomerCsvMapper>(request.Content!).ToList();

            await Task.CompletedTask;

            return 1;
        }
    }
}
