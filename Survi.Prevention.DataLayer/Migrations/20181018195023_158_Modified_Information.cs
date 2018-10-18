using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class _158_Modified_Information : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "webuser_fire_safety_department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "webuser_fire_safety_department",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "webuser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "webuser",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "webuser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "webuser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "webuser",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "utilisation_code_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "utilisation_code_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "utilisation_code",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "utilisation_code",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "utilisation_code",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "utilisation_code",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "utilisation_code",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "unit_of_measure_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "unit_of_measure_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "unit_of_measure",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "unit_of_measure",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "unit_of_measure",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "unit_of_measure",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "unit_of_measure",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey_question_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey_question_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey_question_choice_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey_question_choice_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey_question_choice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey_question_choice",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey_question",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey_question",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "survey",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "survey",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "state_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "state_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "state",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "state",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "state",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "state",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "state",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "sprinkler_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "sprinkler_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "sprinkler_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "sprinkler_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "siding_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "siding_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "siding_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "siding_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "roof_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "roof_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "roof_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "roof_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "roof_material_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "roof_material_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "roof_material_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "roof_material_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "risk_level_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "risk_level_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "risk_level",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "risk_level",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "risk_level",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "risk_level",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "risk_level",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "report_configuration_template",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "report_configuration_template",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "region_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "region_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "region",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "region",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "region",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "region",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "region",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "picture",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "person_requiring_assistance_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "person_requiring_assistance_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "person_requiring_assistance_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "person_requiring_assistance_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "person_requiring_assistance_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "person_requiring_assistance_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "person_requiring_assistance_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "lane_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "lane_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "lane",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "lane",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "lane",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "lane",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "lane",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_visit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_visit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_survey_answer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_survey_answer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_picture",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_sprinkler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_sprinkler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_person_requiring_assistance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_person_requiring_assistance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_particular_risk_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_particular_risk_picture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_particular_risk",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_particular_risk",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_hazardous_material",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_hazardous_material",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_fire_hydrant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_fire_hydrant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_detail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_detail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_course_lane",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_course_lane",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_course",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_course",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_course",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_course",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_contact",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_contact",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_contact",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_contact",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_anomaly_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_anomaly_picture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_anomaly",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_anomaly",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_alarm_panel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_alarm_panel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection_building",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection_building",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "inspection",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "inspection",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "hazardous_material_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "hazardous_material_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "hazardous_material",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "hazardous_material",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "firestation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "firestation",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "firestation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "firestation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "firestation",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_safety_department_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_inspection_configuration_risk_level",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_safety_department_inspection_configuration_risk_level",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_inspection_configuration",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_safety_department_inspection_configuration",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_city_serving",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_safety_department_city_serving",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "fire_safety_department",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "fire_safety_department",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_safety_department",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_safety_department",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "fire_hydrant_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "fire_hydrant_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant_connection_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant_connection_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant_connection",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "fire_hydrant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "county_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "county_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "county",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "county",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "county",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "county",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "county",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "country_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "country_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "country",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "country",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "country",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "country",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "construction_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "construction_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "construction_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "construction_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "construction_fire_resistance_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "construction_fire_resistance_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "construction_fire_resistance_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "construction_fire_resistance_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "city_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "city_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "city_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "city_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "city_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "city_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "city_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "city_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "city_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "city",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "city",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "city",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "city",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "city",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_type",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_type",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_sprinkler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_sprinkler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_sprinkler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_person_requiring_assistance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_person_requiring_assistance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_particular_risk_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_particular_risk_picture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_particular_risk",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_particular_risk",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_particular_risk",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_localization",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_hazardous_material",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_hazardous_material",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_hazardous_material",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_fire_hydrant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_fire_hydrant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_fire_hydrant",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_detail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_detail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_course_lane",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_course_lane",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_course_lane",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_course",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_course",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_course",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_course",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_contact",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_contact",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_contact",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_contact",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_anomaly_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_anomaly_picture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_anomaly",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_anomaly",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_anomaly",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_alarm_panel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_alarm_panel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building_alarm_panel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "building",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "building",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "batch",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "batch",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "alarm_panel_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "alarm_panel_type_localization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "alarm_panel_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "alarm_panel_type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_web_user_last_modified_by",
                table: "access_secret_key",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_on",
                table: "access_secret_key",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "webuser_fire_safety_department");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "webuser_fire_safety_department");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "utilisation_code_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "utilisation_code_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "unit_of_measure_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "unit_of_measure_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey_question_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey_question_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey_question_choice_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey_question_choice_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey_question_choice");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey_question_choice");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey_question");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey_question");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "survey");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "survey");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "state_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "state_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "state");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "state");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "state");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "state");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "state");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "sprinkler_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "sprinkler_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "sprinkler_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "sprinkler_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "siding_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "siding_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "siding_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "siding_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "roof_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "roof_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "roof_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "roof_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "roof_material_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "roof_material_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "roof_material_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "roof_material_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "risk_level_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "risk_level_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "report_configuration_template");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "report_configuration_template");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "region_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "region_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "region");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "region");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "region");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "region");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "region");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "picture");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "person_requiring_assistance_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "person_requiring_assistance_type_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "lane_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "lane_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_visit");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_visit");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_survey_answer");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_survey_answer");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_detail");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_detail");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "inspection");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "inspection");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "hazardous_material_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "hazardous_material_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_safety_department_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_inspection_configuration_risk_level");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_safety_department_inspection_configuration_risk_level");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_inspection_configuration");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_safety_department_inspection_configuration");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department_city_serving");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_safety_department_city_serving");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant_type_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant_connection_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant_connection_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant_connection");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant_connection");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "county_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "county_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "county");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "county");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "county");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "county");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "county");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "country_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "country_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "country");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "country");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "country");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "country");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "country");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "construction_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "construction_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "construction_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "construction_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "construction_fire_resistance_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "construction_fire_resistance_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "construction_fire_resistance_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "city_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "city_type_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "city_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "city_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "city");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "city");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "city");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "city");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "city");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_type_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_localization");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_detail");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_detail");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "building");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "building");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "batch");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "batch");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "alarm_panel_type_localization");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "alarm_panel_type_localization");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "alarm_panel_type");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "alarm_panel_type");

            migrationBuilder.DropColumn(
                name: "id_web_user_last_modified_by",
                table: "access_secret_key");

            migrationBuilder.DropColumn(
                name: "last_modified_on",
                table: "access_secret_key");
        }
    }
}
