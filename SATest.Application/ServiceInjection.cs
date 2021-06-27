using Microsoft.Extensions.DependencyInjection;
using SATest.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SATest.Application
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
