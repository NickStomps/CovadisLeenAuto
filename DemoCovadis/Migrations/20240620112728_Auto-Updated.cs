using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class AutoUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Users_laatsteBestuurderId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_laatsteBestuurderId",
                table: "Autos");

            migrationBuilder.AlterColumn<int>(
                name: "laatsteBestuurderId",
                table: "Autos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "laatsteBestuurderId",
                table: "Autos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_laatsteBestuurderId",
                table: "Autos",
                column: "laatsteBestuurderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Users_laatsteBestuurderId",
                table: "Autos",
                column: "laatsteBestuurderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
