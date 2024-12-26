﻿using JSM.Application.Core;
using JSM.Application.Core.Interfaces;
using MediatR;

namespace JSM.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddScoped<ICsvHelper, CsvHelper>();
        }
    }
}
