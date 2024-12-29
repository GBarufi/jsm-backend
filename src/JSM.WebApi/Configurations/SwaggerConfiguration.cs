using JSM.Application.Core.Utils;

namespace JSM.WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var applicationAssembly = AssemblyUtils.GetAssembly();
                var xmlFilename = $"{applicationAssembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
