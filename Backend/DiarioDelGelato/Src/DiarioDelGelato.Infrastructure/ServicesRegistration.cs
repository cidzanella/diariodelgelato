using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Infrastructure.Identity.Services;
using DiarioDelGelato.Infrastructure.Identity.Settings;
using DiarioDelGelato.Infrastructure.Services;
using DiarioDelGelato.Infrastructure.Services.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace DiarioDelGelato.Infrastructure
{
    public static class ServicesRegistration
    {
        // services extensions registration
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // add infrastructure services such as email, csv file builder, datetime, token, etc
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddJwtTokenAuthentication(configuration);
            services.AddMailService(configuration);
            return services;
        }

        private static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //bind JWTSettings
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecretKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        private static IServiceCollection AddMailService(this IServiceCollection services, IConfiguration configuration)
        {
            return services;

            //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            //services.AddScoped<IMailService, MailService>();
            //return services;
        }
    }
}
