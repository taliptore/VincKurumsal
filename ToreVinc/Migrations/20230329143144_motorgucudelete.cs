using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class motorgucudelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_MotorGucus_MotorGucuId",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_MotorGucuId",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "MotorGucuId",
                table: "AracBilgisis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorGucuId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_MotorGucuId",
                table: "AracBilgisis",
                column: "MotorGucuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_MotorGucus_MotorGucuId",
                table: "AracBilgisis",
                column: "MotorGucuId",
                principalTable: "MotorGucus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
