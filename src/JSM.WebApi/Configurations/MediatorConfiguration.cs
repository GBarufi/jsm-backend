using JSM.Application.Core.Utils;

namespace JSM.WebApi.Configurations
{
    public static class MediatorConfiguration
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyUtils.GetApplicationProjectAssembly()));
        }
    }
}
