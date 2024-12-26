using JSM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JSM.Persistence.Contexts
{
    public class JsmContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLocation> Locations { get; set; }
        public DbSet<CustomerPortrait> Portraits { get; set; }
    }
}
