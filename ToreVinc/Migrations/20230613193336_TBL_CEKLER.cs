using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToreVinc.Migrations
{
    public partial class TBL_CEKLER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CEKLER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BELGENO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEKNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASILBORCLU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALINANCARIID = table.Column<int>(type: "int", nullable: false),
                    VERILENCARIID = table.Column<int>(type: "int", nullable: false),
                    ACKODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VADETARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BANKA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HESAPNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TUTAR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERILENBANKA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VERILENBANKA_BELGENO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERILENCARI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VERILENCARI_BELGENO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERILENBANKA_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DURUM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAHSIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BORDROID = table.Column<int>(type: "int", nullable: false),
                    TARIH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SAVEUSER = table.Column<int>(type: "int", nullable: false),
                    SAVEDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDITUSER = table.Column<int>(type: "int", nullable: false),
                    EDITDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CEKLER", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_CEKLER");
        }
    }
}
