using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class aracmigrationinlude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracMarkas_AracModels_AracModelId",
                table: "AracMarkas");

            migrationBuilder.DropIndex(
                name: "IX_AracMarkas_AracModelId",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "AracModelId",
                table: "AracMarkas");

            migrationBuilder.AddColumn<int>(
                name: "AracMarkaId",
                table: "AracModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AracMarkaKodu",
                table: "AracModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AracModels_AracMarkaId",
                table: "AracModels",
                column: "AracMarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracModels_AracMarkas_AracMarkaId",
                table: "AracModels",
                column: "AracMarkaId",
                principalTable: "AracMarkas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracModels_AracMarkas_AracMarkaId",
                table: "AracModels");

            migrationBuilder.DropIndex(
                name: "IX_AracModels_AracMarkaId",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "AracMarkaId",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "AracMarkaKodu",
                table: "AracModels");

            migrationBuilder.AddColumn<int>(
                name: "AracModelId",
                table: "AracMarkas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AracMarkas_AracModelId",
                table: "AracMarkas",
                column: "AracModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracMarkas_AracModels_AracModelId",
                table: "AracMarkas",
                column: "AracModelId",
                principalTable: "AracModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
