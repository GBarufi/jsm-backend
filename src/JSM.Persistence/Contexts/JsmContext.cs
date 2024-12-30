using JSM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JSM.Persistence.Contexts
{
    public class JsmContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserLocation> Locations => Set<UserLocation>();
        public DbSet<UserPortrait> Portraits => Set<UserPortrait>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JsmContext).Assembly);
        }
    }
}
