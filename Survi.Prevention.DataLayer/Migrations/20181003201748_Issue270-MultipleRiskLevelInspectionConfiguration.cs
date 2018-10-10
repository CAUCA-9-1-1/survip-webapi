using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue270MultipleRiskLevelInspectionConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fire_safety_department_inspection_configuration",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_safety_department = table.Column<Guid>(nullable: false),
                    has_general_information = table.Column<bool>(nullable: false),
                    has_implantation_plan = table.Column<bool>(nullable: false),
                    has_course = table.Column<bool>(nullable: false),
                    has_water_supply = table.Column<bool>(nullable: false),
                    has_building_details = table.Column<bool>(nullable: false),
                    has_building_contacts = table.Column<bool>(nullable: false),
                    has_building_pnaps = table.Column<bool>(nullable: false),
                    has_building_fire_protection = table.Column<bool>(nullable: false),
                    has_building_hazardous_materials = table.Column<bool>(nullable: false),
                    has_building_particular_risks = table.Column<bool>(nullable: false),
                    has_building_anomalies = table.Column<bool>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department_inspection_configuration", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_inspection_configuration_surveys_sur~",
                        column: x => x.id_survey,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

	        migrationBuilder.DropTable(
		        name: "fire_safety_department_risk_level");

			migrationBuilder.CreateTable(
                name: "fire_safety_department_inspection_configuration_risk_level",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_safety_department_inspection_configuration = table.Column<Guid>(nullable: false),
                    id_risk_level = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department_inspection_configuration_risk_level", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_inspection_configuration_risk_level_~",
                        column: x => x.id_fire_safety_department_inspection_configuration,
                        principalTable: "fire_safety_department_inspection_configuration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ffdconfigrisklevel_risklevel_idrisklevel",
                        column: x => x.id_risk_level,
                        principalTable: "risk_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_inspection_configuration_id_survey",
                table: "fire_safety_department_inspection_configuration",
                column: "id_survey");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_inspection_configuration_risk_level_~",
                table: "fire_safety_department_inspection_configuration_risk_level",
                column: "id_fire_safety_department_inspection_configuration");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_inspection_configuration_risk_level~1",
                table: "fire_safety_department_inspection_configuration_risk_level",
                column: "id_risk_level");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fire_safety_department_inspection_configuration_risk_level");

            migrationBuilder.DropTable(
                name: "fire_safety_department_inspection_configuration");

            migrationBuilder.CreateTable(
                name: "fire_safety_department_risk_level",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    has_building_anomalies = table.Column<bool>(nullable: false),
                    has_building_contacts = table.Column<bool>(nullable: false),
                    has_building_details = table.Column<bool>(nullable: false),
                    has_building_fire_protection = table.Column<bool>(nullable: false),
                    has_building_hazardous_materials = table.Column<bool>(nullable: false),
                    has_building_pnaps = table.Column<bool>(nullable: false),
                    has_building_particular_risks = table.Column<bool>(nullable: false),
                    has_course = table.Column<bool>(nullable: false),
                    has_general_information = table.Column<bool>(nullable: false),
                    has_implantation_plan = table.Column<bool>(nullable: false),
                    has_water_supply = table.Column<bool>(nullable: false),
                    id_fire_safety_department = table.Column<Guid>(nullable: false),
                    id_risk_level = table.Column<Guid>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: true),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department_risk_level", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_risk_level_risk_level_risk_level_id",
                        column: x => x.id_risk_level,
                        principalTable: "risk_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_risk_level_surveys_survey_id",
                        column: x => x.id_survey,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_risk_level_id_risk_level",
                table: "fire_safety_department_risk_level",
                column: "id_risk_level");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_risk_level_id_survey",
                table: "fire_safety_department_risk_level",
                column: "id_survey");
        }
    }
}
