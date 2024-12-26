using JSM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JSM.Persistence.Configurations
{
    public static class InMemoryDatabaseConfiguration
    {
        public static void Configure(IServiceCollection services, string dbName)
        {
            services.AddDbContext<JsmContext>(options => 
                options.UseInMemoryDatabase(dbName));
        }
    }
}
