using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class servisurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServisDetays_Servislers_ServislerId",
                table: "ServisDetays");

            migrationBuilder.DropIndex(
                name: "IX_ServisDetays_ServislerId",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "ServislerId",
                table: "ServisDetays");

            migrationBuilder.AddColumn<string>(
                name: "ServisUrl",
                table: "Servislers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServisUrl",
                table: "Servislers");

            migrationBuilder.AddColumn<int>(
                name: "ServislerId",
                table: "ServisDetays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServisDetays_ServislerId",
                table: "ServisDetays",
                column: "ServislerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServisDetays_Servislers_ServislerId",
                table: "ServisDetays",
                column: "ServislerId",
                principalTable: "Servislers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
