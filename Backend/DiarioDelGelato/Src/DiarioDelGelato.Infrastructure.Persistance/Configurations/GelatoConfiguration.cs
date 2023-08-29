using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Configurations
{
    public class GelatoConfiguration : IEntityTypeConfiguration<Gelato>
    {
        public void Configure(EntityTypeBuilder<Gelato> builder)
        {
            builder.ToTable("Gelato");

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Description)
                .HasMaxLength(100);

            SeedGelato(builder);

        }

        private static void SeedGelato(EntityTypeBuilder<Gelato> builder)
        {
            builder.HasData(
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
        }
    }
}