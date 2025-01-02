using JSM.Application.Core;
using JSM.Application.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JSM.Application.Commands.Users.CreateUser
{
    public record CreateUsersFromCsvCommand : CsvRequestBase<int>
    {
        public override bool IsValid(ICsvHelper? csvHelper)
        {
            if (csvHelper is null)
                return false;

            ValidationResult = new CreateUsersFromCsvCommandValidation(csvHelper).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
