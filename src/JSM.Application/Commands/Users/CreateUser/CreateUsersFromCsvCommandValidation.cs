using JSM.Application.Core;
using JSM.Application.Core.Interfaces;

namespace JSM.Application.Commands.Users.CreateUser
{
    public class CreateUsersFromCsvCommandValidation(ICsvHelper csvHelper) : CsvValidation<CreateUsersFromCsvCommand>(csvHelper)
    {
        public override string[] ExpectedFields => [
            "gender",
            "name__title",
            "name__first",
            "name__last",
            "location__street",
            "location__city",
            "location__state",
            "location__postcode",
            "location__coordinates__latitude",
            "location__coordinates__longitude",
            "location__timezone__offset",
            "location__timezone__description",
            "email",
            "dob__date",
            "dob__age",
            "registered__date",
            "registered__age",
            "phone",
            "cell",
            "picture__large",
            "picture__medium",
            "picture__thumbnail"
        ];
    }
}
