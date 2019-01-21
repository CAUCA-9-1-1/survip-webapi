using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue257AddReportByFireStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_fire_safety_department",
                table: "report_configuration_template",
                nullable: false,
                defaultValue: Guid.Empty);

            migrationBuilder.AddColumn<bool>(
                name: "is_default",
                table: "report_configuration_template",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_fire_safety_department",
                table: "report_configuration_template");

            migrationBuilder.DropColumn(
                name: "is_default",
                table: "report_configuration_template");
        }
    }
}
