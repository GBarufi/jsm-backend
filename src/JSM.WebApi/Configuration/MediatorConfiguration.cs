namespace JSM.WebApi.Configuration
{
    public static class MediatorConfiguration
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            Application.Configurations.MediatorConfiguration.Configure(services);
        }
    }
}
