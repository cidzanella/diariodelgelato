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
    public static class ServicesDependencyInjection
    {
        // services extensions for the application core
        public static void AddApplicationLayer(this IServiceCollection services )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
