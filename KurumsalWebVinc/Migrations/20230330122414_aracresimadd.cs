using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class aracresimadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracResim_AracBilgisis_AracBilgisiId",
                table: "AracResim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracResim",
                table: "AracResim");

            migrationBuilder.RenameTable(
                name: "AracResim",
                newName: "AracResims");

            migrationBuilder.RenameIndex(
                name: "IX_AracResim_AracBilgisiId",
                table: "AracResims",
                newName: "IX_AracResims_AracBilgisiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracResims",
                table: "AracResims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracResims_AracBilgisis_AracBilgisiId",
                table: "AracResims",
                column: "AracBilgisiId",
                principalTable: "AracBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracResims_AracBilgisis_AracBilgisiId",
                table: "AracResims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracResims",
                table: "AracResims");

            migrationBuilder.RenameTable(
                name: "AracResims",
                newName: "AracResim");

            migrationBuilder.RenameIndex(
                name: "IX_AracResims_AracBilgisiId",
                table: "AracResim",
                newName: "IX_AracResim_AracBilgisiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracResim",
                table: "AracResim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracResim_AracBilgisis_AracBilgisiId",
                table: "AracResim",
                column: "AracBilgisiId",
                principalTable: "AracBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
