using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class usertableiliskiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "YakitTipiId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VitesTipId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SehirilceBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SehirilBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KimdenId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KasaTipiId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AracRenkId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AracModelId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AracMarkaId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AracDurumId",
                table: "AracBilgisis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracDurums_AracDurumId",
                table: "AracBilgisis",
                column: "AracDurumId",
                principalTable: "AracDurums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracMarkas_AracMarkaId",
                table: "AracBilgisis",
                column: "AracMarkaId",
                principalTable: "AracMarkas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracModels_AracModelId",
                table: "AracBilgisis",
                column: "AracModelId",
                principalTable: "AracModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_AracRenks_AracRenkId",
                table: "AracBilgisis",
                column: "AracRenkId",
                principalTable: "AracRenks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_Kimdens_KimdenId",
                table: "AracBilgisis",
                column: "KimdenId",
                principalTable: "Kimdens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_SehirilBilgisis_SehirilBilgisiId",
                table: "AracBilgisis",
                column: "SehirilBilgisiId",
                principalTable: "SehirilBilgisis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_SehirilceBilgisis_SehirilceBilgisiId",
                table: "AracBilgisis",
                column: "SehirilceBilgisiId",
                principalTable: "SehirilceBilgisis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_VitesTips_VitesTipId",
                table: "AracBilgisis",
                column: "VitesTipId",
                principalTable: "VitesTips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_YakitTipis_YakitTipiId",
                table: "AracBilgisis",
                column: "YakitTipiId",
                principalTable: "YakitTipis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AracBilgisis_kasaTipis_KasaTipiId",
                table: "AracBilgisis",
                column: "KasaTipiId",
                principalTable: "kasaTipis",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "YakitTipiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VitesTipId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirilceBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirilBilgisiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KimdenId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KasaTipiId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AracRenkId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AracModelId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AracMarkaId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AracDurumId",
                table: "AracBilgisis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
