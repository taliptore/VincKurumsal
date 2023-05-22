using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class mesaj1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idilan",
                table: "Mesajs");

            migrationBuilder.DropColumn(
                name: "UserIdAlici",
                table: "Mesajs");

            migrationBuilder.AddColumn<int>(
                name: "AracBilgisiId",
                table: "Mesajs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mesajs_AracBilgisiId",
                table: "Mesajs",
                column: "AracBilgisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesajs_AracBilgisis_AracBilgisiId",
                table: "Mesajs",
                column: "AracBilgisiId",
                principalTable: "AracBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesajs_AracBilgisis_AracBilgisiId",
                table: "Mesajs");

            migrationBuilder.DropIndex(
                name: "IX_Mesajs_AracBilgisiId",
                table: "Mesajs");

            migrationBuilder.DropColumn(
                name: "AracBilgisiId",
                table: "Mesajs");

            migrationBuilder.AddColumn<string>(
                name: "Idilan",
                table: "Mesajs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdAlici",
                table: "Mesajs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
