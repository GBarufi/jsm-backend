using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.Customer
{
    public class NormalCustomerStrategy : ICustomerTypeStrategy
    {
        public CustomerType Type => CustomerType.Normal;

        public bool CustomerBelongsToType(double latitude, double longitude) =>
            latitude >= -54.777426 && latitude <= -46.603598 &&
            longitude >= -34.016466 && longitude <= -26.155681;
    }
}
