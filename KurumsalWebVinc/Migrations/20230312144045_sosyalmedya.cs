using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class sosyalmedya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tanim",
                table: "SosyalMedyaBilgileris",
                newName: "Youtube");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "SosyalMedyaBilgileris",
                newName: "Whatsapp");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "SosyalMedyaBilgileris",
                newName: "Tanim");

            migrationBuilder.RenameColumn(
                name: "Whatsapp",
                table: "SosyalMedyaBilgileris",
                newName: "Aciklama");
        }
    }
}
