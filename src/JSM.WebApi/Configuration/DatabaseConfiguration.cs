using JSM.Persistence.Configurations;

namespace JSM.WebApi.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureInMemoryDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            InMemoryDatabaseConfiguration.Configure(services, configuration.GetConnectionString("Database")!);
        }
    }
}
