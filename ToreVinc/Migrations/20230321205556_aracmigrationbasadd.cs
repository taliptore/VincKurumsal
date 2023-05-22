using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class aracmigrationbasadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelKodu = table.Column<int>(type: "int", nullable: false),
                    ModelAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracMarkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaKodu = table.Column<int>(type: "int", nullable: false),
                    MarkaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AracModelId = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracMarkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AracMarkas_AracModels_AracModelId",
                        column: x => x.AracModelId,
                        principalTable: "AracModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracMarkas_AracModelId",
                table: "AracMarkas",
                column: "AracModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracMarkas");

            migrationBuilder.DropTable(
                name: "AracModels");
        }
    }
}
