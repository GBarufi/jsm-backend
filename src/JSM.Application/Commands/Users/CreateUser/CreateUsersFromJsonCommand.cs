using JSM.Application.Core;
using JSM.Application.Dtos.Users;
using Newtonsoft.Json;

namespace JSM.Application.Commands.Users.CreateUser
{
    public record CreateUsersFromJsonCommand : RequestBase<int>
    {
        [JsonProperty("Results")]
        public List<UserInputDto>? UsersList { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new CreateUsersFromJsonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
