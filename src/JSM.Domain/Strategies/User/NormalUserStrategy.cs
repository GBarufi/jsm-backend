using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.User
{
    public class NormalUserStrategy : IUserTypeStrategy
    {
        public UserType Type => UserType.Normal;

        public bool UserBelongsToType(double latitude, double longitude) =>
            latitude >= -54.777426 && latitude <= -46.603598 &&
            longitude >= -34.016466 && longitude <= -26.155681;
    }
}
