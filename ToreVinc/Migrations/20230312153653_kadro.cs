using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class kadro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kadromuzs_KadroTipis_KadroTipiId",
                table: "Kadromuzs");

            migrationBuilder.DropIndex(
                name: "IX_Kadromuzs_KadroTipiId",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "KadroTipiId",
                table: "Kadromuzs");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SayfaUrl",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uzmanlik",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "SayfaUrl",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "Uzmanlik",
                table: "Kadromuzs");

            migrationBuilder.AddColumn<int>(
                name: "KadroTipiId",
                table: "Kadromuzs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kadromuzs_KadroTipiId",
                table: "Kadromuzs",
                column: "KadroTipiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kadromuzs_KadroTipis_KadroTipiId",
                table: "Kadromuzs",
                column: "KadroTipiId",
                principalTable: "KadroTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
