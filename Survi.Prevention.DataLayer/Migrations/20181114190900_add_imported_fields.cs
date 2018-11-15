using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class add_imported_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "webuser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "webuser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "webuser",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "utilisation_code",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "unit_of_measure",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "state",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "risk_level",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "region",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "person_requiring_assistance_type",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "lane",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "inspection_building_particular_risk_picture",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_particular_risk_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_particular_risk",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_fire_hydrant",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building_contact",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "inspection_building_anomaly_picture",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "inspection_building_anomaly_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "inspection_building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "inspection_building",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "firestation",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_safety_department",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant_type",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "fire_hydrant",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "county",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "country",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "city_type",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "city",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_person_requiring_assistance",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "building_particular_risk_picture",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_particular_risk_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_particular_risk_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_particular_risk",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_fire_hydrant",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building_contact",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "building_anomaly_picture",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "has_been_modified",
                table: "building_anomaly_picture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "id_extern",
                table: "building_anomaly_picture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "imported_on",
                table: "building",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "webuser");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "state");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "state");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "state");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "risk_level");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "region");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "region");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "region");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "person_requiring_assistance_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_sprinkler");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_particular_risk");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_course_lane");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_course");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_contact");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_anomaly");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "firestation");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "fire_hydrant");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "county");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "county");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "county");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "country");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "country");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "country");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "city_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "city");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "city");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "city");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_type");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_sprinkler");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_person_requiring_assistance");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_particular_risk_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_particular_risk");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_hazardous_material");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_fire_hydrant");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_course_lane");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_course");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_contact");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_anomaly_picture");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_anomaly");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building_alarm_panel");

            migrationBuilder.DropColumn(
                name: "has_been_modified",
                table: "building");

            migrationBuilder.DropColumn(
                name: "id_extern",
                table: "building");

            migrationBuilder.DropColumn(
                name: "imported_on",
                table: "building");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "inspection_building_particular_risk_picture",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "inspection_building_anomaly_picture",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "building_particular_risk_picture",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_picture",
                table: "building_anomaly_picture",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
