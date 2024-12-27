using JSM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JSM.Persistence.Contexts
{
    public class JsmContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerLocation> Locations => Set<CustomerLocation>();
        public DbSet<CustomerPortrait> Portraits => Set<CustomerPortrait>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JsmContext).Assembly);
        }
    }
}
