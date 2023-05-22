using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class aracbilgimodelmarkailbagla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_AracDurums_AracDurumId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_AracRenks_AracRenkId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_Kimdens_KimdenId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_MotorGucus_MotorGucuId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_VitesTips_VitesTipId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_YakitTipis_YakitTipiId",
                table: "AracBilgisi");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisi_kasaTipis_KasaTipiId",
                table: "AracBilgisi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracBilgisi",
                table: "AracBilgisi");

            migrationBuilder.RenameTable(
                name: "AracBilgisi",
                newName: "AracBilgisis");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_YakitTipiId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_YakitTipiId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_VitesTipId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_VitesTipId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_MotorGucuId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_MotorGucuId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_KimdenId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_KimdenId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_KasaTipiId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_KasaTipiId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_AracRenkId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_AracRenkId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisi_AracDurumId",
                table: "AracBilgisis",
                newName: "IX_AracBilgisis_AracDurumId");

            migrationBuilder.AddColumn<int>(
                name: "AracMarkaId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AracModelId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SehirilBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SehirilceBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracBilgisis",
                table: "AracBilgisis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_AracMarkaId",
                table: "AracBilgisis",
                column: "AracMarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_AracModelId",
                table: "AracBilgisis",
                column: "AracModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_SehirilBilgisiId",
                table: "AracBilgisis",
                column: "SehirilBilgisiId");

            migrationBuilder.CreateIndex(
                name: "IX_AracBilgisis_SehirilceBilgisiId",
                table: "AracBilgisis",
                column: "SehirilceBilgisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracDurums_AracDurumId",
                table: "AracBilgisis",
                column: "AracDurumId",
                principalTable: "AracDurums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracMarkas_AracMarkaId",
                table: "AracBilgisis",
                column: "AracMarkaId",
                principalTable: "AracMarkas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracModels_AracModelId",
                table: "AracBilgisis",
                column: "AracModelId",
                principalTable: "AracModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracRenks_AracRenkId",
                table: "AracBilgisis",
                column: "AracRenkId",
                principalTable: "AracRenks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_Kimdens_KimdenId",
                table: "AracBilgisis",
                column: "KimdenId",
                principalTable: "Kimdens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_MotorGucus_MotorGucuId",
                table: "AracBilgisis",
                column: "MotorGucuId",
                principalTable: "MotorGucus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_SehirilBilgisis_SehirilBilgisiId",
                table: "AracBilgisis",
                column: "SehirilBilgisiId",
                principalTable: "SehirilBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_SehirilceBilgisis_SehirilceBilgisiId",
                table: "AracBilgisis",
                column: "SehirilceBilgisiId",
                principalTable: "SehirilceBilgisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_VitesTips_VitesTipId",
                table: "AracBilgisis",
                column: "VitesTipId",
                principalTable: "VitesTips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_YakitTipis_YakitTipiId",
                table: "AracBilgisis",
                column: "YakitTipiId",
                principalTable: "YakitTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_kasaTipis_KasaTipiId",
                table: "AracBilgisis",
                column: "KasaTipiId",
                principalTable: "kasaTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AracDurums_AracDurumId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AracMarkas_AracMarkaId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AracModels_AracModelId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_AracRenks_AracRenkId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_Kimdens_KimdenId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_MotorGucus_MotorGucuId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_SehirilBilgisis_SehirilBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_SehirilceBilgisis_SehirilceBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_VitesTips_VitesTipId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_YakitTipis_YakitTipiId",
                table: "AracBilgisis");

            migrationBuilder.DropForeignKey(
                name: "FK_AracBilgisis_kasaTipis_KasaTipiId",
                table: "AracBilgisis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracBilgisis",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_AracMarkaId",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_AracModelId",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_SehirilBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.DropIndex(
                name: "IX_AracBilgisis_SehirilceBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "AracMarkaId",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "AracModelId",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "SehirilBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.DropColumn(
                name: "SehirilceBilgisiId",
                table: "AracBilgisis");

            migrationBuilder.RenameTable(
                name: "AracBilgisis",
                newName: "AracBilgisi");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_YakitTipiId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_YakitTipiId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_VitesTipId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_VitesTipId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_MotorGucuId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_MotorGucuId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_KimdenId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_KimdenId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_KasaTipiId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_KasaTipiId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_AracRenkId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_AracRenkId");

            migrationBuilder.RenameIndex(
                name: "IX_AracBilgisis_AracDurumId",
                table: "AracBilgisi",
                newName: "IX_AracBilgisi_AracDurumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracBilgisi",
                table: "AracBilgisi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_AracDurums_AracDurumId",
                table: "AracBilgisi",
                column: "AracDurumId",
                principalTable: "AracDurums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_AracRenks_AracRenkId",
                table: "AracBilgisi",
                column: "AracRenkId",
                principalTable: "AracRenks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_Kimdens_KimdenId",
                table: "AracBilgisi",
                column: "KimdenId",
                principalTable: "Kimdens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_MotorGucus_MotorGucuId",
                table: "AracBilgisi",
                column: "MotorGucuId",
                principalTable: "MotorGucus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_VitesTips_VitesTipId",
                table: "AracBilgisi",
                column: "VitesTipId",
                principalTable: "VitesTips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_YakitTipis_YakitTipiId",
                table: "AracBilgisi",
                column: "YakitTipiId",
                principalTable: "YakitTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisi_kasaTipis_KasaTipiId",
                table: "AracBilgisi",
                column: "KasaTipiId",
                principalTable: "kasaTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
