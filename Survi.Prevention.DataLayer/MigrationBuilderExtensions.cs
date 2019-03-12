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
			migrationBuilder.Sql("DROP VIEW building_for_report");
			migrationBuilder.Sql("DROP VIEW building_detail_for_report");
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
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,

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

			migrationBuilder.Sql(@"
				CREATE OR REPLACE VIEW building_for_report
				  AS
				SELECT
				  b.id,
				  b.id_parent_building,
				  b.child_type,

				  b.civic_number,
				  b.civic_letter,
				  b.civic_supp,
				  b.civic_letter_supp,
				  b.appartment_number,

				  b.postal_code,
				  b.building_value,
				  b.matricule,
				  b.year_of_construction,
				  b.details,

				  b.alias_name as name,

				  ucloc.name        AS utilisation_code,
				  riskloc.name             AS risk_level,

				  (CASE WHEN lpc.description != '' OR lgc.description != ''
					THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != ''
					 THEN lgc.description
															ELSE '' END, ') ')
				   ELSE laneloc.name END)  AS full_lane_name,

				  (CASE WHEN lpct.description != '' OR lgct.description != ''
					THEN concat(laneloct.name, ' (', lpct.description, CASE WHEN lgct.description != ''
					 THEN lgct.description
															  ELSE '' END, ') ')
				   ELSE laneloct.name END) AS full_transversal_lane_name,

				  (SELECT concat(bc.first_name, ' ', bc.last_name)
				   FROM building_contact AS bc
				   WHERE bc.id_building = b.id AND bc.is_owner = TRUE AND bc.is_active = TRUE
				   LIMIT 1)                AS owner_name,

				  cl.name as city_name,
				  countyloc.name as county_name,
				  state.ansi_code as state_code,
				  countryloc.name as country_name,

				  laneloc.language_code

				FROM building AS b
				  INNER JOIN building_detail AS bd ON b.id = bd.id_building
				  INNER JOIN lane AS l ON b.id_lane = l.id
				  INNER JOIN lane_public_code AS lpc ON lpc.id = l.id_public_code
				  INNER JOIN lane_generic_code AS lgc ON lgc.id = l.id_lane_generic_code
				  INNER JOIN lane_localization AS laneloc ON l.id = laneloc.id_lane

				  INNER JOIN city ON l.id_city = city.id
				  INNER JOIN city_localization as cl on city.id = cl.id_city and cl.language_code = laneloc.language_code
				  INNER JOIN county_localization as countyloc on city.id_county = countyloc.id_county and countyloc.language_code = laneloc.language_code
				  INNER JOIN county on countyloc.id_county = county.id
                  INNER JOIN region on county.id_region = region.id
				  INNER JOIN state on region.id_state = state.id
				  INNER JOIN country_localization as countryloc ON state.id_country = countryloc.id_country and countryloc.language_code = laneloc.language_code

				  LEFT JOIN lane AS lt ON b.id_lane_transversal = lt.id
				  LEFT JOIN lane_public_code AS lpct ON lpct.id = lt.id_public_code
				  LEFT JOIN lane_generic_code AS lgct ON lgct.id = lt.id_lane_generic_code
				  LEFT JOIN lane_localization AS laneloct ON lt.id = laneloct.id_lane AND laneloct.language_code = laneloc.language_code

				  LEFT JOIN utilisation_code AS uc ON b.id_utilisation_code = uc.id
				  LEFT JOIN utilisation_code_localization AS ucloc
					ON uc.id = ucloc.id_utilisation_code AND ucloc.language_code = laneloc.language_code

				  LEFT JOIN risk_level AS risk ON b.id_risk_level = risk.id
				  LEFT JOIN risk_level_localization AS riskloc
					ON riskloc.id_risk_level = risk.id AND riskloc.language_code = laneloc.language_code

				WHERE b.is_active = TRUE;
				");

			migrationBuilder.Sql(@"
				CREATE OR REPLACE VIEW building_detail_for_report
					AS
				SELECT
					bd.id,
					b.id as id_building,
					bd.height,
					bd.garage_type,
					bd.estimated_water_flow,

					btype.name as building_type,
					stype.name as siding_type,
					ctype.name as construction_type,
					cfrtype.name as construction_fire_resistance_type,
					rmtype.name as roof_material_type,
					rtype.name as roof_type,

					ewfunit.abbreviation as estimated_water_flow_unit,
					heightunit.abbreviation as height_unit,

					lang.code as language_code

				FROM building as b
				INNER JOIN building_detail as bd ON b.id = bd.id_building
				CROSS JOIN (select 'fr' as code union select 'en' as code) as lang
				LEFT JOIN building_type_localization as btype on btype.id_building_type = bd.id_building_type and btype.language_code = lang.code
				LEFT JOIN siding_type_localization as stype on stype.id_siding_type = bd.id_building_siding_type and stype.language_code = lang.code
					LEFT JOIN construction_type_localization as ctype on ctype.id_construction_type = bd.id_construction_type and ctype.language_code = lang.code
					LEFT JOIN construction_fire_resistance_type_localization as cfrtype on cfrtype.id_parent = bd.id_construction_fire_resistance_type and cfrtype.language_code = lang.code
					LEFT JOIN roof_material_type_localization as rmtype on rmtype.id_roof_material_type = bd.id_roof_material_type and rmtype.language_code = lang.code
					LEFT JOIN roof_type_localization as rtype on rtype.id_roof_type = bd.id_roof_type and rtype.language_code = lang.code
					LEFT JOIN unit_of_measure as ewfunit on ewfunit.id = bd.id_unit_of_measure_estimated_water_flow --and ewfunit.language_code = lang.code
					LEFT JOIN unit_of_measure as heightunit on heightunit.id = bd.id_unit_of_measure_height --and heightunit.language_code = lang.code

				WHERE b.is_active = true;
				");
		}

		public static void DropInspectionBuildingManagementView(this MigrationBuilder builder)
		{
			builder.Sql("DROP VIEW batch_inspection_building;");
			builder.Sql("DROP VIEW available_building_for_management;");
		}

		public static void CreateInspectionBuildingManagementView(this MigrationBuilder builder)
		{
			builder.Sql(@"
				CREATE VIEW batch_inspection_building
				  AS
				SELECT
				  i.id as id_inspection,
				  b.id_risk_level,
				  batch.id as id_batch,
				  b.id as id_building,
				  i.id_webuser_assigned_to,
				  i.id_webuser_created_by,
				  i.sequence,

				  b.matricule,
                  (EXISTS (select * from inspection_visit where inspection_visit.id_inspection = i.id AND inspection_visit.status IN (0,1) )) AS has_been_downloaded,
				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,
				  city.name as city_name,
				  risk.name as risk_level,
				  
				  laneloc.language_code,
				  i.status as inspection_status

				FROM inspection as i
				INNER JOIN batch on batch.id = i.id_batch
				INNER JOIN building as b ON i.id_building = b.id AND b.is_active = true and b.child_type = 0
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane
				INNER JOIN city_localization as city ON l.id_city = city.id_city and city.language_code = laneloc.language_code
				LEFT JOIN risk_level_localization as risk ON b.id_risk_level = risk.id_risk_level and risk.language_code = laneloc.language_code

				WHERE i.is_active = true
				AND 	b.child_type = 0
				");

			builder.Sql(@"
				CREATE VIEW available_building_for_management
				  AS
				SELECT
				  b.id_risk_level,
				  b.id as id_building,
				  l.id_city,

				  b.matricule,

				  (CASE WHEN lpc.description != '' or lgc.description != '' THEN concat(laneloc.name, ' (', lpc.description, CASE WHEN lgc.description != '' THEN lgc.description ELSE ''END, ')' ) ELSE laneloc.name END) as full_lane_name,
				  CONCAT(b.civic_number, b.civic_letter) as full_civic_number,
				  LPAD(CONCAT(b.civic_number, b.civic_letter), 10, '0') as full_civic_number_sortable,
				  city.name as city_name,
				  risk.name as risk_level,
				  
				  laneloc.language_code

				FROM building as b
				INNER JOIN lane as l on b.id_lane = l.id
				INNER JOIN lane_public_code as lpc ON lpc.id = l.id_public_code
				INNER JOIN lane_generic_code as lgc ON lgc.id = l.id_lane_generic_code
				INNER JOIN lane_localization as laneloc ON l.id = laneloc.id_lane
				INNER JOIN city_localization as city ON l.id_city = city.id_city and city.language_code = laneloc.language_code
				LEFT JOIN risk_level_localization as risk ON b.id_risk_level = risk.id_risk_level and risk.language_code = laneloc.language_code

				WHERE b.is_active = true
				AND 	b.child_type = 0
				AND 	not exists(select id from inspection as i where i.id_building = b.id and (i.status IN (0, 1, 2, 4)));
				");
		}
	}
}
