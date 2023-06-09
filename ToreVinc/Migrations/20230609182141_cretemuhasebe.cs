using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToreVinc.Migrations
{
    public partial class cretemuhasebe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_KULLANICIBILGI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KULLANICIADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIFRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YONETICI = table.Column<bool>(type: "bit", nullable: false),
                    DURUM = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_KULLANICIBILGI", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_KULLANICIBILGI");
        }
    }
}
