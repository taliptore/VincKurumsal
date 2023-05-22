using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class userıdstring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AspNetUsers_UserId1",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_UserId1",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AracBilgisis");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AracBilgisis",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AracBilgisis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AracBilgisis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_UserId1",
                table: "AracBilgisis",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AspNetUsers_UserId1",
                table: "AracBilgisis",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
