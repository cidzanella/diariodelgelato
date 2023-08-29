﻿// <auto-generated />
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiarioDelGelato.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230829104815_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("DiarioDelGelato.Domain.Entities.Gelato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gelato", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "0% lactose - 0% gordura",
                            Name = "Abacaxi com Hortelã"
                        },
                        new
                        {
                            Id = 2,
                            Description = "chocolate belga Callebaut com flocos de chocolate belga",
                            Name = "Brigadeiro Belga"
                        },
                        new
                        {
                            Id = 3,
                            Description = "delicado creme de canela",
                            Name = "Canella"
                        },
                        new
                        {
                            Id = 4,
                            Description = "café com toque de cacau e canela",
                            Name = "Cappuccino"
                        },
                        new
                        {
                            Id = 5,
                            Description = "tradicional doce de leite argentino com uma pitada de sal rosa do Himalaia",
                            Name = "Caramello Salato"
                        },
                        new
                        {
                            Id = 6,
                            Description = "intenso em cacau, para apreciadores de chocolate meio amargo",
                            Name = "Ciocco Fondente"
                        },
                        new
                        {
                            Id = 7,
                            Description = "leite ninho com Nutella",
                            Name = "Cremino"
                        },
                        new
                        {
                            Id = 8,
                            Description = "aquela combinação de cerejas e chocolate",
                            Name = "Floresta Negra"
                        },
                        new
                        {
                            Id = 9,
                            Description = "morango - 0% lactose - 0% gordura",
                            Name = "Fragola"
                        },
                        new
                        {
                            Id = 10,
                            Description = "frutas vermelhas - 0% lactose - 0% gordura",
                            Name = "Frutti di Bosco"
                        },
                        new
                        {
                            Id = 11,
                            Description = "maracujá - 0% lactose - 0% gordura",
                            Name = "Frutto della Passione"
                        },
                        new
                        {
                            Id = 12,
                            Description = "gelato de chocolate ao leite com um delicado toque de rum Havana",
                            Name = "Havana"
                        },
                        new
                        {
                            Id = 13,
                            Description = "amora - 0% lactose - 0% gordura",
                            Name = "La Mora"
                        },
                        new
                        {
                            Id = 14,
                            Description = "passas ao rum à moda italiana, com uva Málaga ao vinho Marsalla",
                            Name = "Málaga"
                        },
                        new
                        {
                            Id = 15,
                            Description = "gelato de sabor refinado, preparado com amêndoas tostadas",
                            Name = "Mandorla Tostata"
                        },
                        new
                        {
                            Id = 16,
                            Description = "manga - 0% lactose - 0% gordura",
                            Name = "Mango"
                        },
                        new
                        {
                            Id = 17,
                            Description = "menta com flocos de chocolate italiano",
                            Name = "Menta Cioccolato"
                        },
                        new
                        {
                            Id = 18,
                            Description = "baunilha francesa com cerejas silvestres Amarena",
                            Name = "Mon Chéri"
                        },
                        new
                        {
                            Id = 19,
                            Description = "delícias da infância ... o sabor do leite ninho num gelato cremoso",
                            Name = "Ninho"
                        },
                        new
                        {
                            Id = 20,
                            Description = "avelã pura, levemente tostada",
                            Name = "Nocciola"
                        },
                        new
                        {
                            Id = 21,
                            Description = "chocolate ao leite com um delicado creme de avelãs crocantes",
                            Name = "Nocciolino"
                        },
                        new
                        {
                            Id = 22,
                            Description = "gelato bem brasileiro, com o tradicional sabor desse doce de amendoim ",
                            Name = "Pé de Moleque"
                        },
                        new
                        {
                            Id = 23,
                            Description = "chocolate branco com amêndoas e coco",
                            Name = "Perdonato"
                        },
                        new
                        {
                            Id = 24,
                            Description = "pistache puro",
                            Name = "Pistacchio"
                        },
                        new
                        {
                            Id = 25,
                            Description = "limão siciliano com vergamota - 0% lactose - 0% gordura",
                            Name = "Spirito Siciliano"
                        },
                        new
                        {
                            Id = 26,
                            Description = "nosso fiodilatte com flocos de chocolate belga Callebaut meio amargo ",
                            Name = "Stracciatella"
                        },
                        new
                        {
                            Id = 27,
                            Description = "creme de Mascarpone com doce de leite argentino",
                            Name = "Torta Belga"
                        },
                        new
                        {
                            Id = 28,
                            Description = "0% lactose - 0% gordura",
                            Name = "Uva"
                        },
                        new
                        {
                            Id = 29,
                            Description = "baunilha especial de Madagascar com mescla de biscoitos de cacau em creme de chocolate ao leite",
                            Name = "Vaniglia Bourbon"
                        },
                        new
                        {
                            Id = 30,
                            Description = "gelato de iogurte com cerejas silvestres italianas",
                            Name = "Yogurt all'Amarena"
                        },
                        new
                        {
                            Id = 31,
                            Description = "aquele que lembra um danoninho",
                            Name = "Yogurt alla Fragola"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
