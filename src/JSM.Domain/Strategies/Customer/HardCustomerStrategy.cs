using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.Customer
{
    public class HardCustomerStrategy : ICustomerTypeStrategy
    {
        public CustomerType Type => CustomerType.Hard;

        public bool CustomerBelongsToType(double latitude, double longitude) =>
            latitude >= -52.997614 && latitude <= -44.428305 &&
            longitude >= -23.966413 && longitude <= -19.766959;
    }
}
