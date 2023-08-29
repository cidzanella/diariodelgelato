using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiarioDelGelato.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gelato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gelato", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gelato",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "0% lactose - 0% gordura", "Abacaxi com Hortelã" },
                    { 2, "chocolate belga Callebaut com flocos de chocolate belga", "Brigadeiro Belga" },
                    { 3, "delicado creme de canela", "Canella" },
                    { 4, "café com toque de cacau e canela", "Cappuccino" },
                    { 5, "tradicional doce de leite argentino com uma pitada de sal rosa do Himalaia", "Caramello Salato" },
                    { 6, "intenso em cacau, para apreciadores de chocolate meio amargo", "Ciocco Fondente" },
                    { 7, "leite ninho com Nutella", "Cremino" },
                    { 8, "aquela combinação de cerejas e chocolate", "Floresta Negra" },
                    { 9, "morango - 0% lactose - 0% gordura", "Fragola" },
                    { 10, "frutas vermelhas - 0% lactose - 0% gordura", "Frutti di Bosco" },
                    { 11, "maracujá - 0% lactose - 0% gordura", "Frutto della Passione" },
                    { 12, "gelato de chocolate ao leite com um delicado toque de rum Havana", "Havana" },
                    { 13, "amora - 0% lactose - 0% gordura", "La Mora" },
                    { 14, "passas ao rum à moda italiana, com uva Málaga ao vinho Marsalla", "Málaga" },
                    { 15, "gelato de sabor refinado, preparado com amêndoas tostadas", "Mandorla Tostata" },
                    { 16, "manga - 0% lactose - 0% gordura", "Mango" },
                    { 17, "menta com flocos de chocolate italiano", "Menta Cioccolato" },
                    { 18, "baunilha francesa com cerejas silvestres Amarena", "Mon Chéri" },
                    { 19, "delícias da infância ... o sabor do leite ninho num gelato cremoso", "Ninho" },
                    { 20, "avelã pura, levemente tostada", "Nocciola" },
                    { 21, "chocolate ao leite com um delicado creme de avelãs crocantes", "Nocciolino" },
                    { 22, "gelato bem brasileiro, com o tradicional sabor desse doce de amendoim ", "Pé de Moleque" },
                    { 23, "chocolate branco com amêndoas e coco", "Perdonato" },
                    { 24, "pistache puro", "Pistacchio" },
                    { 25, "limão siciliano com vergamota - 0% lactose - 0% gordura", "Spirito Siciliano" },
                    { 26, "nosso fiodilatte com flocos de chocolate belga Callebaut meio amargo ", "Stracciatella" },
                    { 27, "creme de Mascarpone com doce de leite argentino", "Torta Belga" },
                    { 28, "0% lactose - 0% gordura", "Uva" },
                    { 29, "baunilha especial de Madagascar com mescla de biscoitos de cacau em creme de chocolate ao leite", "Vaniglia Bourbon" },
                    { 30, "gelato de iogurte com cerejas silvestres italianas", "Yogurt all'Amarena" },
                    { 31, "aquele que lembra um danoninho", "Yogurt alla Fragola" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gelato");
        }
    }
}
