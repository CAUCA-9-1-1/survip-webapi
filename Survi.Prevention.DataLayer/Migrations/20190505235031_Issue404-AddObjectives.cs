using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue404AddObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    id_fire_safety_department = table.Column<Guid>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    objective = table.Column<int>(nullable: false, defaultValue: 0),
                    is_high_risk = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_objectives", x => x.id);
                    table.ForeignKey(
                        name: "fk_objectives_fire_safety_departments_fire_safety_department_id",
                        column: x => x.id_fire_safety_department,
                        principalTable: "fire_safety_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_objectives_id_fire_safety_department",
                table: "objectives",
                column: "id_fire_safety_department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objectives");
        }
    }
}
