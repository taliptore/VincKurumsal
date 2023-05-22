using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class raportekli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracRapor_AracBilgisis_AracBilgisiId",
                table: "AracRapor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracRapor",
                table: "AracRapor");

            migrationBuilder.DropIndex(
                name: "IX_AracRapor_AracBilgisiId",
                table: "AracRapor");

            migrationBuilder.RenameTable(
                name: "AracRapor",
                newName: "AracRapors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracRapors",
                table: "AracRapors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AracRapors_AracBilgisiId",
                table: "AracRapors",
                column: "AracBilgisiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AracRapors_AracBilgisis_AracBilgisiId",
                table: "AracRapors",
                column: "AracBilgisiId",
                principalTable: "AracBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracRapors_AracBilgisis_AracBilgisiId",
                table: "AracRapors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracRapors",
                table: "AracRapors");

            migrationBuilder.DropIndex(
                name: "IX_AracRapors_AracBilgisiId",
                table: "AracRapors");

            migrationBuilder.RenameTable(
                name: "AracRapors",
                newName: "AracRapor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracRapor",
                table: "AracRapor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AracRapor_AracBilgisiId",
                table: "AracRapor",
                column: "AracBilgisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracRapor_AracBilgisis_AracBilgisiId",
                table: "AracRapor",
                column: "AracBilgisiId",
                principalTable: "AracBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
