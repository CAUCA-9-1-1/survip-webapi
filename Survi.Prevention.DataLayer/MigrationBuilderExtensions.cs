using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer
{
	public static class MigrationBuilderExtensions
	{
		public static void DropInitialInspectionViews(this MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP VIEW building_with_no_active_inspection;");
			migrationBuilder.Sql("DROP VIEW building_with_todo_inspection;");
			migrationBuilder.Sql("DROP VIEW building_with_ready_for_approbation_inspection;");
			migrationBuilder.Sql("DROP VIEW building_with_completed_inspection;");
		}

		public static void CreateInitialInspectionViews(this MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				CREATE VIEW building_with_no_active_inspection
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

				  (select completed_on from inspection as i where i.id_building = b.id and i.status = 3 order by i.completed_on desc limit 1) as last_inspection_on,
				  (select concat(bc.first_name, ' ', bc.last_name) from building_contact as bc where bc.id_building = b.id and bc.is_owner = true and bc.is_active = true limit 1) as owner,
				  (select string_agg(concat(bc.first_name, ' ', bc.last_name), ', ') from building_contact as bc where bc.id_building = b.id and bc.is_owner = false and bc.is_active = true) as contacts,
				  EXISTS(select id from building_anomaly as ba where ba.id_building = b.id and ba.is_active = true) as has_anomaly,

				  laneloc.language_code,
				  ''::text as batch_description,
				  false as has_visit_note,
				  null as id_batch,
				  b.id as id_building,
				  null as id_webuser_assigned_to,
				  0 as inspection_status,
				  false as is_ready_for_inspection,
				  null as should_start_on,
				  ''::text as webuser_assigned_to

				FROM building as b
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane

				WHERE b.is_active = true
				AND 	b.child_type = 0
				AND 	not exists(select id from inspection as i where i.id_building = b.id and (i.status IN (0, 1, 2, 4)));
				");

			migrationBuilder.Sql(@"
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
				  ''::text as webuser_assigned_to,
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
				  END), '')

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

				WHERE i.is_active = true and i.status = 3;
				");
		}
	}
}
