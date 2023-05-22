using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class markakodukoy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AracMarkaKOD",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AracModelKOD",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AracMarkaKOD",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "AracModelKOD",
                table: "AracBilgisis");
        }
    }
}
