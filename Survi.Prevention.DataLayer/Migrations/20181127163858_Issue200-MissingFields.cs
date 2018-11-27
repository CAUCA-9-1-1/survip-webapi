using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue200MissingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_detail",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_detail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_detail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_detail",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_detail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_detail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_detail");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_detail");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_detail");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_detail");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_detail");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_detail");
        }
    }
}
