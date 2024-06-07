using DiarioDelGelato.Application.Interfaces.Services.Entities;
using DiarioDelGelato.Application.Services.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application
{
    public static class ServicesRegistration
    {
        // services extensions for the application core
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IGelatoService, GelatoService>();
            services.AddScoped<IConoDelGiornoService, ConoDelGiornoService>();
            return services;
        }
    }
}
