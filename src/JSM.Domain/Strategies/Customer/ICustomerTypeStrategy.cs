using JSM.Domain.Enums;

namespace JSM.Domain.Strategies.Customer
{
    public interface ICustomerTypeStrategy
    {
        public CustomerType Type { get; }
        public bool CustomerBelongsToType(double latitude, double longitude);
    }
}
