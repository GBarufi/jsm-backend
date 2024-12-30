using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.User
{
    public class HardUserStrategy : IUserTypeStrategy
    {
        public UserType Type => UserType.Hard;

        public bool UserBelongsToType(double latitude, double longitude) =>
            latitude >= -52.997614 && latitude <= -44.428305 &&
            longitude >= -23.966413 && longitude <= -19.766959;
    }
}
