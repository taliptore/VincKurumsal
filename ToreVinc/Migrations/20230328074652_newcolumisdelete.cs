using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalWebVinc.Migrations
{
    /// <inheritdoc />
    public partial class newcolumisdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Vizyons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Vizyons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vizyons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Vizyons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Vizyons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Videolars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Videolars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Videolars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Videolars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Videolars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "TalepFormus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "TalepFormus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TalepFormus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "TalepFormus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "TalepFormus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "SSSes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "SSSes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SSSes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "SSSes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "SSSes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "SosyalMedyaBilgileris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SosyalMedyaBilgileris",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "SosyalMedyaBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "SlideModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "SlideModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlideModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "SlideModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "SlideModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Servislers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Servislers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Servislers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Servislers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Servislers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "ServisDetays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "ServisDetays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServisDetays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "ServisDetays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "ServisDetays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Resimlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Resimlers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Resimlers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Resimlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Resimlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "RandevuBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "RandevuBilgileris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RandevuBilgileris",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "RandevuBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "RandevuBilgileris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "MailAyarlaris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "MailAyarlaris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MailAyarlaris",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "MailAyarlaris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "MailAyarlaris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "KadroTipis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "KadroTipis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KadroTipis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "KadroTipis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "KadroTipis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Kadromuzs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kadromuzs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Kadromuzs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "IletisimBilgisis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IletisimBilgisis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "IletisimBilgisis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Iceriks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Iceriks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Iceriks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Iceriks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Iceriks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Hizmetlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Hizmetlers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hizmetlers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Hizmetlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Hizmetlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Hakkimizdas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Hakkimizdas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hakkimizdas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Hakkimizdas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Hakkimizdas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "GenelBilgilers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GenelBilgilers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Departmens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Departmens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departmens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Departmens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Departmens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "CalismaSaatleris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "CalismaSaatleris",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CalismaSaatleris",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "CalismaSaatleris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "CalismaSaatleris",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "BlogKategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "BlogKategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogKategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "BlogKategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "BlogKategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "AracModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "AracModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AracModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "AracModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "AracModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "AracMarkas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "AracMarkas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AracMarkas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "AracMarkas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "AracMarkas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "AltMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeleteDate",
                table: "AltMenu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AltMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsDeletedUserId",
                table: "AltMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserId",
                table: "AltMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Vizyons");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Vizyons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vizyons");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Vizyons");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Vizyons");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Videolars");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Videolars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Videolars");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Videolars");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Videolars");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "TalepFormus");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "SSSes");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "SSSes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SSSes");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "SSSes");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "SSSes");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "SosyalMedyaBilgileris");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "SlideModels");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "SlideModels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlideModels");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "SlideModels");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "SlideModels");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Servislers");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Servislers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Servislers");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Servislers");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Servislers");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "ServisDetays");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "RandevuBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "RandevuBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RandevuBilgileris");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "RandevuBilgileris");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "RandevuBilgileris");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "MailAyarlaris");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "MailAyarlaris");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MailAyarlaris");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "MailAyarlaris");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "MailAyarlaris");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "KadroTipis");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "KadroTipis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KadroTipis");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "KadroTipis");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "KadroTipis");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Kadromuzs");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "IletisimBilgisis");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Iceriks");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Hizmetlers");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Hizmetlers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hizmetlers");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Hizmetlers");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Hizmetlers");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Hakkimizdas");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Hakkimizdas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hakkimizdas");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Hakkimizdas");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Hakkimizdas");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Departmens");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Departmens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departmens");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Departmens");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Departmens");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "CalismaSaatleris");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "CalismaSaatleris");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CalismaSaatleris");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "CalismaSaatleris");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "CalismaSaatleris");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "BlogKategories");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "BlogKategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogKategories");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "BlogKategories");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "BlogKategories");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "AracModels");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "AracMarkas");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "AltMenu");

            migrationBuilder.DropColumn(
                name: "IsDeleteDate",
                table: "AltMenu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AltMenu");

            migrationBuilder.DropColumn(
                name: "IsDeletedUserId",
                table: "AltMenu");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "AltMenu");
        }
    }
}
