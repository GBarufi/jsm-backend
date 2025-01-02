using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.User
{
    public class SpecialUserStrategy : IUserTypeStrategy
    {
        public UserType Type => UserType.Special;

        public bool UserBelongsToType(double latitude, double longitude) =>
            latitude >= -46.361899 && latitude <= -34.276938 &&
            longitude >= -15.411580 && longitude <= -2.196998;
    }
}
