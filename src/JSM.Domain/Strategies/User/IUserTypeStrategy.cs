using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.User
{
    public interface IUserTypeStrategy
    {
        public UserType Type { get; }
        public bool UserBelongsToType(double latitude, double longitude);
    }
}
