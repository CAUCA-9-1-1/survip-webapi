using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue199ImportationPartTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_alarm_panel_type_localization_alarm_panel_type_parent_id",
                table: "alarm_panel_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_building_localization_building_parent_id",
                table: "building_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_building_type_localization_building_type_parent_id",
                table: "building_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_city_localization_city_parent_id",
                table: "city_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_city_type_localization_city_type_parent_id",
                table: "city_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_construction_type_localization_construction_type_parent_id",
                table: "construction_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_country_localization_country_parent_id",
                table: "country_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_county_localization_county_parent_id",
                table: "county_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_fire_hydrant_type_localization_fire_hydrant_type_parent_id",
                table: "fire_hydrant_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_hazardous_material_localization_hazardous_material_parent_id",
                table: "hazardous_material_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_localization_inspection_building_parent~",
                table: "inspection_building_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_lane_localization_lane_parent_id",
                table: "lane_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_region_localization_region_parent_id",
                table: "region_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_risk_level_localization_risk_level_parent_id",
                table: "risk_level_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_roof_material_type_localization_roof_material_type_parent_id",
                table: "roof_material_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_roof_type_localization_roof_type_parent_id",
                table: "roof_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_siding_type_localization_siding_type_parent_id",
                table: "siding_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_sprinkler_type_localization_sprinkler_type_parent_id",
                table: "sprinkler_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_state_localization_state_parent_id",
                table: "state_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_survey_localization_survey_parent_id",
                table: "survey_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_survey_question_localization_survey_question_parent_id",
                table: "survey_question_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_unit_of_measure_localization_unit_of_measure_parent_id",
                table: "unit_of_measure_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_utilisation_code_localization_utilisation_code_parent_id",
                table: "utilisation_code_localization");

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "sprinkler_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "sprinkler_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "sprinkler_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "siding_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "siding_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "siding_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "roof_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "roof_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "roof_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "roof_material_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "roof_material_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "roof_material_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "construction_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "construction_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "construction_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "construction_fire_resistance_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "construction_fire_resistance_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "construction_fire_resistance_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "alarm_panel_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "alarm_panel_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "alarm_panel_type",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_alarm_panel_type_localization_alarm_panel_type_alarm_panel_~",
                table: "alarm_panel_type_localization",
                column: "id_alarm_panel_type",
                principalTable: "alarm_panel_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_building_localization_building_building_id",
                table: "building_localization",
                column: "id_building",
                principalTable: "building",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_building_type_localization_building_type_building_type_id",
                table: "building_type_localization",
                column: "id_building_type",
                principalTable: "building_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_city_localization_city_city_id",
                table: "city_localization",
                column: "id_city",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_city_type_localization_city_type_city_type_id",
                table: "city_type_localization",
                column: "id_city_type",
                principalTable: "city_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_construction_type_localization_construction_type_constructi~",
                table: "construction_type_localization",
                column: "id_construction_type",
                principalTable: "construction_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_country_localization_country_country_id",
                table: "country_localization",
                column: "id_country",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_county_localization_county_county_id",
                table: "county_localization",
                column: "id_county",
                principalTable: "county",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fire_hydrant_type_localization_fire_hydrant_type_fire_hydra~",
                table: "fire_hydrant_type_localization",
                column: "id_fire_hydrant_type",
                principalTable: "fire_hydrant_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_hazardous_material_localization_hazardous_material_hazardou~",
                table: "hazardous_material_localization",
                column: "id_hazardous_material",
                principalTable: "hazardous_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_localization_inspection_building_inspec~",
                table: "inspection_building_localization",
                column: "id_building",
                principalTable: "inspection_building",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lane_localization_lane_lane_id",
                table: "lane_localization",
                column: "id_lane",
                principalTable: "lane",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_region_localization_region_region_id",
                table: "region_localization",
                column: "id_region",
                principalTable: "region",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_risk_level_localization_risk_level_risk_level_id",
                table: "risk_level_localization",
                column: "id_risk_level",
                principalTable: "risk_level",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_roof_material_type_localization_roof_material_type_roof_mat~",
                table: "roof_material_type_localization",
                column: "id_roof_material_type",
                principalTable: "roof_material_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_roof_type_localization_roof_type_roof_type_id",
                table: "roof_type_localization",
                column: "id_roof_type",
                principalTable: "roof_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_siding_type_localization_siding_type_siding_type_id",
                table: "siding_type_localization",
                column: "id_siding_type",
                principalTable: "siding_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sprinkler_type_localization_sprinkler_type_sprinkler_type_id",
                table: "sprinkler_type_localization",
                column: "id_sprinkler_type",
                principalTable: "sprinkler_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_state_localization_state_state_id",
                table: "state_localization",
                column: "id_state",
                principalTable: "state",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_survey_localization_survey_survey_id",
                table: "survey_localization",
                column: "id_survey",
                principalTable: "survey",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_survey_question_localization_survey_question_survey_questio~",
                table: "survey_question_localization",
                column: "id_survey_question",
                principalTable: "survey_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_unit_of_measure_localization_unit_of_measure_unit_of_measur~",
                table: "unit_of_measure_localization",
                column: "id_parent",
                principalTable: "unit_of_measure",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_utilisation_code_localization_utilisation_code_utilisation_~",
                table: "utilisation_code_localization",
                column: "id_utilisation_code",
                principalTable: "utilisation_code",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_alarm_panel_type_localization_alarm_panel_type_alarm_panel_~",
                table: "alarm_panel_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_building_localization_building_building_id",
                table: "building_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_building_type_localization_building_type_building_type_id",
                table: "building_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_city_localization_city_city_id",
                table: "city_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_city_type_localization_city_type_city_type_id",
                table: "city_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_construction_type_localization_construction_type_constructi~",
                table: "construction_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_country_localization_country_country_id",
                table: "country_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_county_localization_county_county_id",
                table: "county_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_fire_hydrant_type_localization_fire_hydrant_type_fire_hydra~",
                table: "fire_hydrant_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_hazardous_material_localization_hazardous_material_hazardou~",
                table: "hazardous_material_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_localization_inspection_building_inspec~",
                table: "inspection_building_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_lane_localization_lane_lane_id",
                table: "lane_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_region_localization_region_region_id",
                table: "region_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_risk_level_localization_risk_level_risk_level_id",
                table: "risk_level_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_roof_material_type_localization_roof_material_type_roof_mat~",
                table: "roof_material_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_roof_type_localization_roof_type_roof_type_id",
                table: "roof_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_siding_type_localization_siding_type_siding_type_id",
                table: "siding_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_sprinkler_type_localization_sprinkler_type_sprinkler_type_id",
                table: "sprinkler_type_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_state_localization_state_state_id",
                table: "state_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_survey_localization_survey_survey_id",
                table: "survey_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_survey_question_localization_survey_question_survey_questio~",
                table: "survey_question_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_unit_of_measure_localization_unit_of_measure_unit_of_measur~",
                table: "unit_of_measure_localization");

            migrationBuilder.DropForeignKey(
                name: "fk_utilisation_code_localization_utilisation_code_utilisation_~",
                table: "utilisation_code_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "sprinkler_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "sprinkler_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "sprinkler_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "siding_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "siding_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "siding_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "roof_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "roof_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "roof_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "roof_material_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "roof_material_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "roof_material_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "construction_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "construction_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "construction_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "alarm_panel_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "alarm_panel_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "alarm_panel_type");

            migrationBuilder.AddForeignKey(
                name: "fk_alarm_panel_type_localization_alarm_panel_type_parent_id",
                table: "alarm_panel_type_localization",
                column: "id_alarm_panel_type",
                principalTable: "alarm_panel_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_building_localization_building_parent_id",
                table: "building_localization",
                column: "id_building",
                principalTable: "building",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_building_type_localization_building_type_parent_id",
                table: "building_type_localization",
                column: "id_building_type",
                principalTable: "building_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_city_localization_city_parent_id",
                table: "city_localization",
                column: "id_city",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_city_type_localization_city_type_parent_id",
                table: "city_type_localization",
                column: "id_city_type",
                principalTable: "city_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_construction_type_localization_construction_type_parent_id",
                table: "construction_type_localization",
                column: "id_construction_type",
                principalTable: "construction_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_country_localization_country_parent_id",
                table: "country_localization",
                column: "id_country",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_county_localization_county_parent_id",
                table: "county_localization",
                column: "id_county",
                principalTable: "county",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fire_hydrant_type_localization_fire_hydrant_type_parent_id",
                table: "fire_hydrant_type_localization",
                column: "id_fire_hydrant_type",
                principalTable: "fire_hydrant_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_hazardous_material_localization_hazardous_material_parent_id",
                table: "hazardous_material_localization",
                column: "id_hazardous_material",
                principalTable: "hazardous_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_localization_inspection_building_parent~",
                table: "inspection_building_localization",
                column: "id_building",
                principalTable: "inspection_building",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lane_localization_lane_parent_id",
                table: "lane_localization",
                column: "id_lane",
                principalTable: "lane",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_region_localization_region_parent_id",
                table: "region_localization",
                column: "id_region",
                principalTable: "region",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_risk_level_localization_risk_level_parent_id",
                table: "risk_level_localization",
                column: "id_risk_level",
                principalTable: "risk_level",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_roof_material_type_localization_roof_material_type_parent_id",
                table: "roof_material_type_localization",
                column: "id_roof_material_type",
                principalTable: "roof_material_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_roof_type_localization_roof_type_parent_id",
                table: "roof_type_localization",
                column: "id_roof_type",
                principalTable: "roof_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_siding_type_localization_siding_type_parent_id",
                table: "siding_type_localization",
                column: "id_siding_type",
                principalTable: "siding_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sprinkler_type_localization_sprinkler_type_parent_id",
                table: "sprinkler_type_localization",
                column: "id_sprinkler_type",
                principalTable: "sprinkler_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_state_localization_state_parent_id",
                table: "state_localization",
                column: "id_state",
                principalTable: "state",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_survey_localization_survey_parent_id",
                table: "survey_localization",
                column: "id_survey",
                principalTable: "survey",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_survey_question_localization_survey_question_parent_id",
                table: "survey_question_localization",
                column: "id_survey_question",
                principalTable: "survey_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_unit_of_measure_localization_unit_of_measure_parent_id",
                table: "unit_of_measure_localization",
                column: "id_parent",
                principalTable: "unit_of_measure",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_utilisation_code_localization_utilisation_code_parent_id",
                table: "utilisation_code_localization",
                column: "id_utilisation_code",
                principalTable: "utilisation_code",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
