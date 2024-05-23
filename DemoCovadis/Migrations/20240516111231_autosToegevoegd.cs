using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class autosToegevoegd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kenteken = table.Column<string>(type: "TEXT", nullable: false),
                    beginStandKm = table.Column<int>(type: "INTEGER", nullable: false),
                    eindStandKm = table.Column<int>(type: "INTEGER", nullable: false),
                    bestuurderId = table.Column<int>(type: "INTEGER", nullable: false),
                    beginAdres = table.Column<string>(type: "TEXT", nullable: false),
                    eindAdres = table.Column<string>(type: "TEXT", nullable: false),
                    vertrekTijd = table.Column<string>(type: "TEXT", nullable: false),
                    aankomstTijd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Users_bestuurderId",
                        column: x => x.bestuurderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_bestuurderId",
                table: "Autos",
                column: "bestuurderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");
        }
    }
}
