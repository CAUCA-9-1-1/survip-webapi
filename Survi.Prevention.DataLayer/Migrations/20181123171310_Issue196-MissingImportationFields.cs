using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue196MissingImportationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "fire_hydrant_connection_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "fire_hydrant_connection_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant_connection_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "fire_hydrant_connection",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "fire_hydrant_connection",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant_connection",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant_connection");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant_connection");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant_connection");
        }
    }
}
