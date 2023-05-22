using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class raporcreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracRapor_AracBilgisis_AracBilgisiId1",
                table: "AracRapor");

            migrationBuilder.DropIndex(
                name: "IX_AracRapor_AracBilgisiId1",
                table: "AracRapor");

            migrationBuilder.DropColumn(
                name: "AracBilgisiId1",
                table: "AracRapor");

            migrationBuilder.AlterColumn<int>(
                name: "AracBilgisiId",
                table: "AracRapor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracRapor_AracBilgisis_AracBilgisiId",
                table: "AracRapor");

            migrationBuilder.DropIndex(
                name: "IX_AracRapor_AracBilgisiId",
                table: "AracRapor");

            migrationBuilder.AlterColumn<string>(
                name: "AracBilgisiId",
                table: "AracRapor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AracBilgisiId1",
                table: "AracRapor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracRapor_AracBilgisiId1",
                table: "AracRapor",
                column: "AracBilgisiId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AracRapor_AracBilgisis_AracBilgisiId1",
                table: "AracRapor",
                column: "AracBilgisiId1",
                principalTable: "AracBilgisis",
                principalColumn: "Id");
        }
    }
}
