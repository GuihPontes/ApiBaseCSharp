using Infra.Interfaces;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services.Intefaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class DependecyInjectionConfiguration
    {
        public static void AddDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
