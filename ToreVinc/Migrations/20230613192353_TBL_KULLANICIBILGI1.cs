using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToreVinc.Migrations
{
    public partial class TBL_KULLANICIBILGI1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_BANKABILGILERI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BANKAADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HESAPTURU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HESAPNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BANKASUBESI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBETELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADRES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YETKILI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DURUM = table.Column<bool>(type: "bit", nullable: false),
                    SIL = table.Column<bool>(type: "bit", nullable: false),
                    SAVEUSER = table.Column<int>(type: "int", nullable: false),
                    SAVEDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDITUSER = table.Column<int>(type: "int", nullable: false),
                    EDITDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BANKABILGILERI", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_BANKABILGILERI");
        }
    }
}
