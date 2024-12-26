using JSM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JSM.Persistence.Configurations
{
    public static class InMemoryDatabaseConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<JsmContext>(options => 
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        }
    }
}
