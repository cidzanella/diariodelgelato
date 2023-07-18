using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                            options.UseInMememoryDatabase(configuration.GetConnectionString("InMemoryConnection"));
                        });
                    break;
                case "SQLSERVER":
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));
                    });
                    break;
                case "SQLITE":
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
                    });
                    break;
                default:
                    break;
            }

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                configuration.GetConnectionString("sqlserver");
            } else
            {
                if (configuration.GetValue<string>("DBProvider").ToLower().Equals("mssql"))
                {

                }
            }
        }

    }
}
