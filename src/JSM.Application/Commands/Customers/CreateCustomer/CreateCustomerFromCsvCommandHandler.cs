using MediatR;
using JSM.Application.Core.Interfaces;
using JSM.Application.Mappers.Customers;
using JSM.Application.Dtos;
using JSM.Domain.Enums;
using JSM.Domain.Models;
using JSM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JSM.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerFromCsvCommandHandler : IRequestHandler<CreateCustomerFromCsvCommand, int>
    {
        private readonly IDbContextFactory<JsmContext> _dbContextFactory;
        private readonly ICsvHelper _csvHelper;

        public CreateCustomerFromCsvCommandHandler(IDbContextFactory<JsmContext> dbContextFactory, ICsvHelper csvHelper)
        {
            _dbContextFactory = dbContextFactory;
            _csvHelper = csvHelper;
        }

        public async Task<int> Handle(CreateCustomerFromCsvCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var csvData = _csvHelper.ImportCsv<CustomerCsvDto, CustomerCsvMapper>(request.Content!).ToList();

            foreach (var csvRow in csvData)
            {
                var newCustomer = new Customer(
                    CustomerType.Normal,
                    CustomerGender.M,
                    csvRow.Name.Title,
                    csvRow.Name.First,
                    csvRow.Name.Last,
                    csvRow.Email,
                    DateTime.Now,
                    DateTime.Now,
                    [csvRow.Phone],
                    [csvRow.Cell],
                    CustomerNationality.BR,
                    new CustomerLocation(
                        LocationRegion.South,
                        csvRow.Location.Street,
                        csvRow.Location.City,
                        csvRow.Location.State,
                        csvRow.Location.PostCode,
                        csvRow.Location.Coordinates.Latitude,
                        csvRow.Location.Coordinates.Longitude,
                        csvRow.Location.Timezone.Offset,
                        csvRow.Location.Timezone.Description
                    ),
                    new CustomerPortrait(
                        csvRow.Picture.Large,
                        csvRow.Picture.Medium,
                        csvRow.Picture.Thumbnail
                    )
                );

                await dbContext.Customers.AddAsync(newCustomer, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
