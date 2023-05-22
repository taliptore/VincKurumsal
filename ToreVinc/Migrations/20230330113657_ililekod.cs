using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class ililekod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SehirilBilgisiilKOD",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SehirilceBilgisiilceKOD",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SehirilBilgisiilKOD",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "SehirilceBilgisiilceKOD",
                table: "AracBilgisis");
        }
    }
}
