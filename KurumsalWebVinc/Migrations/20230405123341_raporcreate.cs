using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class raporcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracRapor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaporuDuzunleyenFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AracBilgisiId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AracBilgisiId1 = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracRapor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AracRapor_AracBilgisis_AracBilgisiId1",
                        column: x => x.AracBilgisiId1,
                        principalTable: "AracBilgisis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracRapor_AracBilgisiId1",
                table: "AracRapor",
                column: "AracBilgisiId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracRapor");
        }
    }
}
