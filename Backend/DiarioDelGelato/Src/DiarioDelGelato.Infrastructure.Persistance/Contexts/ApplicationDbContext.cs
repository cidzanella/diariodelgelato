using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {
        }

        public DbSet<Gelato> Gelatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Gelatos
            modelBuilder.Entity<Gelato>()
                .HasData(
                    new Gelato { Name = "Abacaxi com Hortelã", Description = "0% lactose - 0% gordura" },
                    new Gelato { Name = "Brigadeiro Belga", Description = "chocolate belga Callebaut com flocos de chocolate belga" },
                    new Gelato { Name = "Canella", Description = "delicado creme de canela" },
                    new Gelato { Name = "Cappuccino", Description = "café com toque de cacau e canela" },
                    new Gelato { Name = "Caramello Salato", Description = "tradicional doce de leite argentino com uma pitada de sal rosa do Himalaia" },
                    new Gelato { Name = "Ciocco Fondente", Description = "intenso em cacau, para apreciadores de chocolate meio amargo" },
                    new Gelato { Name = "Cremino", Description = "leite ninho com Nutella" },
                    new Gelato { Name = "Floresta Negra", Description = "aquela combinação de cerejas e chocolate" },
                    new Gelato { Name = "Fragola", Description = "morango - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Frutti di Bosco", Description = "frutas vermelhas - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Frutto della Passione", Description = "maracujá - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Havana", Description = "gelato de chocolate ao leite com um delicado toque de rum Havana" },
                    new Gelato { Name = "La Mora", Description = "amora - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Málaga", Description = "passas ao rum à moda italiana, com uva Málaga ao vinho Marsalla" },
                    new Gelato { Name = "Mandorla Tostata", Description = "gelato de sabor refinado, preparado com amêndoas tostadas" },
                    new Gelato { Name = "Mango", Description = "manga - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Menta Cioccolato", Description = "menta com flocos de chocolate italiano" },
                    new Gelato { Name = "Mon Chéri", Description = "baunilha francesa com cerejas silvestres Amarena" },
                    new Gelato { Name = "Ninho", Description = "delícias da infância ... o sabor do leite ninho num gelato cremoso" },
                    new Gelato { Name = "Nocciola", Description = "avelã pura, levemente tostada" },
                    new Gelato { Name = "Nocciolino", Description = "chocolate ao leite com um delicado creme de avelãs crocantes" },
                    new Gelato { Name = "Pé de Moleque", Description = "gelato bem brasileiro, com o tradicional sabor desse doce de amendoim " },
                    new Gelato { Name = "Perdonato", Description = "chocolate branco com amêndoas e coco" },
                    new Gelato { Name = "Pistacchio", Description = "pistache puro" },
                    new Gelato { Name = "Spirito Siciliano", Description = "limão siciliano com vergamota - 0% lactose - 0% gordura" },
                    new Gelato { Name = "Stracciatella", Description = "nosso fiodilatte com flocos de chocolate belga Callebaut meio amargo " },
                    new Gelato { Name = "Torta Belga", Description = "creme de Mascarpone com doce de leite argentino" },
                    new Gelato { Name = "Uva", Description = "0% lactose - 0% gordura" },
                    new Gelato { Name = "Vaniglia Bourbon", Description = "baunilha especial de Madagascar com mescla de biscoitos de cacau em creme de chocolate ao leite" },
                    new Gelato { Name = "Yogurt all'Amarena", Description = "gelato de iogurte com cerejas silvestres italianas" },
                    new Gelato { Name = "Yogurt alla Fragola", Description = "aquele que lembra um danoninho" }
                );
        }
    }
}
