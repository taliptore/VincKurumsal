using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class multilangue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Culture",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localization",
                columns: table => new
                {
                    LocalizationSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultureCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizationSetId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization", x => x.LocalizationSetId);
                    table.ForeignKey(
                        name: "FK_Localization_Culture_CultureCode",
                        column: x => x.CultureCode,
                        principalTable: "Culture",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Localization_LocalizationSet_LocalizationSetId1",
                        column: x => x.LocalizationSetId1,
                        principalTable: "LocalizationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_AuthorId",
                table: "Menus",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_DescriptionId",
                table: "Menus",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_NameId",
                table: "Menus",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Localization_CultureCode",
                table: "Localization",
                column: "CultureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Localization_LocalizationSetId1",
                table: "Localization",
                column: "LocalizationSetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_LocalizationSet_AuthorId",
                table: "Menus",
                column: "AuthorId",
                principalTable: "LocalizationSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_LocalizationSet_DescriptionId",
                table: "Menus",
                column: "DescriptionId",
                principalTable: "LocalizationSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_LocalizationSet_NameId",
                table: "Menus",
                column: "NameId",
                principalTable: "LocalizationSet",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_LocalizationSet_AuthorId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_LocalizationSet_DescriptionId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_LocalizationSet_NameId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Localization");

            migrationBuilder.DropTable(
                name: "Culture");

            migrationBuilder.DropTable(
                name: "LocalizationSet");

            migrationBuilder.DropIndex(
                name: "IX_Menus_AuthorId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_DescriptionId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_NameId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Menus");
        }
    }
}
