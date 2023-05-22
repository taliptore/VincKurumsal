using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class blog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogResim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SayfaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SayfaId = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
