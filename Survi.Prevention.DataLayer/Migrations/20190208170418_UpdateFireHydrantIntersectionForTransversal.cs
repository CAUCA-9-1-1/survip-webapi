using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class UpdateFireHydrantIntersectionForTransversal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fire_hydrant_lanes_intersection_id",
                table: "fire_hydrant");

            migrationBuilder.RenameColumn(
                name: "id_intersection",
                table: "fire_hydrant",
                newName: "id_lane_transversal");

            migrationBuilder.RenameIndex(
                name: "IX_fire_hydrant_id_intersection",
                table: "fire_hydrant",
                newName: "IX_fire_hydrant_id_lane_transversal");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_fire_safety_department",
                table: "report_configuration_template",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_fire_hydrant_lanes_lane_transversal_id",
                table: "fire_hydrant",
                column: "id_lane_transversal",
                principalTable: "lane",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fire_hydrant_lanes_lane_transversal_id",
                table: "fire_hydrant");

            migrationBuilder.RenameColumn(
                name: "id_lane_transversal",
                table: "fire_hydrant",
                newName: "id_intersection");

            migrationBuilder.RenameIndex(
                name: "IX_fire_hydrant_id_lane_transversal",
                table: "fire_hydrant",
                newName: "IX_fire_hydrant_id_intersection");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_fire_safety_department",
                table: "report_configuration_template",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "fk_fire_hydrant_lanes_intersection_id",
                table: "fire_hydrant",
                column: "id_intersection",
                principalTable: "lane",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
