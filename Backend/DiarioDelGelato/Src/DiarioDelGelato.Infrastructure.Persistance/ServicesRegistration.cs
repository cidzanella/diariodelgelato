using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Infrastructure.Persistance.Repositories;
using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Infrastructure.Persistance.Services;

namespace DiarioDelGelato.Infrastructure.Persistance
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddPersistanceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string ?dbProvider = configuration.GetValue<string>("DBProvider").ToUpper();

            switch (dbProvider)
            {
                case "INMEMORYDATABASE":
                    services.AddDbContext<ApplicationDbContext>(options => 
                        {
                            options.UseInMemoryDatabase(configuration.GetConnectionString("InMemoryConnection"));
                        });
                    break;
                case "SQLSERVER":
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
                    });
                    break;
                case "SQLITE":
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
                    });
                    break;
                default:
                    break;
            }

            services.AddScoped<IGelatoRepositoryAsync, GelatoRepositoryAsync>();
            services.AddScoped<IConoDelGiornoRepositoryAsync, ConoDelGiornoRespositoryAsync>();
            services.AddScoped<ITeamRepositoryAsync, TeamRepositoryAsync>();
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();

            return services;

        }

    }
}
