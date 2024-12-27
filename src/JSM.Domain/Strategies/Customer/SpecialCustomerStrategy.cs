using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.Customer
{
    public class SpecialCustomerStrategy : ICustomerTypeStrategy
    {
        public CustomerType Type => CustomerType.Special;

        public bool CustomerBelongsToType(double latitude, double longitude) =>
            latitude >= -46.361899 && latitude <= -34.276938 &&
            longitude >= -15.411580 && longitude <= -2.196998;
    }
}
