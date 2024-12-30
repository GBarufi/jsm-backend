using FluentValidation;
using JSM.Application.Core.Interfaces;
using JSM.Application.Dtos.Users;

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
                .Must(content => csvHelper.ValidateCsv<UserInputDto>(content!, ExpectedFields))
                .WithMessage($"The uploaded CSV columns don't match the expected columns. The expected columns are {string.Join(", ", ExpectedFields)}");
        }
    }
}
