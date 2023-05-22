using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class useriliski : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AracBilgisis");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AracBilgisis",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_UserId",
                table: "AracBilgisis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AspNetUsers_UserId",
                table: "AracBilgisis",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AspNetUsers_UserId",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_UserId",
                table: "AracBilgisis");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AracBilgisis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AracBilgisis",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
