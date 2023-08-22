using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection services, IConfiguration configuration)
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
        }

    }
}
