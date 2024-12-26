using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JSM.Application.Configurations
{
    public static class MediatorConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
