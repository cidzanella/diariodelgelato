using DiarioDelGelato.Application.Extensions;
using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Services
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;

        public DatabaseSeeder(ApplicationDbContext dbContext, IPasswordService passwordService, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _configuration = configuration;
        }
        public void Seed()
        {
            SeedAdminUserAsync();
            SeedGelatosAsync();
            SeedTeamAsync();
        }

        private async Task SeedTeamAsync()
        {
            // checks if database was already seeded
            if (_dbContext.Team.Any())
                return;

            // compose work shifts
            long startBreakA = new DateTime().TimeToUnixTimestampUtc(15, 30);
            long stopBreakA = new DateTime().TimeToUnixTimestampUtc(15, 45);

            long startBreakB = new DateTime().TimeToUnixTimestampUtc(20, 15);
            long stopBreakB = new DateTime().TimeToUnixTimestampUtc(20, 30);

            long startWorkTurnoSemanaTarde = new DateTime().TimeToUnixTimestampUtc(12, 40);
            long stopWorkTurnoSemanaTarde = new DateTime().TimeToUnixTimestampUtc(18, 30);

            long startWorkTurnoSemanaNoite = new DateTime().TimeToUnixTimestampUtc(18, 30);
            long stopWorkTurnoSemanaNoite = new DateTime().TimeToUnixTimestampUtc(22, 30);

            long startWorkTurnoFindiTarde = new DateTime().TimeToUnixTimestampUtc(11, 30);
            long stopWorkTurnoFindiTarde = new DateTime().TimeToUnixTimestampUtc(17, 30);

            long startWorkTurnoFindiNoite = new DateTime().TimeToUnixTimestampUtc(16, 30);
            long stopWorkTurnoFindiNoite = new DateTime().TimeToUnixTimestampUtc(22, 30);

            long startWorkProducao = new DateTime().TimeToUnixTimestampUtc(08, 00);
            long stopWorkProducao = new DateTime().TimeToUnixTimestampUtc(12, 00);

            await _dbContext.Team.AddRangeAsync(
                new TeamMember
                {
                    Id = 1001,
                    FullName = "Cid Zanella",
                    PersonalId = "45220087",
                    BreakStartHour = startBreakA,
                    BreakStopHour = stopBreakA,
                    HasCredential = false,
                    WorkStartHour = startWorkTurnoSemanaTarde,
                    WorkStopHour = stopWorkTurnoSemanaTarde,
                    Photo = string.Empty
                },
                new TeamMember
                {
                    Id = 1002,
                    FullName = "Suélen Maino Zanella",
                    PersonalId = "96548206",
                    BreakStartHour = startBreakB,
                    BreakStopHour = stopBreakB,
                    HasCredential = false,
                    WorkStartHour = startWorkTurnoSemanaNoite,
                    WorkStopHour = stopWorkTurnoSemanaNoite,
                    Photo = string.Empty
                }
            );
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedGelatosAsync()
        {
            // check for data already seeded in database
            if (_dbContext.Gelatos.Any())
                return; 

            // gelatos seeds
            await _dbContext.Gelatos.AddRangeAsync(
                new Gelato { Id = 1, Name = "Abacaxi com Hortelã", Description = "0% lactose - 0% gordura" },
                new Gelato { Id = 2, Name = "Brigadeiro Belga", Description = "chocolate belga Callebaut com flocos de chocolate belga" },
                new Gelato { Id = 3, Name = "Canella", Description = "delicado creme de canela" },
                new Gelato { Id = 4, Name = "Cappuccino", Description = "café com toque de cacau e canela" },
                new Gelato { Id = 5, Name = "Caramello Salato", Description = "tradicional doce de leite argentino com uma pitada de sal rosa do Himalaia" },
                new Gelato { Id = 6, Name = "Ciocco Fondente", Description = "intenso em cacau, para apreciadores de chocolate meio amargo" },
                new Gelato { Id = 7, Name = "Cremino", Description = "leite ninho com Nutella" },
                new Gelato { Id = 8, Name = "Floresta Negra", Description = "aquela combinação de cerejas e chocolate" },
                new Gelato { Id = 9, Name = "Fragola", Description = "morango - 0% lactose - 0% gordura" },
                new Gelato { Id = 10, Name = "Frutti di Bosco", Description = "frutas vermelhas - 0% lactose - 0% gordura" },
                new Gelato { Id = 11, Name = "Frutto della Passione", Description = "maracujá - 0% lactose - 0% gordura" },
                new Gelato { Id = 12, Name = "Havana", Description = "gelato de chocolate ao leite com um delicado toque de rum Havana" },
                new Gelato { Id = 13, Name = "La Mora", Description = "amora - 0% lactose - 0% gordura" },
                new Gelato { Id = 14, Name = "Málaga", Description = "passas ao rum à moda italiana, com uva Málaga ao vinho Marsalla" },
                new Gelato { Id = 15, Name = "Mandorla Tostata", Description = "gelato de sabor refinado, preparado com amêndoas tostadas" },
                new Gelato { Id = 16, Name = "Mango", Description = "manga - 0% lactose - 0% gordura" },
                new Gelato { Id = 17, Name = "Menta Cioccolato", Description = "menta com flocos de chocolate italiano" },
                new Gelato { Id = 18, Name = "Mon Chéri", Description = "baunilha francesa com cerejas silvestres Amarena" },
                new Gelato { Id = 19, Name = "Ninho", Description = "delícias da infância ... o sabor do leite ninho num gelato cremoso" },
                new Gelato { Id = 20, Name = "Nocciola", Description = "avelã pura, levemente tostada" },
                new Gelato { Id = 21, Name = "Nocciolino", Description = "chocolate ao leite com um delicado creme de avelãs crocantes" },
                new Gelato { Id = 22, Name = "Pé de Moleque", Description = "gelato bem brasileiro, com o tradicional sabor desse doce de amendoim " },
                new Gelato { Id = 23, Name = "Perdonato", Description = "chocolate branco com amêndoas e coco" },
                new Gelato { Id = 24, Name = "Pistacchio", Description = "pistache puro" },
                new Gelato { Id = 25, Name = "Spirito Siciliano", Description = "limão siciliano com vergamota - 0% lactose - 0% gordura" },
                new Gelato { Id = 26, Name = "Stracciatella", Description = "nosso fiodilatte com flocos de chocolate belga Callebaut meio amargo " },
                new Gelato { Id = 27, Name = "Torta Belga", Description = "creme de Mascarpone com doce de leite argentino" },
                new Gelato { Id = 28, Name = "Uva", Description = "0% lactose - 0% gordura" },
                new Gelato { Id = 29, Name = "Vaniglia Bourbon", Description = "baunilha especial de Madagascar com mescla de biscoitos de cacau em creme de chocolate ao leite" },
                new Gelato { Id = 30, Name = "Yogurt all'Amarena", Description = "gelato de iogurte com cerejas silvestres italianas" },
                new Gelato { Id = 31, Name = "Yogurt alla Fragola", Description = "aquele que lembra um danoninho" }
            );
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedAdminUserAsync()
        {
            // check if database was already seeded
            if (_dbContext.Users.Any(u => u.IsAdmin))
                return;

            // appsettings.json has AdminUser credentials in development
            // in production there will be environment variables or Azure Key Vault
            // windows prompt command to create the environment variables:
            // setx AdminUser__UserName "admin"
            // setx AdminUser__Password "YourSecureAdminPassword"

            // gets data from configuration secrets
            var adminUserName = _configuration["AdminUser:UserName"];
            var adminPassword = _configuration["AdminUser:Password"];
            if (String.IsNullOrWhiteSpace(adminUserName) || String.IsNullOrWhiteSpace(adminPassword))
                throw new Exception("Admin username and password must be set in the configuration.");

            // generate password hash and salt
            _passwordService.CreatePasswordHash(adminPassword, out string adminPasswordHash, out string adminPasswordSalt);
            if (String.IsNullOrWhiteSpace(adminPasswordHash) || String.IsNullOrWhiteSpace(adminPasswordSalt))
                throw new Exception("Error setting up AdminUser credentials.");

            // check if user already seeded in database
            if (_dbContext.Users.Any(u => u.UserName.ToLower() == adminUserName.ToLower()))
                return;

            // add adminUser to Users database
            await _dbContext.Users.AddAsync(new User
            {
                Id = 1000,
                TeamMemberId = 0,
                UserName = adminUserName,
                IsAdmin = true,
                IsEnabled = true,
                PasswordHash = adminPasswordHash,
                PasswordSalt = adminPasswordSalt
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
