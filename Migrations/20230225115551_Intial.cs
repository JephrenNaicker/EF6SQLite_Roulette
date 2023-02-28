using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF6SQLite_Roulette.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wheelBoards",
                columns: table => new
                {
                    wbId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wbNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    wbColour = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wheelBoards", x => x.wbId);
                });

            migrationBuilder.CreateTable(
                name: "wheelResults",
                columns: table => new
                {
                    wrId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wrNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    wrColour = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wheelResults", x => x.wrId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wheelBoards");

            migrationBuilder.DropTable(
                name: "wheelResults");
        }
    }
}
