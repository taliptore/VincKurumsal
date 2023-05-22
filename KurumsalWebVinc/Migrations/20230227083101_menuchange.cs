using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class menuchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_AltMenu_AltMenuId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_AltMenuId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "AltMenuId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "AltMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AltMenu_MenuId",
                table: "AltMenu",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AltMenu_Menus_MenuId",
                table: "AltMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AltMenu_Menus_MenuId",
                table: "AltMenu");

            migrationBuilder.DropIndex(
                name: "IX_AltMenu_MenuId",
                table: "AltMenu");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "AltMenu");

            migrationBuilder.AddColumn<int>(
                name: "AltMenuId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_AltMenuId",
                table: "Menus",
                column: "AltMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_AltMenu_AltMenuId",
                table: "Menus",
                column: "AltMenuId",
                principalTable: "AltMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
