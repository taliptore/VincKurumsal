using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    public partial class talepaddcolum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BulSehirId",
                table: "TalepFormus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GitSehirId",
                table: "TalepFormus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ServislerId",
                table: "TalepFormus",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BulSehirId",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "GitSehirId",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "ServislerId",
                table: "TalepFormus");
        }
    }
}
