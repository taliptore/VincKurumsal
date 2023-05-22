using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class blogkategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogKategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BlogKategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogKategoryId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogKategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogKategories_BlogKategories_BlogKategoryId",
                        column: x => x.BlogKategoryId,
                        principalTable: "BlogKategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogKategoryId",
                table: "Blogs",
                column: "BlogKategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogKategories_BlogKategoryId",
                table: "BlogKategories",
                column: "BlogKategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogKategories_BlogKategoryId",
                table: "Blogs",
                column: "BlogKategoryId",
                principalTable: "BlogKategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogKategories_BlogKategoryId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogKategories");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogKategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogKategoryId",
                table: "Blogs");
        }
    }
}
