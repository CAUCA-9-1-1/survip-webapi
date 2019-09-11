using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Survi.Prevention.DataLayer.Migrations
{
	public partial class feat334UpdateViewsAndDeleteOldTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				DROP VIEW building_with_todo_inspection;
				CREATE VIEW building_with_todo_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
   				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
                  (EXISTS (select * from inspection_visit where inspection_visit.id_inspection = i.id AND inspection_visit.status IN (0,1) )) AS has_been_downloaded,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select first_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select last_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select first_name from ""user"" as usr where usr.id = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select last_name from ""user"" as usr where usr.id = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN ""user"" as usr ON bu.id_webuser = usr.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to,
				CASE
		           WHEN ((SELECT count(inspection.id) AS count
		                  FROM inspection
		                  WHERE ((inspection.is_active = true) AND (inspection.id_batch = i.id_batch) AND
		                         (inspection.status <> 0))) > 0) THEN true
		           ELSE false END AS is_batch_started

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status in (0, 1, 4);
				");

			migrationBuilder.Sql(@"
				DROP VIEW building_with_ready_for_approbation_inspection;
				CREATE VIEW building_with_ready_for_approbation_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select first_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select last_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select first_name from ""user"" as usr where usr.id = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select last_name from ""user"" as usr where usr.id = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN ""user"" as usr ON bu.id_webuser = usr.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status = 2;
				");

			migrationBuilder.Sql(@"
				DROP VIEW building_with_completed_inspection;
				CREATE VIEW building_with_completed_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
                  i.completed_on,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select first_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select last_name from ""user"" as usr where usr.id = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select first_name from ""user"" as usr where usr.id = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select last_name from ""user"" as usr where usr.id = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN ""user"" as usr ON bu.id_webuser = usr.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status = 3;
				");
			migrationBuilder.DropForeignKey(
                name: "fk_batch_webusers_created_by_id",
                table: "batch");

            migrationBuilder.DropForeignKey(
                name: "fk_batch_user_webusers_user_id",
                table: "batch_user");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_webusers_assigned_to_id",
                table: "inspection");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_webusers_created_by_id",
                table: "inspection");


            migrationBuilder.DropForeignKey(
                name: "fk_inspection_visit_webusers_visited_by_id",
                table: "inspection_visit");

            migrationBuilder.DropTable(
                name: "access_secret_key");

            migrationBuilder.DropTable(
                name: "access_token");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "webuser_attributes");

            migrationBuilder.DropTable(
                name: "webuser_fire_safety_department");

            migrationBuilder.DropTable(
                name: "permission_object");

            migrationBuilder.DropTable(
                name: "permission_system_feature");

            migrationBuilder.DropTable(
                name: "webuser");

            migrationBuilder.DropTable(
                name: "permission_system");

            migrationBuilder.AddForeignKey(
                name: "fk_batch_users_created_by_id",
                table: "batch",
                column: "id_webuser_created_by",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_batch_user_users_user_id",
                table: "batch_user",
                column: "id_webuser",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_users_assigned_to_id",
                table: "inspection",
                column: "id_webuser_assigned_to",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_users_created_by_id",
                table: "inspection",
                column: "id_webuser_created_by",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_visit_users_visited_by_id",
                table: "inspection_visit",
                column: "id_webuser_visited_by",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }





        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_batch_users_created_by_id",
                table: "batch");

            migrationBuilder.DropForeignKey(
                name: "fk_batch_user_users_user_id",
                table: "batch_user");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_users_assigned_to_id",
                table: "inspection");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_users_created_by_id",
                table: "inspection");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_visit_users_visited_by_id",
                table: "inspection_visit");

            migrationBuilder.CreateTable(
                name: "access_secret_key",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    application_name = table.Column<string>(maxLength: 50, nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    random_key = table.Column<string>(maxLength: 100, nullable: false),
                    secret_key = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_secret_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_system",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_system", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "webuser",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    has_been_modified = table.Column<bool>(nullable: false),
                    id_extern = table.Column<string>(nullable: true),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    imported_on = table.Column<DateTime>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    username = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_webuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_object",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    generic_id = table.Column<string>(maxLength: 50, nullable: true),
                    group_name = table.Column<string>(maxLength: 50, nullable: true),
                    id_permission_object_parent = table.Column<Guid>(nullable: true),
                    id_permission_system = table.Column<Guid>(nullable: false),
                    is_group = table.Column<bool>(nullable: false),
                    object_table = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_object", x => x.id);
                    table.ForeignKey(
                        name: "fk_permission_object_permission_object_parent_id",
                        column: x => x.id_permission_object_parent,
                        principalTable: "permission_object",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permission_object_permission_systems_system_id",
                        column: x => x.id_permission_system,
                        principalTable: "permission_system",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_system_feature",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    default_value = table.Column<bool>(nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: false),
                    feature_name = table.Column<string>(maxLength: 50, nullable: false),
                    id_permission_system = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_system_feature", x => x.id);
                    table.ForeignKey(
                        name: "fk_permission_system_feature_permission_system_system_id",
                        column: x => x.id_permission_system,
                        principalTable: "permission_system",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "access_token",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    expires_in = table.Column<int>(nullable: false),
                    id_webuser = table.Column<Guid>(nullable: false),
                    refresh_token = table.Column<string>(maxLength: 100, nullable: false),
                    token_for_access = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_access_token_webusers_user_id",
                        column: x => x.id_webuser,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "webuser_attributes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    attribute_name = table.Column<string>(maxLength: 50, nullable: false),
                    attribute_value = table.Column<string>(maxLength: 50, nullable: false),
                    id_webuser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_webuser_attributes", x => x.id);
                    table.ForeignKey(
                        name: "fk_webuser_attributes_webuser_user_id",
                        column: x => x.id_webuser,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "webuser_fire_safety_department",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    id_fire_safety_department = table.Column<Guid>(nullable: false),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    id_webuser = table.Column<Guid>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    last_modified_on = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_webuser_fire_safety_department", x => x.id);
                    table.ForeignKey(
                        name: "fk_webuser_fire_safety_department_fire_safety_department_fire_~",
                        column: x => x.id_fire_safety_department,
                        principalTable: "fire_safety_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_webuser_fire_safety_department_webuser_user_id",
                        column: x => x.id_webuser,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    access = table.Column<bool>(nullable: true),
                    comments = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    id_permission_object = table.Column<Guid>(nullable: false),
                    id_permission_system = table.Column<Guid>(nullable: false),
                    id_permission_system_feature = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_permission_permission_objects_permission_object_id",
                        column: x => x.id_permission_object,
                        principalTable: "permission_object",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_permission_permission_systems_system_id",
                        column: x => x.id_permission_system,
                        principalTable: "permission_system",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_permission_permission_system_features_feature_id",
                        column: x => x.id_permission_system_feature,
                        principalTable: "permission_system_feature",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "permission_system",
                columns: new[] { "id", "description" },
                values: new object[] { new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), "SURVI-Prevention" });

            migrationBuilder.InsertData(
                table: "permission_system_feature",
                columns: new[] { "id", "default_value", "description", "feature_name", "id_permission_system" },
                values: new object[,]
                {
                    { new Guid("78b19b2a-f31b-4027-8b92-105a0ac44282"), false, "Gestion des unités de mesure", "RightUnitManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("d68c1911-e063-4b22-a635-413004d3bd60"), false, "Gestion des comtés", "RightCountyManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("62982bdc-2ae9-407b-9396-01bfb3c50d23"), false, "Gestion des régions", "RightRegionManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("193ab58d-0a0f-48d5-bb65-6a2d67db58c4"), false, "Gestion des provinces/états", "RightStateManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("08dfbdb1-6cf4-449b-85e3-8134de4ed052"), false, "Gestion des pays", "RightCountryManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("8a9896a5-0ab5-4c33-a01f-7e97742c9570"), false, "Gestion des types de ville", "RightCityTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd"), false, "Gestion des villes", "RightCityManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("2dfaae63-39a2-471c-9a42-705cba52c565"), false, "Gestion des niveaux de risque", "RightRiskLevelManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4e5be439-7249-4f7c-b9c1-e0a448046c57"), false, "Gestion des codes d'utilisation", "RightUtilisationCodeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("6da8395e-4057-415c-9710-ea098fdf2e9e"), false, "Gestion des types de PNAPs", "RightRPATypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("e8c4cc98-7e17-450b-8333-9d87cd8f695a"), false, "Gestion des matières dangereuses", "RightHazardousMaterialManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("9898d805-e8ef-4595-a0d2-66d1b022ea86"), false, "Gestion des niveaux de risque par SSI", "RightDepartmentRiskLevel", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("26d14cda-d321-4db2-a604-6daaff0483e9"), false, "Gestion des SSI", "RightDepartmentManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), false, "Gestion des bornes", "RightFireHydrantManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("b38a094f-b0a6-494b-9104-009d30199cbf"), false, "Gestion des opérateurs", "RightOperatorManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1864a414-64a3-4f67-9556-059ad9c5a672"), false, "Gestion des types de connexion", "RightConnectionTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749"), false, "Gestion des types de borne", "RightFireHydrantTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("89dbc380-186b-440c-a069-bd42d0664ed8"), false, "Gestion des utilisateurs", "RightUserManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), true, "Accès au tableau de bord", "url-inspection-dashboard", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843"), false, "Accès aux statistiques", "url-statistics", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), false, "Accès à la gestion des rapports", "url-report-configuration", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), false, "Accès à la gestion système", "url-management-system", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("05d57316-7b0a-4195-bfdb-796262d4128a"), false, "Accès à la gestion des types du système", "url-management-typesystem", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d"), false, "Accès à la gestion des questionnaires", "url-management-survey", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4"), false, "Accès à la gestion du SSI", "url-management-department", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), false, "Accès à la gestion des villes", "url-management-address", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("aa163670-487c-461e-8112-9bf98070f5b3"), false, "Acception des inspections", "RightApproveInspection", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43"), false, "Gestion des lots", "RightBatchManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), false, "Gestion des casernes", "RightFireStationManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("0615bbba-ae42-472b-b768-227b80efd4f1"), false, "Gestion des voies", "RightLaneManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("98075263-e986-4823-aa11-cfca837adcbc"), false, "Gestion des bâtiments", "RightBuildingManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), false, "Gestion des permissions", "RightPermissionManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), true, "Accès au mobile", "RightMobile", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") }
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_access_token_id_webuser",
                table: "access_token",
                column: "id_webuser");

            migrationBuilder.CreateIndex(
                name: "IX_permission_id_permission_object",
                table: "permission",
                column: "id_permission_object");

            migrationBuilder.CreateIndex(
                name: "IX_permission_id_permission_system",
                table: "permission",
                column: "id_permission_system");

            migrationBuilder.CreateIndex(
                name: "IX_permission_id_permission_system_feature",
                table: "permission",
                column: "id_permission_system_feature");

            migrationBuilder.CreateIndex(
                name: "IX_permission_object_id_permission_object_parent",
                table: "permission_object",
                column: "id_permission_object_parent");

            migrationBuilder.CreateIndex(
                name: "IX_permission_object_id_permission_system",
                table: "permission_object",
                column: "id_permission_system");

            migrationBuilder.CreateIndex(
                name: "IX_permission_system_feature_id_permission_system",
                table: "permission_system_feature",
                column: "id_permission_system");

            migrationBuilder.CreateIndex(
                name: "IX_webuser_attributes_id_webuser",
                table: "webuser_attributes",
                column: "id_webuser");

            migrationBuilder.CreateIndex(
                name: "IX_webuser_fire_safety_department_id_fire_safety_department",
                table: "webuser_fire_safety_department",
                column: "id_fire_safety_department");

            migrationBuilder.CreateIndex(
                name: "IX_webuser_fire_safety_department_id_webuser",
                table: "webuser_fire_safety_department",
                column: "id_webuser");

            migrationBuilder.AddForeignKey(
                name: "fk_batch_webusers_created_by_id",
                table: "batch",
                column: "id_webuser_created_by",
                principalTable: "webuser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_batch_user_webusers_user_id",
                table: "batch_user",
                column: "id_webuser",
                principalTable: "webuser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_webusers_assigned_to_id",
                table: "inspection",
                column: "id_webuser_assigned_to",
                principalTable: "webuser",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_webusers_created_by_id",
                table: "inspection",
                column: "id_webuser_created_by",
                principalTable: "webuser",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_visit_webusers_visited_by_id",
                table: "inspection_visit",
                column: "id_webuser_visited_by",
                principalTable: "webuser",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"
				insert into webuser (id, created_on, is_active, username, password, id_web_user_last_modified_by, last_modified_on, has_been_modified, id_extern, imported_on)
				select id,
				       now() as created_on,
				       is_active,
				       user_name as username,
				       password,
				       (select id from ""user"" where user_name = 'admin') as id_web_user_last_modified_by,
				       null as last_modified_on,
				       true as has_been_modified,
				       null as id_extern,
				       null as imported_on
				from ""user"";
				--firstname
				insert into webuser_attributes (id, attribute_name, attribute_value, id_webuser)
				select (uuid_generate_v4()) as id, 'first_name' as attribute_name, first_name as attribute_value, id as id_webuser from ""user"";
				--lastname
				insert into webuser_attributes (id, attribute_name, attribute_value, id_webuser)
				select (uuid_generate_v4()) as id, 'last_name' as attribute_name, last_name as attribute_value, id as id_webuser  from ""user"";
				--email
				insert into webuser_attributes (id, attribute_name, attribute_value, id_webuser)
				select (uuid_generate_v4()) as id, 'email' as attribute_name, email as attribute_value, id as id_webuser from ""user"";
				--telephone
				insert into webuser_attributes (id, attribute_name, attribute_value, id_webuser)
				select (uuid_generate_v4()) as id, 'telephone' as attribute_name, phone_number as attribute_value, id as id_webuser from ""user""
				where phone_number != '' and phone_number is not null;
				--ssi
				insert into webuser_fire_safety_department (id, created_on, is_active, id_webuser, id_fire_safety_department, id_web_user_last_modified_by, last_modified_on)
				select id, now() as created_on, true as is_active, user_id as id_webuser, CAST(fire_safety_department_id AS uuid) as id_fire_safety_department,
				  CAST('0540e8f7-dc44-4b2f-8e42-5004cca3700b' AS uuid) as  id_web_user_last_modified_by, now() as last_modified_on from user_fire_safety_department;
				--add groups
				insert into permission_object (id, object_table, generic_id, is_group, group_name, id_permission_system, id_permission_object_parent)
				select id, 'group' as object_table, null as generic_id, true as is_group, name as group_name,
				       '4c0b5365-c308-4bb6-b412-36b22eea59a4' as id_permission_system,
				       null as id_permission_object_parent
				from ""group"";

				--add user in group
				insert into permission_object (id, object_table, generic_id, is_group, group_name, id_permission_system, id_permission_object_parent)
				select id, 'webuser' as object_table, id_user as generic_id, false as is_group, null as group_name,
				       '4c0b5365-c308-4bb6-b412-36b22eea59a4' as id_permission_system,
				       id_group as id_permission_object_parent
				from user_group;

				--add group permissions
				insert into permission (id, comments, access, created_on, id_permission_object, id_permission_system, id_permission_system_feature)
				select id, '' as comments, is_allowed as access, now() as created_on, id_group as id_permission_object,'4c0b5365-c308-4bb6-b412-36b22eea59a4' as id_permission_system,
				id_module_permission as id_permission_system_feature from group_permission;

				--add user permissions
				insert into permission (id, comments, access, created_on, id_permission_object, id_permission_system, id_permission_system_feature)
				select id, '' as comments, is_allowed as access, now() as created_on, id_user as id_permission_object,'4c0b5365-c308-4bb6-b412-36b22eea59a4' as id_permission_system,
				id_module_permission as id_permission_system_feature from user_permission;");

			migrationBuilder.Sql(@"
				DROP VIEW building_with_todo_inspection;
				CREATE VIEW building_with_todo_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
   				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
                  (EXISTS (select * from inspection_visit where inspection_visit.id_inspection = i.id AND inspection_visit.status IN (0,1) )) AS has_been_downloaded,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN webuser as wu ON bu.id_webuser = wu.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to,
				CASE
		           WHEN ((SELECT count(inspection.id) AS count
		                  FROM inspection
		                  WHERE ((inspection.is_active = true) AND (inspection.id_batch = i.id_batch) AND
		                         (inspection.status <> 0))) > 0) THEN true
		           ELSE false END AS is_batch_started

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status in (0, 1, 4);
				");

			migrationBuilder.Sql(@"
				DROP VIEW building_with_ready_for_approbation_inspection;
				CREATE VIEW building_with_ready_for_approbation_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN webuser as wu ON bu.id_webuser = wu.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status = 2;
				");

			migrationBuilder.Sql(@"
				DROP VIEW building_with_completed_inspection;
				CREATE VIEW building_with_completed_inspection
				  AS
				SELECT
				  b.id,
				  b.id_risk_level,
				  l.id_city,
				  b.id_lane,
				  b.postal_code,
				  b.id_utilisation_code,
				  b.id_picture,
				  b.building_value,
				  b.id_lane_transversal,
				  b.matricule,
				  b.number_of_appartment,
				  b.number_of_building,
				  b.number_of_floor,
				  b.vacant_land,
				  b.year_of_construction,
				  b.details,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

				  (select i2.completed_on from inspection as i2 where i2.id_building = b.id and i2.status = 3 order by i2.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select ba.id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  i.id as id_inspection,
				  laneloc.language_code,
				  batch.description as batch_description,
				  false as has_visit_note,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.status as inspection_status,
                  i.completed_on,
				  batch.is_ready_for_inspection,
				  batch.should_start_on,
				  COALESCE((CASE WHEN i.id_webuser_assigned_to IS NOT NULL THEN
					(SELECT
					  CONCAT(
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1),''), ' ',
					  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = i.id_webuser_assigned_to limit 1), '')) as name)
					ELSE
					  (SELECT string_agg(
						  CONCAT(
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'first_name' and wua.id_webuser = bu.id_webuser limit 1),''), ' ',
						  COALESCE((select attribute_value from webuser_attributes as wua where attribute_name = 'last_name' and wua.id_webuser = bu.id_webuser limit 1), '')), ', ') as name
					  FROM batch_user as bu
						INNER JOIN webuser as wu ON bu.id_webuser = wu.id
					  where bu.id_batch = batch.id)
				  END), '') as webuser_assigned_to

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE i.is_active = true and i.status = 3;
				");
		}
    }
}
