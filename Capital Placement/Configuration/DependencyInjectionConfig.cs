using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Data;
using Capital_Placement.Interfaces;
using Capital_Placement.Repository;
using Capital_Placement.Services;

namespace Capital_Placement.Configuration
{
    public static class DependencyInjectionConfig
    {
         public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CapitalPlacementContext>();

            services.AddScoped<IAppProgramService, AppProgramService>();

            services.AddScoped<IAppProgramRepository, AppProgramRepository>();
            
            services.AddScoped<IApplicationService, ApplicationService>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            return services;
        }
    }
}