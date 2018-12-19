using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue245ImportationOptimization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_utilisation_code_id_extern",
                table: "utilisation_code",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_of_measure_id_extern",
                table: "unit_of_measure",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_state_id_extern",
                table: "state",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sprinkler_type_id_extern",
                table: "sprinkler_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_siding_type_id_extern",
                table: "siding_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roof_type_id_extern",
                table: "roof_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roof_material_type_id_extern",
                table: "roof_material_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_risk_level_id_extern",
                table: "risk_level",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_region_id_extern",
                table: "region",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_requiring_assistance_type_id_extern",
                table: "person_requiring_assistance_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lane_public_code_id_extern",
                table: "lane_public_code",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lane_generic_code_id_extern",
                table: "lane_generic_code",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lane_id_extern",
                table: "lane",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_sprinkler_id_extern",
                table: "inspection_building_sprinkler",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_person_requiring_assistance_id_extern",
                table: "inspection_building_person_requiring_assistance",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_particular_risk_picture_id_extern",
                table: "inspection_building_particular_risk_picture",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_particular_risk_id_extern",
                table: "inspection_building_particular_risk",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_hazardous_material_id_extern",
                table: "inspection_building_hazardous_material",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_fire_hydrant_id_extern",
                table: "inspection_building_fire_hydrant",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_extern",
                table: "inspection_building_detail",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_lane_id_extern",
                table: "inspection_building_course_lane",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_id_extern",
                table: "inspection_building_course",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_contact_id_extern",
                table: "inspection_building_contact",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_anomaly_picture_id_extern",
                table: "inspection_building_anomaly_picture",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_anomaly_id_extern",
                table: "inspection_building_anomaly",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_alarm_panel_id_extern",
                table: "inspection_building_alarm_panel",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_extern",
                table: "inspection_building",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hazardous_material_id_extern",
                table: "hazardous_material",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_firestation_id_extern",
                table: "firestation",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_city_serving_id_extern",
                table: "fire_safety_department_city_serving",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_id_extern",
                table: "fire_safety_department",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_type_id_extern",
                table: "fire_hydrant_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_type_id_extern",
                table: "fire_hydrant_connection_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_id_extern",
                table: "fire_hydrant_connection",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_extern",
                table: "fire_hydrant",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_county_id_extern",
                table: "county",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_country_id_extern",
                table: "country",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_construction_type_id_extern",
                table: "construction_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_construction_fire_resistance_type_id_extern",
                table: "construction_fire_resistance_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_type_id_extern",
                table: "city_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_id_extern",
                table: "city",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_type_id_extern",
                table: "building_type",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_sprinkler_id_extern",
                table: "building_sprinkler",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_person_requiring_assistance_id_extern",
                table: "building_person_requiring_assistance",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_particular_risk_picture_id_extern",
                table: "building_particular_risk_picture",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_particular_risk_id_extern",
                table: "building_particular_risk",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_hazardous_material_id_extern",
                table: "building_hazardous_material",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_fire_hydrant_id_extern",
                table: "building_fire_hydrant",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_extern",
                table: "building_detail",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_course_lane_id_extern",
                table: "building_course_lane",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_course_id_extern",
                table: "building_course",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_contact_id_extern",
                table: "building_contact",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_anomaly_picture_id_extern",
                table: "building_anomaly_picture",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_anomaly_id_extern",
                table: "building_anomaly",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_alarm_panel_id_extern",
                table: "building_alarm_panel",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_id_extern",
                table: "building",
                column: "id_extern",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_alarm_panel_type_id_extern",
                table: "alarm_panel_type",
                column: "id_extern",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_utilisation_code_id_extern",
                table: "utilisation_code");

            migrationBuilder.DropIndex(
                name: "IX_unit_of_measure_id_extern",
                table: "unit_of_measure");

            migrationBuilder.DropIndex(
                name: "IX_state_id_extern",
                table: "state");

            migrationBuilder.DropIndex(
                name: "IX_sprinkler_type_id_extern",
                table: "sprinkler_type");

            migrationBuilder.DropIndex(
                name: "IX_siding_type_id_extern",
                table: "siding_type");

            migrationBuilder.DropIndex(
                name: "IX_roof_type_id_extern",
                table: "roof_type");

            migrationBuilder.DropIndex(
                name: "IX_roof_material_type_id_extern",
                table: "roof_material_type");

            migrationBuilder.DropIndex(
                name: "IX_risk_level_id_extern",
                table: "risk_level");

            migrationBuilder.DropIndex(
                name: "IX_region_id_extern",
                table: "region");

            migrationBuilder.DropIndex(
                name: "IX_person_requiring_assistance_type_id_extern",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropIndex(
                name: "IX_lane_public_code_id_extern",
                table: "lane_public_code");

            migrationBuilder.DropIndex(
                name: "IX_lane_generic_code_id_extern",
                table: "lane_generic_code");

            migrationBuilder.DropIndex(
                name: "IX_lane_id_extern",
                table: "lane");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_sprinkler_id_extern",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_person_requiring_assistance_id_extern",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_particular_risk_picture_id_extern",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_particular_risk_id_extern",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_hazardous_material_id_extern",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_fire_hydrant_id_extern",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_detail_id_extern",
                table: "inspection_building_detail");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_course_lane_id_extern",
                table: "inspection_building_course_lane");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_course_id_extern",
                table: "inspection_building_course");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_contact_id_extern",
                table: "inspection_building_contact");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_anomaly_picture_id_extern",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_anomaly_id_extern",
                table: "inspection_building_anomaly");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_alarm_panel_id_extern",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropIndex(
                name: "IX_inspection_building_id_extern",
                table: "inspection_building");

            migrationBuilder.DropIndex(
                name: "IX_hazardous_material_id_extern",
                table: "hazardous_material");

            migrationBuilder.DropIndex(
                name: "IX_firestation_id_extern",
                table: "firestation");

            migrationBuilder.DropIndex(
                name: "IX_fire_safety_department_city_serving_id_extern",
                table: "fire_safety_department_city_serving");

            migrationBuilder.DropIndex(
                name: "IX_fire_safety_department_id_extern",
                table: "fire_safety_department");

            migrationBuilder.DropIndex(
                name: "IX_fire_hydrant_type_id_extern",
                table: "fire_hydrant_type");

            migrationBuilder.DropIndex(
                name: "IX_fire_hydrant_connection_type_id_extern",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropIndex(
                name: "IX_fire_hydrant_connection_id_extern",
                table: "fire_hydrant_connection");

            migrationBuilder.DropIndex(
                name: "IX_fire_hydrant_id_extern",
                table: "fire_hydrant");

            migrationBuilder.DropIndex(
                name: "IX_county_id_extern",
                table: "county");

            migrationBuilder.DropIndex(
                name: "IX_country_id_extern",
                table: "country");

            migrationBuilder.DropIndex(
                name: "IX_construction_type_id_extern",
                table: "construction_type");

            migrationBuilder.DropIndex(
                name: "IX_construction_fire_resistance_type_id_extern",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropIndex(
                name: "IX_city_type_id_extern",
                table: "city_type");

            migrationBuilder.DropIndex(
                name: "IX_city_id_extern",
                table: "city");

            migrationBuilder.DropIndex(
                name: "IX_building_type_id_extern",
                table: "building_type");

            migrationBuilder.DropIndex(
                name: "IX_building_sprinkler_id_extern",
                table: "building_sprinkler");

            migrationBuilder.DropIndex(
                name: "IX_building_person_requiring_assistance_id_extern",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropIndex(
                name: "IX_building_particular_risk_picture_id_extern",
                table: "building_particular_risk_picture");

            migrationBuilder.DropIndex(
                name: "IX_building_particular_risk_id_extern",
                table: "building_particular_risk");

            migrationBuilder.DropIndex(
                name: "IX_building_hazardous_material_id_extern",
                table: "building_hazardous_material");

            migrationBuilder.DropIndex(
                name: "IX_building_fire_hydrant_id_extern",
                table: "building_fire_hydrant");

            migrationBuilder.DropIndex(
                name: "IX_building_detail_id_extern",
                table: "building_detail");

            migrationBuilder.DropIndex(
                name: "IX_building_course_lane_id_extern",
                table: "building_course_lane");

            migrationBuilder.DropIndex(
                name: "IX_building_course_id_extern",
                table: "building_course");

            migrationBuilder.DropIndex(
                name: "IX_building_contact_id_extern",
                table: "building_contact");

            migrationBuilder.DropIndex(
                name: "IX_building_anomaly_picture_id_extern",
                table: "building_anomaly_picture");

            migrationBuilder.DropIndex(
                name: "IX_building_anomaly_id_extern",
                table: "building_anomaly");

            migrationBuilder.DropIndex(
                name: "IX_building_alarm_panel_id_extern",
                table: "building_alarm_panel");

            migrationBuilder.DropIndex(
                name: "IX_building_id_extern",
                table: "building");

            migrationBuilder.DropIndex(
                name: "IX_alarm_panel_type_id_extern",
                table: "alarm_panel_type");
        }
    }
}
