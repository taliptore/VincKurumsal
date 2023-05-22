using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class image2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.RenameColumn(
                name: "ResimYol",
                table: "Resimlers",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "ResimAciklama",
                table: "Resimlers",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Resimlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Baslik",
                table: "Resimlers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "Baslik",
                table: "Resimlers");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Resimlers",
                newName: "ResimYol");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Resimlers",
                newName: "ResimAciklama");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }
    }
}
