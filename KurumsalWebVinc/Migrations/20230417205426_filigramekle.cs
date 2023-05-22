using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    public partial class filigramekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FiligramYazi",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FiligramYaziEklensinmi",
                table: "GenelBilgilers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiligramYazi",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "FiligramYaziEklensinmi",
                table: "GenelBilgilers");
        }
    }
}
