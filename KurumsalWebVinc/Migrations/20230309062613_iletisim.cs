using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class iletisim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tanim",
                table: "IletisimBilgisis",
                newName: "MapKordinat");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "IletisimBilgisis",
                newName: "IsTel");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CepTel",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eposta1",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eposta2",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "CepTel",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "Eposta1",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "Eposta2",
                table: "IletisimBilgisis");

            migrationBuilder.RenameColumn(
                name: "MapKordinat",
                table: "IletisimBilgisis",
                newName: "Tanim");

            migrationBuilder.RenameColumn(
                name: "IsTel",
                table: "IletisimBilgisis",
                newName: "Aciklama");
        }
    }
}
