using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class updateFireHydrantPhysicalPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "physical_position",
                table: "fire_hydrant",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "coordinates",
                table: "fire_hydrant",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "address_location_type",
                table: "fire_hydrant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "civic_number",
                table: "fire_hydrant",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "coordinates",
                table: "building",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address_location_type",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "civic_number",
                table: "fire_hydrant");

            migrationBuilder.AlterColumn<string>(
                name: "physical_position",
                table: "fire_hydrant",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "coordinates",
                table: "fire_hydrant",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geometry",
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "coordinates",
                table: "building",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geometry",
                oldNullable: true);
        }
    }
}
