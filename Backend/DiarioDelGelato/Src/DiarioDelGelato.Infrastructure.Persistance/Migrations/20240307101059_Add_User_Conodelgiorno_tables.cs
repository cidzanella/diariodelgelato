using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiarioDelGelato.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Conodelgiorno_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConoDelGiornoJournal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamMemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    GelatoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    GelatoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConoDelGiornoJournal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WorkStartHour = table.Column<long>(type: "INTEGER", nullable: false),
                    WorkStopHour = table.Column<long>(type: "INTEGER", nullable: false),
                    BreakStartHour = table.Column<long>(type: "INTEGER", nullable: false),
                    BreakStopHour = table.Column<long>(type: "INTEGER", nullable: false),
                    HasCredential = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "BreakStartHour", "BreakStopHour", "FullName", "HasCredential", "IsAdmin", "PasswordHash", "PasswordSalt", "Photo", "UserName", "WorkStartHour", "WorkStopHour" },
                values: new object[,]
                {
                    { 1, 55800L, 56700L, "Cid Zanella", false, true, null, null, "", "", 45600L, 66600L },
                    { 2, 72900L, 73800L, "Suélen Maino Zanella", false, true, null, null, "", "", 66600L, 81000L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConoDelGiornoJournal");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
