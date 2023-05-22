using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class aracbilgicreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracBilgisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasarKaydiAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DegisenAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoyaAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KM = table.Column<int>(type: "int", nullable: false),
                    Garanti = table.Column<bool>(type: "bit", nullable: false),
                    AgirHararKayitliMi = table.Column<bool>(type: "bit", nullable: false),
                    Takasli = table.Column<bool>(type: "bit", nullable: false),
                    AracDurumId = table.Column<int>(type: "int", nullable: false),
                    AracRenkId = table.Column<int>(type: "int", nullable: false),
                    KasaTipiId = table.Column<int>(type: "int", nullable: false),
                    KimdenId = table.Column<int>(type: "int", nullable: false),
                    MotorGucuId = table.Column<int>(type: "int", nullable: false),
                    VitesTipId = table.Column<int>(type: "int", nullable: false),
                    YakitTipiId = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracBilgisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_AracDurums_AracDurumId",
                        column: x => x.AracDurumId,
                        principalTable: "AracDurums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_AracRenks_AracRenkId",
                        column: x => x.AracRenkId,
                        principalTable: "AracRenks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_Kimdens_KimdenId",
                        column: x => x.KimdenId,
                        principalTable: "Kimdens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_MotorGucus_MotorGucuId",
                        column: x => x.MotorGucuId,
                        principalTable: "MotorGucus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_VitesTips_VitesTipId",
                        column: x => x.VitesTipId,
                        principalTable: "VitesTips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_YakitTipis_YakitTipiId",
                        column: x => x.YakitTipiId,
                        principalTable: "YakitTipis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracBilgisi_kasaTipis_KasaTipiId",
                        column: x => x.KasaTipiId,
                        principalTable: "kasaTipis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_AracDurumId",
                table: "AracBilgisi",
                column: "AracDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_AracRenkId",
                table: "AracBilgisi",
                column: "AracRenkId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_KasaTipiId",
                table: "AracBilgisi",
                column: "KasaTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_KimdenId",
                table: "AracBilgisi",
                column: "KimdenId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_MotorGucuId",
                table: "AracBilgisi",
                column: "MotorGucuId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_VitesTipId",
                table: "AracBilgisi",
                column: "VitesTipId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisi_YakitTipiId",
                table: "AracBilgisi",
                column: "YakitTipiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracBilgisi");
        }
    }
}
