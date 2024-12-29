using FluentValidation;
using JSM.Application.Core.Interfaces;
using JSM.Application.Dtos.Customers;

namespace JSM.Application.Core
{
    public abstract class CsvValidation<T> : AbstractValidator<T> where T : ICsvRequest
    {
        public abstract string[] ExpectedFields { get; }
        public CsvValidation(ICsvHelper csvHelper)
        {
            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Must(content => csvHelper.ValidateCsv<CustomerCsvDto>(content!, ExpectedFields));
        }
    }
}
