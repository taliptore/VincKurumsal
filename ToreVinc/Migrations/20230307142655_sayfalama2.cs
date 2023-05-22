using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class sayfalama2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Iceriks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Iceriks_MenuId",
                table: "Iceriks",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iceriks_Menus_MenuId",
                table: "Iceriks",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iceriks_Menus_MenuId",
                table: "Iceriks");

            migrationBuilder.DropIndex(
                name: "IX_Iceriks_MenuId",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Iceriks");
        }
    }
}
