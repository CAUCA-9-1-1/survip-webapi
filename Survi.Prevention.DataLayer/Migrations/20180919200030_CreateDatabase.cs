using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.CreateTable(
                name: "access_secret_key",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    application_name = table.Column<string>(maxLength: 50, nullable: false),
                    random_key = table.Column<string>(maxLength: 100, nullable: false),
                    secret_key = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_secret_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alarm_panel_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alarm_panel_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "building_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "construction_fire_resistance_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_construction_fire_resistance_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "construction_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_construction_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    code_alpha2 = table.Column<string>(maxLength: 2, nullable: false),
                    code_alpha3 = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant_connection_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant_connection_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hazardous_material",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    number = table.Column<string>(maxLength: 50, nullable: false),
                    guide_number = table.Column<string>(maxLength: 255, nullable: false),
                    react_to_water = table.Column<bool>(nullable: false),
                    toxic_inhalation_hazard = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hazardous_material", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inspection_picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    mime_type = table.Column<string>(nullable: true),
                    data = table.Column<byte[]>(nullable: false),
                    sketch_json = table.Column<string>(type: "json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_picture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lane_generic_code",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(maxLength: 1, nullable: false),
                    description = table.Column<string>(maxLength: 15, nullable: false),
                    add_white_space_after = table.Column<bool>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lane_generic_code", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lane_public_code",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(maxLength: 2, nullable: false),
                    description = table.Column<string>(maxLength: 20, nullable: false),
                    abbreviation = table.Column<string>(maxLength: 2, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lane_public_code", x => x.id);
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
                name: "person_requiring_assistance_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_requiring_assistance_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    mime_type = table.Column<string>(nullable: true),
                    data = table.Column<byte[]>(nullable: false),
                    sketch_json = table.Column<string>(type: "json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_picture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "report_configuration_template",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    data = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_report_configuration_template", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "risk_level",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    sequence = table.Column<int>(nullable: false),
                    code = table.Column<int>(nullable: false),
                    color = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_risk_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roof_material_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roof_material_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roof_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roof_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "siding_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_siding_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sprinkler_type",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sprinkler_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    survey_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit_of_measure",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    abbreviation = table.Column<string>(maxLength: 5, nullable: false),
                    measure_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit_of_measure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "utilisation_code",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    cubf = table.Column<string>(maxLength: 5, nullable: false),
                    scian = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisation_code", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "webuser",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    username = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_webuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alarm_panel_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_alarm_panel_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alarm_panel_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_alarm_panel_type_localization_alarm_panel_type_parent_id",
                        column: x => x.id_alarm_panel_type,
                        principalTable: "alarm_panel_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_type_localization_building_type_parent_id",
                        column: x => x.id_building_type,
                        principalTable: "building_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_city_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_type_localization_city_type_parent_id",
                        column: x => x.id_city_type,
                        principalTable: "city_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "construction_fire_resistance_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_parent = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_construction_fire_resistance_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_construction_fire_resistance_type_localization_construction~",
                        column: x => x.id_parent,
                        principalTable: "construction_fire_resistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "construction_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_construction_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_construction_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_construction_type_localization_construction_type_parent_id",
                        column: x => x.id_construction_type,
                        principalTable: "construction_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "country_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_country = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_country_localization_country_parent_id",
                        column: x => x.id_country,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    ansi_code = table.Column<string>(maxLength: 2, nullable: false),
                    id_country = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_state", x => x.id);
                    table.ForeignKey(
                        name: "fk_state_country_country_id",
                        column: x => x.id_country,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant_connection_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_hydrant_connection_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant_connection_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_connection_type_localization_fire_hydrant_conn~",
                        column: x => x.id_fire_hydrant_connection_type,
                        principalTable: "fire_hydrant_connection_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_hydrant_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_type_localization_fire_hydrant_type_parent_id",
                        column: x => x.id_fire_hydrant_type,
                        principalTable: "fire_hydrant_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hazardous_material_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_hazardous_material = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hazardous_material_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_hazardous_material_localization_hazardous_material_parent_id",
                        column: x => x.id_hazardous_material,
                        principalTable: "hazardous_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_object",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    object_table = table.Column<string>(maxLength: 255, nullable: false),
                    generic_id = table.Column<string>(maxLength: 50, nullable: true),
                    is_group = table.Column<bool>(nullable: false),
                    group_name = table.Column<string>(maxLength: 50, nullable: true),
                    id_permission_system = table.Column<Guid>(nullable: false),
                    id_permission_object_parent = table.Column<Guid>(nullable: true)
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
                    feature_name = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: false),
                    default_value = table.Column<bool>(nullable: false),
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
                name: "person_requiring_assistance_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_person_requiring_assistance_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_requiring_assistance_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_person_requiring_assistance_type_localization_person_requir~",
                        column: x => x.id_person_requiring_assistance_type,
                        principalTable: "person_requiring_assistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "risk_level_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_risk_level = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_risk_level_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_risk_level_localization_risk_level_parent_id",
                        column: x => x.id_risk_level,
                        principalTable: "risk_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roof_material_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_roof_material_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roof_material_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_roof_material_type_localization_roof_material_type_parent_id",
                        column: x => x.id_roof_material_type,
                        principalTable: "roof_material_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roof_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_roof_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roof_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_roof_type_localization_roof_type_parent_id",
                        column: x => x.id_roof_type,
                        principalTable: "roof_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "siding_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_siding_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_siding_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_siding_type_localization_siding_type_parent_id",
                        column: x => x.id_siding_type,
                        principalTable: "siding_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sprinkler_type_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_sprinkler_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sprinkler_type_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_sprinkler_type_localization_sprinkler_type_parent_id",
                        column: x => x.id_sprinkler_type,
                        principalTable: "sprinkler_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_safety_department_risk_level",
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
                    id_risk_level = table.Column<Guid>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "survey_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_survey_localization_survey_parent_id",
                        column: x => x.id_survey,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "survey_question",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    sequence = table.Column<int>(nullable: false),
                    question_type = table.Column<int>(nullable: false),
                    max_occurrence = table.Column<int>(nullable: false),
                    min_occurrence = table.Column<int>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: false),
                    id_survey_question_next = table.Column<Guid>(nullable: true),
                    is_recursive = table.Column<bool>(nullable: false),
                    id_survey_question_parent = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_survey_question_survey_survey_id",
                        column: x => x.id_survey,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_survey_question_survey_question_next_question_id",
                        column: x => x.id_survey_question_next,
                        principalTable: "survey_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unit_of_measure_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_parent = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit_of_measure_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_unit_of_measure_localization_unit_of_measure_parent_id",
                        column: x => x.id_parent,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisation_code_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_utilisation_code = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisation_code_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_utilisation_code_localization_utilisation_code_parent_id",
                        column: x => x.id_utilisation_code,
                        principalTable: "utilisation_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "access_token",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    token_for_access = table.Column<string>(maxLength: 500, nullable: false),
                    refresh_token = table.Column<string>(maxLength: 100, nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    expires_in = table.Column<int>(nullable: false),
                    id_webuser = table.Column<Guid>(nullable: false)
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
                name: "batch",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    should_start_on = table.Column<DateTime>(nullable: true),
                    is_ready_for_inspection = table.Column<bool>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: false),
                    id_webuser_created_by = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batch", x => x.id);
                    table.ForeignKey(
                        name: "fk_batch_webusers_created_by_id",
                        column: x => x.id_webuser_created_by,
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
                name: "region",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    id_state = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region", x => x.id);
                    table.ForeignKey(
                        name: "fk_region_states_state_id",
                        column: x => x.id_state,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_state = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_state_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_state_localization_state_parent_id",
                        column: x => x.id_state,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    access = table.Column<bool>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "survey_question_choice",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    sequence = table.Column<int>(nullable: false),
                    id_survey_question = table.Column<Guid>(nullable: false),
                    id_survey_question_next = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_question_choice", x => x.id);
                    table.ForeignKey(
                        name: "FK_survey_question_choice_survey_question_id_survey_question",
                        column: x => x.id_survey_question,
                        principalTable: "survey_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_survey_question_choice_survey_question_id_survey_question_n~",
                        column: x => x.id_survey_question_next,
                        principalTable: "survey_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "survey_question_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_survey_question = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_question_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_survey_question_localization_survey_question_parent_id",
                        column: x => x.id_survey_question,
                        principalTable: "survey_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "batch_user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    id_webuser = table.Column<Guid>(nullable: false),
                    id_batch = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batch_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_batch_user_batch_batch_id",
                        column: x => x.id_batch,
                        principalTable: "batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_batch_user_webusers_user_id",
                        column: x => x.id_webuser,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "county",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_region = table.Column<Guid>(nullable: false),
                    id_state = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_county", x => x.id);
                    table.ForeignKey(
                        name: "fk_county_regions_region_id",
                        column: x => x.id_region,
                        principalTable: "region",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_county_states_state_id",
                        column: x => x.id_state,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "region_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_region = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_region_localization_region_parent_id",
                        column: x => x.id_region,
                        principalTable: "region",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "survey_question_choice_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_survey_question_choice = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_question_choice_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_survey_question_choice_localization_survey_question_choice_~",
                        column: x => x.id_survey_question_choice,
                        principalTable: "survey_question_choice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    code3_letters = table.Column<string>(maxLength: 3, nullable: false),
                    email_address = table.Column<string>(maxLength: 100, nullable: false),
                    id_city_type = table.Column<Guid>(nullable: false),
                    id_county = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_city_types_city_type_id",
                        column: x => x.id_city_type,
                        principalTable: "city_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_city_counties_county_id",
                        column: x => x.id_county,
                        principalTable: "county",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "county_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_county = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_county_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_county_localization_county_parent_id",
                        column: x => x.id_county,
                        principalTable: "county",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_safety_department",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    language = table.Column<string>(maxLength: 2, nullable: false),
                    id_county = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_county_county_id",
                        column: x => x.id_county,
                        principalTable: "county",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_city = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_localization_city_parent_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lane",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    is_valid = table.Column<bool>(nullable: false),
                    id_public_code = table.Column<Guid>(nullable: true),
                    id_lane_generic_code = table.Column<Guid>(nullable: true),
                    id_city = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lane", x => x.id);
                    table.ForeignKey(
                        name: "fk_lane_city_city_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lane_lane_generic_codes_lane_generic_code_id",
                        column: x => x.id_lane_generic_code,
                        principalTable: "lane_generic_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lane_lane_public_codes_public_code_id",
                        column: x => x.id_public_code,
                        principalTable: "lane_public_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fire_safety_department_city_serving",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_safety_department = table.Column<Guid>(nullable: false),
                    id_city = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department_city_serving", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_city_serving_city_city_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_city_serving_fire_safety_department_~",
                        column: x => x.id_fire_safety_department,
                        principalTable: "fire_safety_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_safety_department_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_fire_hydrant_type = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_safety_department_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_safety_department_localization_fire_safety_department_~",
                        column: x => x.id_fire_hydrant_type,
                        principalTable: "fire_safety_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "webuser_fire_safety_department",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_webuser = table.Column<Guid>(nullable: false),
                    id_fire_safety_department = table.Column<Guid>(nullable: false)
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
                name: "building",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    building_value = table.Column<decimal>(nullable: false),
                    child_type = table.Column<int>(nullable: false),
                    id_city = table.Column<Guid>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: false),
                    id_lane_transversal = table.Column<Guid>(nullable: true),
                    id_parent_building = table.Column<Guid>(nullable: true),
                    id_picture = table.Column<Guid>(nullable: true),
                    id_risk_level = table.Column<Guid>(nullable: false),
                    id_utilisation_code = table.Column<Guid>(nullable: true),
                    number_of_appartment = table.Column<int>(nullable: false),
                    number_of_building = table.Column<int>(nullable: false),
                    number_of_floor = table.Column<int>(nullable: false),
                    coordinates = table.Column<Point>(type: "geometry", nullable: true),
                    show_in_resources = table.Column<bool>(nullable: false),
                    suite = table.Column<int>(nullable: false),
                    vacant_land = table.Column<bool>(nullable: false),
                    year_of_construction = table.Column<int>(nullable: false),
                    civic_number = table.Column<string>(maxLength: 15, nullable: false),
                    civic_letter = table.Column<string>(maxLength: 10, nullable: false),
                    civic_supp = table.Column<string>(maxLength: 10, nullable: false),
                    civic_letter_supp = table.Column<string>(maxLength: 10, nullable: false),
                    appartment_number = table.Column<string>(maxLength: 10, nullable: false),
                    floor = table.Column<string>(maxLength: 10, nullable: false),
                    postal_code = table.Column<string>(maxLength: 6, nullable: false),
                    source = table.Column<string>(maxLength: 25, nullable: false),
                    utilisation_description = table.Column<string>(maxLength: 255, nullable: false),
                    matricule = table.Column<string>(maxLength: 18, nullable: false),
                    coordinates_source = table.Column<string>(maxLength: 50, nullable: false),
                    details = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_cities_city_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_lanes_lane_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_lanes_transversal_id",
                        column: x => x.id_lane_transversal,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_building_parent_id",
                        column: x => x.id_parent_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_pictures_picture_id",
                        column: x => x.id_picture,
                        principalTable: "picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_risk_levels_risk_level_id",
                        column: x => x.id_risk_level,
                        principalTable: "risk_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_utilisation_codes_utilisation_code_id",
                        column: x => x.id_utilisation_code,
                        principalTable: "utilisation_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    location_type = table.Column<int>(nullable: false),
                    coordinates = table.Column<Point>(type: "geometry", nullable: true),
                    altitude = table.Column<decimal>(nullable: false),
                    number = table.Column<string>(maxLength: 10, nullable: false),
                    rate_from = table.Column<decimal>(maxLength: 5, nullable: true),
                    rate_to = table.Column<decimal>(maxLength: 5, nullable: true),
                    pressure_from = table.Column<decimal>(maxLength: 5, nullable: true),
                    pressure_to = table.Column<decimal>(maxLength: 5, nullable: true),
                    color = table.Column<string>(maxLength: 50, nullable: false),
                    comments = table.Column<string>(nullable: true),
                    physical_position = table.Column<string>(maxLength: 200, nullable: true),
                    civic_number = table.Column<string>(maxLength: 5, nullable: true),
                    address_location_type = table.Column<int>(nullable: false),
                    id_city = table.Column<Guid>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: true),
                    id_intersection = table.Column<Guid>(nullable: true),
                    id_fire_hydrant_type = table.Column<Guid>(nullable: false),
                    id_unit_of_measure_rate = table.Column<Guid>(nullable: true),
                    id_unit_of_measure_pressure = table.Column<Guid>(nullable: true),
                    rate_operator_type = table.Column<int>(nullable: false),
                    pressure_operator_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_cities_city_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_fire_hydrant_types_hydrant_type_id",
                        column: x => x.id_fire_hydrant_type,
                        principalTable: "fire_hydrant_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_lanes_intersection_id",
                        column: x => x.id_intersection,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_lanes_lane_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_unit_of_measures_pressure_unit_of_measure_id",
                        column: x => x.id_unit_of_measure_pressure,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_unit_of_measures_rate_unit_of_measure_id",
                        column: x => x.id_unit_of_measure_rate,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lane_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lane_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_lane_localization_lane_parent_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_alarm_panel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_alarm_panel_type = table.Column<Guid>(nullable: true),
                    id_building = table.Column<Guid>(nullable: false),
                    floor = table.Column<string>(maxLength: 100, nullable: true),
                    wall = table.Column<string>(maxLength: 100, nullable: true),
                    sector = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_alarm_panel", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_alarm_panel_alarm_panel_type_alarm_panel_type_id",
                        column: x => x.id_alarm_panel_type,
                        principalTable: "alarm_panel_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_alarm_panel_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_anomaly",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    theme = table.Column<string>(maxLength: 50, nullable: false),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_anomaly", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_anomaly_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_contact",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    call_priority = table.Column<int>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    is_owner = table.Column<bool>(nullable: false),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    phone_number = table.Column<string>(maxLength: 10, nullable: false),
                    phone_number_extension = table.Column<string>(maxLength: 10, nullable: false),
                    pager_number = table.Column<string>(maxLength: 10, nullable: false),
                    pager_code = table.Column<string>(maxLength: 10, nullable: false),
                    cellphone_number = table.Column<string>(maxLength: 10, nullable: false),
                    other_number = table.Column<string>(maxLength: 10, nullable: false),
                    other_number_extension = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_contact_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    approved_on = table.Column<DateTime>(nullable: true),
                    estimated_water_flow = table.Column<int>(nullable: false),
                    fire_resistance_type_id = table.Column<Guid>(nullable: true),
                    garage_type = table.Column<int>(nullable: false),
                    height = table.Column<decimal>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_building_siding_type = table.Column<Guid>(nullable: true),
                    id_building_type = table.Column<Guid>(nullable: true),
                    id_construction_fire_resistance_type = table.Column<Guid>(nullable: true),
                    id_construction_type = table.Column<Guid>(nullable: true),
                    id_picture_plan = table.Column<Guid>(nullable: true),
                    id_roof_material_type = table.Column<Guid>(nullable: true),
                    id_roof_type = table.Column<Guid>(nullable: true),
                    id_unit_of_measure_estimated_water_flow = table.Column<Guid>(nullable: true),
                    id_unit_of_measure_height = table.Column<Guid>(nullable: true),
                    revised_on = table.Column<DateTime>(nullable: true),
                    additional_information = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_detail_construction_fire_resistance_types_fire_resist~",
                        column: x => x.fire_resistance_type_id,
                        principalTable: "construction_fire_resistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_building_details_detail_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_detail_siding_types_siding_type_id",
                        column: x => x.id_building_siding_type,
                        principalTable: "siding_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_detail_building_types_building_type_id",
                        column: x => x.id_building_type,
                        principalTable: "building_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_construction_type",
                        column: x => x.id_construction_type,
                        principalTable: "construction_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_detail_pictures_plan_picture_id",
                        column: x => x.id_picture_plan,
                        principalTable: "picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_detail_roof_material_types_roof_material_type_id",
                        column: x => x.id_roof_material_type,
                        principalTable: "roof_material_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_building_detail_roof_types_roof_type_id",
                        column: x => x.id_roof_type,
                        principalTable: "roof_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_unit_of_measure_ewf",
                        column: x => x.id_unit_of_measure_estimated_water_flow,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_unit_of_measure_height",
                        column: x => x.id_unit_of_measure_height,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "building_hazardous_material",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    capacity_container = table.Column<decimal>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_hazardous_material = table.Column<Guid>(nullable: false),
                    id_unit_of_measure = table.Column<Guid>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    tank_type = table.Column<int>(nullable: false),
                    container = table.Column<string>(maxLength: 100, nullable: false),
                    place = table.Column<string>(maxLength: 150, nullable: false),
                    wall = table.Column<string>(maxLength: 15, nullable: false),
                    sector = table.Column<string>(maxLength: 15, nullable: false),
                    floor = table.Column<string>(maxLength: 4, nullable: false),
                    gas_inlet = table.Column<string>(maxLength: 100, nullable: false),
                    security_perimeter = table.Column<string>(nullable: false),
                    other_information = table.Column<string>(nullable: false),
                    supply_line = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_hazardous_material", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_hazardous_material_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_hazardous_material_hazardous_materials_material_id",
                        column: x => x.id_hazardous_material,
                        principalTable: "hazardous_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_hazardous_material_unit_of_measures_unit_id",
                        column: x => x.id_unit_of_measure,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "building_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_localization_building_parent_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_particular_risk",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    has_opening = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    is_weakened = table.Column<bool>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    wall = table.Column<string>(maxLength: 15, nullable: true),
                    sector = table.Column<string>(maxLength: 15, nullable: true),
                    dimension = table.Column<string>(maxLength: 100, nullable: true),
                    risk_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_particular_risk", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_particular_risk_buildings_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_person_requiring_assistance",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    day_is_approximate = table.Column<bool>(nullable: false),
                    day_resident_count = table.Column<int>(nullable: false),
                    evening_is_approximate = table.Column<bool>(nullable: false),
                    evening_resident_count = table.Column<int>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_person_requiring_assistance_type = table.Column<Guid>(nullable: false),
                    night_is_approximate = table.Column<bool>(nullable: false),
                    night_resident_count = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    person_name = table.Column<string>(maxLength: 60, nullable: false),
                    floor = table.Column<string>(maxLength: 3, nullable: false),
                    local = table.Column<string>(maxLength: 10, nullable: false),
                    contact_name = table.Column<string>(maxLength: 60, nullable: false),
                    contact_phone_number = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_person_requiring_assistance", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_person_requiring_assistance_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_person_requiring_assistance_person_requiring_assista~",
                        column: x => x.id_person_requiring_assistance_type,
                        principalTable: "person_requiring_assistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_sprinkler",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_sprinkler_type = table.Column<Guid>(nullable: false),
                    floor = table.Column<string>(maxLength: 100, nullable: true),
                    wall = table.Column<string>(maxLength: 100, nullable: true),
                    sector = table.Column<string>(maxLength: 100, nullable: true),
                    pipe_location = table.Column<string>(nullable: true),
                    collector_location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_sprinkler", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_sprinkler_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_sprinkler_sprinkler_types_sprinkler_type_id",
                        column: x => x.id_sprinkler_type,
                        principalTable: "sprinkler_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "firestation",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(maxLength: 10, nullable: true),
                    fax_number = table.Column<string>(maxLength: 10, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    id_building = table.Column<Guid>(nullable: true),
                    id_fire_safety_department = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_firestation", x => x.id);
                    table.ForeignKey(
                        name: "fk_firestation_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_firestation_fire_safety_department_fire_safety_department_id",
                        column: x => x.id_fire_safety_department,
                        principalTable: "fire_safety_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_survey = table.Column<Guid>(nullable: true),
                    id_building = table.Column<Guid>(nullable: false),
                    id_webuser_created_by = table.Column<Guid>(nullable: false),
                    id_webuser_assigned_to = table.Column<Guid>(nullable: true),
                    id_batch = table.Column<Guid>(nullable: false),
                    sequence = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    started_on = table.Column<DateTime>(nullable: true),
                    completed_on = table.Column<DateTime>(nullable: true),
                    survey_completed_on = table.Column<DateTime>(nullable: true),
                    is_survey_completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_batch_batch_id",
                        column: x => x.id_batch,
                        principalTable: "batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_main_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_surveys_survey_id",
                        column: x => x.id_survey,
                        principalTable: "survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_webusers_assigned_to_id",
                        column: x => x.id_webuser_assigned_to,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_webusers_created_by_id",
                        column: x => x.id_webuser_created_by,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_fire_hydrant",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    deleted_on = table.Column<DateTime>(nullable: true),
                    id_building = table.Column<Guid>(nullable: false),
                    id_fire_hydrant = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_fire_hydrant", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_fire_hydrant_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_fire_hydrant_fire_hydrants_hydrant_id",
                        column: x => x.id_fire_hydrant,
                        principalTable: "fire_hydrant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fire_hydrant_connection",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    diameter = table.Column<decimal>(nullable: false),
                    id_fire_hydrant = table.Column<Guid>(nullable: false),
                    id_unit_of_measure_diameter = table.Column<Guid>(nullable: false),
                    id_fire_hydrant_connection_type = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fire_hydrant_connection", x => x.id);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_connection_fire_hydrant_hydrant_id",
                        column: x => x.id_fire_hydrant,
                        principalTable: "fire_hydrant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_connection_fire_hydrant_connection_types_connecti~",
                        column: x => x.id_fire_hydrant_connection_type,
                        principalTable: "fire_hydrant_connection_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fire_hydrant_connection_unit_of_measures_diameter_unit_of_mea~",
                        column: x => x.id_unit_of_measure_diameter,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_anomaly_picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building_anomaly = table.Column<Guid>(nullable: false),
                    id_picture = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_anomaly_picture", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_anomaly_picture_building_anomaly_anomaly_id",
                        column: x => x.id_building_anomaly,
                        principalTable: "building_anomaly",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_anomaly_picture_pictures_picture_id",
                        column: x => x.id_picture,
                        principalTable: "picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_particular_risk_picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building_particular_risk = table.Column<Guid>(nullable: false),
                    id_picture = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_particular_risk_picture", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_particular_risk_picture_building_particular_risk_r~",
                        column: x => x.id_building_particular_risk,
                        principalTable: "building_particular_risk",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_particular_risk_picture_pictures_picture_id",
                        column: x => x.id_picture,
                        principalTable: "picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building_course",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_firestation = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_course", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_course_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_course_firestations_firestation_id",
                        column: x => x.id_firestation,
                        principalTable: "firestation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    building_value = table.Column<decimal>(nullable: false),
                    child_type = table.Column<int>(nullable: false),
                    id_city = table.Column<Guid>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: false),
                    id_lane_transversal = table.Column<Guid>(nullable: true),
                    id_parent_building = table.Column<Guid>(nullable: true),
                    id_picture = table.Column<Guid>(nullable: true),
                    id_risk_level = table.Column<Guid>(nullable: false),
                    id_utilisation_code = table.Column<Guid>(nullable: true),
                    number_of_appartment = table.Column<int>(nullable: false),
                    number_of_building = table.Column<int>(nullable: false),
                    number_of_floor = table.Column<int>(nullable: false),
                    coordinates = table.Column<Point>(type: "geometry", nullable: true),
                    show_in_resources = table.Column<bool>(nullable: false),
                    suite = table.Column<int>(nullable: false),
                    vacant_land = table.Column<bool>(nullable: false),
                    year_of_construction = table.Column<int>(nullable: false),
                    civic_number = table.Column<string>(maxLength: 15, nullable: false),
                    civic_letter = table.Column<string>(maxLength: 10, nullable: false),
                    civic_supp = table.Column<string>(maxLength: 10, nullable: false),
                    civic_letter_supp = table.Column<string>(maxLength: 10, nullable: false),
                    appartment_number = table.Column<string>(maxLength: 10, nullable: false),
                    floor = table.Column<string>(maxLength: 10, nullable: false),
                    postal_code = table.Column<string>(maxLength: 6, nullable: false),
                    source = table.Column<string>(maxLength: 25, nullable: false),
                    utilisation_description = table.Column<string>(maxLength: 255, nullable: false),
                    matricule = table.Column<string>(maxLength: 18, nullable: false),
                    coordinates_source = table.Column<string>(maxLength: 50, nullable: false),
                    details = table.Column<string>(nullable: false),
                    id_inspection = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_city_city_id",
                        column: x => x.id_city,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_inspections_inspection_id",
                        column: x => x.id_inspection,
                        principalTable: "inspection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_lane_lane_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_lane_transversal_id",
                        column: x => x.id_lane_transversal,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_inspection_building_parent_id",
                        column: x => x.id_parent_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_inspection_pictures_picture_id",
                        column: x => x.id_picture,
                        principalTable: "inspection_picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_risk_level_risk_level_id",
                        column: x => x.id_risk_level,
                        principalTable: "risk_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_utilisation_code_utilisation_code_id",
                        column: x => x.id_utilisation_code,
                        principalTable: "utilisation_code",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inspection_survey_answer",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_inspection = table.Column<Guid>(nullable: false),
                    id_survey_question = table.Column<Guid>(nullable: false),
                    id_survey_question_choice = table.Column<Guid>(nullable: true),
                    answer = table.Column<string>(maxLength: 200, nullable: false),
                    id_survey_answer_parent = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_survey_answer", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_survey_answer_inspection_inspection_id",
                        column: x => x.id_inspection,
                        principalTable: "inspection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_survey_answer_survey_questions_question_id",
                        column: x => x.id_survey_question,
                        principalTable: "survey_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_survey_answer_survey_question_choices_choice_id",
                        column: x => x.id_survey_question_choice,
                        principalTable: "survey_question_choice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inspection_visit",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    reason_for_approbation_refusal = table.Column<string>(nullable: true),
                    reason_for_inspection_refusal = table.Column<string>(nullable: true),
                    has_been_refused = table.Column<bool>(nullable: false),
                    owner_was_absent = table.Column<bool>(nullable: false),
                    is_seasonal = table.Column<bool>(nullable: false),
                    is_vacant = table.Column<bool>(nullable: false),
                    door_hanger_has_been_left = table.Column<bool>(nullable: false),
                    requested_date_of_visit = table.Column<DateTime>(nullable: true),
                    started_on = table.Column<DateTime>(nullable: true),
                    ended_on = table.Column<DateTime>(nullable: true),
                    id_inspection = table.Column<Guid>(nullable: false),
                    id_webuser_visited_by = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_visit", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_visit_inspection_inspection_id",
                        column: x => x.id_inspection,
                        principalTable: "inspection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_visit_webusers_visited_by_id",
                        column: x => x.id_webuser_visited_by,
                        principalTable: "webuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "building_course_lane",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    direction = table.Column<int>(nullable: false),
                    id_building_course = table.Column<Guid>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: false),
                    sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_course_lane", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_course_lane_building_course_course_id",
                        column: x => x.id_building_course,
                        principalTable: "building_course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_building_course_lane_lanes_lane_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_alarm_panel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_alarm_panel_type = table.Column<Guid>(nullable: true),
                    id_building = table.Column<Guid>(nullable: false),
                    floor = table.Column<string>(maxLength: 100, nullable: true),
                    wall = table.Column<string>(maxLength: 100, nullable: true),
                    sector = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_alarm_panel", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_alarm_panel_alarm_panel_type_alarm_pane~",
                        column: x => x.id_alarm_panel_type,
                        principalTable: "alarm_panel_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_alarm_panel_inspection_building_buildin~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_anomaly",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    theme = table.Column<string>(maxLength: 50, nullable: false),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_anomaly", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_anomaly_inspection_building_building_id",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_contact",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    call_priority = table.Column<int>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    is_owner = table.Column<bool>(nullable: false),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    phone_number = table.Column<string>(maxLength: 10, nullable: false),
                    phone_number_extension = table.Column<string>(maxLength: 10, nullable: false),
                    pager_number = table.Column<string>(maxLength: 10, nullable: false),
                    pager_code = table.Column<string>(maxLength: 10, nullable: false),
                    cellphone_number = table.Column<string>(maxLength: 10, nullable: false),
                    other_number = table.Column<string>(maxLength: 10, nullable: false),
                    other_number_extension = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_contact_inspection_building_building_id",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_course",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_firestation = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_course", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_course_inspection_building_building_id",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_course_firestation_firestation_id",
                        column: x => x.id_firestation,
                        principalTable: "firestation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    approved_on = table.Column<DateTime>(nullable: true),
                    estimated_water_flow = table.Column<int>(nullable: false),
                    fire_resistance_type_id = table.Column<Guid>(nullable: true),
                    garage_type = table.Column<int>(nullable: false),
                    height = table.Column<decimal>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_building_siding_type = table.Column<Guid>(nullable: true),
                    id_building_type = table.Column<Guid>(nullable: true),
                    id_construction_fire_resistance_type = table.Column<Guid>(nullable: true),
                    id_construction_type = table.Column<Guid>(nullable: true),
                    id_picture_plan = table.Column<Guid>(nullable: true),
                    id_roof_material_type = table.Column<Guid>(nullable: true),
                    id_roof_type = table.Column<Guid>(nullable: true),
                    id_unit_of_measure_estimated_water_flow = table.Column<Guid>(nullable: true),
                    id_unit_of_measure_height = table.Column<Guid>(nullable: true),
                    revised_on = table.Column<DateTime>(nullable: true),
                    additional_information = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_construction_fire_resistance_typ~",
                        column: x => x.fire_resistance_type_id,
                        principalTable: "construction_fire_resistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_inspection_building_details_detail_id",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_siding_type_siding_type_id",
                        column: x => x.id_building_siding_type,
                        principalTable: "siding_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_building_type_building_type_id",
                        column: x => x.id_building_type,
                        principalTable: "building_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_construction_type",
                        column: x => x.id_construction_type,
                        principalTable: "construction_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_inspection_pictures_plan_picture_~",
                        column: x => x.id_picture_plan,
                        principalTable: "inspection_picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_roof_material_type_roof_material~",
                        column: x => x.id_roof_material_type,
                        principalTable: "roof_material_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inspection_building_detail_roof_type_roof_type_id",
                        column: x => x.id_roof_type,
                        principalTable: "roof_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_unit_of_measure_ewf",
                        column: x => x.id_unit_of_measure_estimated_water_flow,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_unit_of_measure_height",
                        column: x => x.id_unit_of_measure_height,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_fire_hydrant",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    deleted_on = table.Column<DateTime>(nullable: true),
                    id_building = table.Column<Guid>(nullable: false),
                    id_fire_hydrant = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_fire_hydrant", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_fire_hydrant_inspection_building_buildi~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_fire_hydrant_fire_hydrant_hydrant_id",
                        column: x => x.id_fire_hydrant,
                        principalTable: "fire_hydrant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_hazardous_material",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    capacity_container = table.Column<decimal>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_hazardous_material = table.Column<Guid>(nullable: false),
                    id_unit_of_measure = table.Column<Guid>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    tank_type = table.Column<int>(nullable: false),
                    container = table.Column<string>(maxLength: 100, nullable: false),
                    place = table.Column<string>(maxLength: 150, nullable: false),
                    wall = table.Column<string>(maxLength: 15, nullable: false),
                    sector = table.Column<string>(maxLength: 15, nullable: false),
                    floor = table.Column<string>(maxLength: 4, nullable: false),
                    gas_inlet = table.Column<string>(maxLength: 100, nullable: false),
                    security_perimeter = table.Column<string>(nullable: false),
                    other_information = table.Column<string>(nullable: false),
                    supply_line = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_hazardous_material", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_hazardous_material_inspection_building_~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_hazardous_material_hazardous_material_m~",
                        column: x => x.id_hazardous_material,
                        principalTable: "hazardous_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_hazardous_material_unit_of_measures_unit_~",
                        column: x => x.id_unit_of_measure,
                        principalTable: "unit_of_measure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_localization_inspection_building_parent~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_particular_risk",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    has_opening = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    is_weakened = table.Column<bool>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    wall = table.Column<string>(maxLength: 15, nullable: true),
                    sector = table.Column<string>(maxLength: 15, nullable: true),
                    dimension = table.Column<string>(maxLength: 100, nullable: true),
                    risk_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_particular_risk", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_particular_risk_inspection_building_bui~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_person_requiring_assistance",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    day_is_approximate = table.Column<bool>(nullable: false),
                    day_resident_count = table.Column<int>(nullable: false),
                    evening_is_approximate = table.Column<bool>(nullable: false),
                    evening_resident_count = table.Column<int>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_person_requiring_assistance_type = table.Column<Guid>(nullable: false),
                    night_is_approximate = table.Column<bool>(nullable: false),
                    night_resident_count = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    person_name = table.Column<string>(maxLength: 60, nullable: false),
                    floor = table.Column<string>(maxLength: 3, nullable: false),
                    local = table.Column<string>(maxLength: 10, nullable: false),
                    contact_name = table.Column<string>(maxLength: 60, nullable: false),
                    contact_phone_number = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_person_requiring_assistance", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_person_requiring_assistance_inspection_~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_person_requiring_assistance_person_requ~",
                        column: x => x.id_person_requiring_assistance_type,
                        principalTable: "person_requiring_assistance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_sprinkler",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_sprinkler_type = table.Column<Guid>(nullable: false),
                    floor = table.Column<string>(maxLength: 100, nullable: true),
                    wall = table.Column<string>(maxLength: 100, nullable: true),
                    sector = table.Column<string>(maxLength: 100, nullable: true),
                    pipe_location = table.Column<string>(nullable: true),
                    collector_location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_sprinkler", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_sprinkler_inspection_building_building_~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_sprinkler_sprinkler_type_sprinkler_type~",
                        column: x => x.id_sprinkler_type,
                        principalTable: "sprinkler_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_anomaly_picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_picture = table.Column<Guid>(nullable: false),
                    id_building_anomaly = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_anomaly_picture", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_anomaly_picture_inspection_building_ano~",
                        column: x => x.id_building_anomaly,
                        principalTable: "inspection_building_anomaly",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_anomaly_picture_inspection_pictures_pict~",
                        column: x => x.id_picture,
                        principalTable: "inspection_picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_course_lane",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    direction = table.Column<int>(nullable: false),
                    id_building_course = table.Column<Guid>(nullable: false),
                    id_lane = table.Column<Guid>(nullable: false),
                    sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_course_lane", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_course_lane_inspection_building_course_~",
                        column: x => x.id_building_course,
                        principalTable: "inspection_building_course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_course_lane_lane_lane_id",
                        column: x => x.id_lane,
                        principalTable: "lane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_particular_risk_picture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    id_building_particular_risk = table.Column<Guid>(nullable: false),
                    id_picture = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_particular_risk_picture", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_particular_risk_picture_inspection_buil~",
                        column: x => x.id_building_particular_risk,
                        principalTable: "inspection_building_particular_risk",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inspection_building_particular_risk_picture_inspection_pictu~",
                        column: x => x.id_picture,
                        principalTable: "inspection_picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "alarm_panel_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ff"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721802"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721805"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721808"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "building_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721799"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "city_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721958"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721975"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "construction_fire_resistance_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721796"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721790"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721793"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "construction_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721784"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721787"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721781"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721778"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721775"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721772"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72176b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72176f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "id", "code_alpha2", "code_alpha3", "created_on", "is_active" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db721957"), "CA", "CAD", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "fire_hydrant_connection_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721835"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721838"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721844"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721841"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721847"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "lane_generic_code",
                columns: new[] { "id", "add_white_space_after", "code", "description", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ac"), true, "F", "AUX", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a7"), false, "A", "", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a8"), true, "B", "À", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a9"), false, "C", "À L'", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218aa"), true, "D", "À LA", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ab"), true, "E", "AU", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ad"), true, "G", "CHEZ", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b7"), true, "Q", "LES", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218af"), true, "I", "DE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b0"), false, "J", "DE L'", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b1"), true, "K", "DE LA", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b2"), true, "L", "DES", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b3"), true, "M", "DU", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b4"), false, "N", "L'", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b5"), true, "O", "LA", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b6"), true, "P", "LE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b8"), true, "R", "THE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ae"), false, "H", "D'", true }
                });

            migrationBuilder.InsertData(
                table: "lane_public_code",
                columns: new[] { "id", "abbreviation", "code", "description", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d2"), "", "41", "FIEF", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d1"), "", "40", "ESPLANADE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d0"), "", "3a", "ALLEY", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c7"), "", "25", "COURS", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c8"), "", "26", "COURT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c9"), "", "29", "CRESCENT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ce"), "", "38", "DRIVE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218cb"), "", "34", "DESCENTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218cc"), "", "35", "DESSERTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218cd"), "DO", "36", "DOMAINE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218cf"), "", "39", "ÉCHANGEUR", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d3"), "", "44", "GARDEN", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ca"), "CR", "32", "CROISSANT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d4"), "", "45", "GARDENS", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218df"), "", "58", "PASSERELLE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d6"), "", "47", "ILE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ee"), "", "73", "PETIT RANG", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ef"), "", "74", "ROAD", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f0"), "", "75", "ROND-POINT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f1"), "", "76", "GRAND RANG", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f2"), "RT", "77", "ROUTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f3"), "", "78", "ROUTE RURALE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f4"), "", "79", "RIVIÈRE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f5"), "RU", "80", "RUE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f6"), "RL", "83", "RUELLE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f7"), "SN", "85", "SENTIER", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f8"), "", "86", "SQUARE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218f9"), "TE", "89", "TERRASSE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218fa"), "", "91", "TRAVERSE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218fb"), "", "92", "TRAIT-CARRÉ", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218fc"), "", "93", "TUNNEL", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218fd"), "", "94", "VIADUC", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218fe"), "", "95", "VOIE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ff"), "", "96", "RUISSEAU", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721900"), "", "97", "ÎLOT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ed"), "", "72", "RIDGE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d5"), "", "46", "HILL", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ec"), "RG", "71", "RANG", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ea"), "PR", "69", "PROMENADE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d7"), "", "4a", "ANSE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d8"), "", "50", "IMPASSE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218d9"), "", "52", "JARDIN", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218da"), "", "53", "LANE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218db"), "LA", "54", "LAC", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218dc"), "", "55", "LIGNE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218dd"), "MT", "56", "MONTÉE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218de"), "", "57", "PARK", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c6"), "CT", "23", "COTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e0"), "", "59", "PARC", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e1"), "", "60", "PISTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e2"), "", "61", "PASSAGE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e3"), "PL", "62", "PLACE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e4"), "", "63", "PLAGE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e5"), "", "64", "PLAZA", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e6"), "", "65", "PONT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e7"), "", "66", "PLATEAU", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e8"), "", "67", "PORTAGE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218e9"), "", "68", "RAMPE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218eb"), "", "70", "QUAI", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c5"), "", "22", "CONCESSION", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218b9"), "", "01", "", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c3"), "", "20", "CERCLE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c4"), "", "21", "CIRCUIT", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218ba"), "AL", "02", "ALLÉE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218bc"), "AV", "08", "AVENUE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218bd"), "BD", "11", "BOULEVARD", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218bb"), "AU", "05", "AUTOROUTE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218bf"), "", "15", "CARREFOUR", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c0"), "", "16", "CHAUSSÉE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c1"), "CH", "17", "CHEMIN", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218c2"), "", "19", "CIRCLE", true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218be"), "CA", "14", "CARRÉ", true }
                });

            migrationBuilder.InsertData(
                table: "permission_system",
                columns: new[] { "id", "description" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), "SURVI-Prevention" });

            migrationBuilder.InsertData(
                table: "person_requiring_assistance_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721826"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721832"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721829"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721823"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721814"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721817"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721811"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721820"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "risk_level",
                columns: new[] { "id", "code", "color", "created_on", "is_active", "sequence" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721951"), 4, "-65536", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194b"), 2, "-256", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194e"), 3, "-23296", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721954"), 0, "-16777216", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721948"), 1, "-16744448", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 }
                });

            migrationBuilder.InsertData(
                table: "roof_material_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217cc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "roof_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217bd"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ba"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ab"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ae"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "siding_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ea"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217de"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217db"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217cf"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "sprinkler_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217fc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ed"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "unit_of_measure",
                columns: new[] { "id", "abbreviation", "created_on", "is_active", "measure_type" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721889"), "sh tn", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721880"), "ml", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187d"), "po3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721883"), "pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721886"), "t", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188c"), "pi3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189b"), "Kg", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721892"), "", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721895"), "G", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721898"), "g", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189e"), "L", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187a"), "m3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188f"), "GI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721877"), "pi", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a1"), "lb", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721871"), "po", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186e"), "mm", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186b"), "m3/h", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721868"), "KPA", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721865"), "PSI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721862"), "", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185f"), "L", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185c"), "G", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721859"), "GI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721856"), "LPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721853"), "GPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721850"), "GIPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721874"), "m", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a4"), "oz", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 }
                });

            migrationBuilder.InsertData(
                table: "webuser",
                columns: new[] { "id", "created_on", "is_active", "password", "username" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db72176c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247", "admin" });

            migrationBuilder.InsertData(
                table: "alarm_panel_type_localization",
                columns: new[] { "id", "created_on", "id_alarm_panel_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721800"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ff"), true, "fr", "Intrusion" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721801"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ff"), true, "en", "Intrusion" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721803"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721802"), true, "fr", "Non zoné" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721804"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721802"), true, "en", "Not zoned" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721806"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721805"), true, "fr", "Zoné" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721807"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721805"), true, "en", "Zoned" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721809"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721808"), true, "fr", "Adressable" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721808"), true, "en", "Adressable" }
                });

            migrationBuilder.InsertData(
                table: "building_type_localization",
                columns: new[] { "id", "created_on", "id_building_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a2"), true, "en", "Other" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a2"), true, "fr", "Autre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72179f"), true, "en", "Semi-detached" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72179f"), true, "fr", "Jumelé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72179c"), true, "en", "Detached" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72179c"), true, "fr", "Détaché" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721799"), true, "en", "Attached" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72179a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721799"), true, "fr", "Attaché" }
                });

            migrationBuilder.InsertData(
                table: "city_type_localization",
                columns: new[] { "id", "created_on", "id_city_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721977"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721975"), true, "en", "Municipality" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721976"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721975"), true, "fr", "Municipalité" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721974"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721958"), true, "en", "City" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721973"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721958"), true, "fr", "Ville" }
                });

            migrationBuilder.InsertData(
                table: "construction_fire_resistance_type_localization",
                columns: new[] { "id", "created_on", "id_parent", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721798"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721796"), true, "en", "Hybrid" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721797"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721796"), true, "fr", "Hybride" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721795"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721793"), true, "en", "Fire resistant" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72178d"), true, "fr", "Combustible" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721792"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721790"), true, "en", "Nonflammable" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721791"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721790"), true, "fr", "Incombustible" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72178d"), true, "en", "Flammable" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72178a"), true, "en", "Regular" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72178b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72178a"), true, "fr", "Ordinaire" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721794"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721793"), true, "fr", "Résistante au feu" }
                });

            migrationBuilder.InsertData(
                table: "construction_type_localization",
                columns: new[] { "id", "created_on", "id_construction_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721780"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72177e"), true, "en", "Steel with unprotected steel joists" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721789"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721787"), true, "en", "Undetermined" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721788"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721787"), true, "fr", "Indéterminé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721786"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721784"), true, "en", "Other" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721785"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721784"), true, "fr", "Autre type" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721783"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721781"), true, "en", "Concrete" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72177e"), true, "fr", "Acier avec solives en acier non protégées" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721782"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721781"), true, "fr", "Béton" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72177b"), true, "fr", "Acier avec solives en acier protégées" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72177b"), true, "en", "Steel with protected steel joists" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721771"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72176f"), true, "en", "Lumber" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721770"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72176f"), true, "fr", "Gros bois d'oeuvre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721773"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721772"), true, "fr", "Mur porteur en maçonnerie avec mur solives en bois solides" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721774"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721772"), true, "en", "Masonry bearing wall and solid wood joists" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72176e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72176b"), true, "en", "Wood frame and prefabricated joists" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721777"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721775"), true, "en", "Masonry bearing wall and prefabricated joists" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721779"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721778"), true, "fr", "Mur porteur en maçonnerie et solives en aciers ou dalle de béton" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72176d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72176b"), true, "fr", "Ossature de bois avec solives préfabriquées" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72177a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721778"), true, "en", "Masonry bearing wall and steel joists or concrete slab" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721776"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721775"), true, "fr", "Mur porteur en maçonnerie et solives préfabriquées" }
                });

            migrationBuilder.InsertData(
                table: "country_localization",
                columns: new[] { "id", "created_on", "id_country", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72195b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721957"), true, "fr", "Canada" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72195c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721957"), true, "en", "Canada" }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_connection_type_localization",
                columns: new[] { "id", "created_on", "id_fire_hydrant_connection_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721837"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721835"), true, "en", "Threaded" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721839"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721838"), true, "fr", "Storz" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721836"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721835"), true, "fr", "Fileté" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721838"), true, "en", "Storz" }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_type_localization",
                columns: new[] { "id", "created_on", "id_fire_hydrant_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721843"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721841"), true, "en", "Tank" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721846"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721844"), true, "en", "Fire hydrant" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721848"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721847"), true, "fr", "Point d'eau" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721849"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721847"), true, "en", "Water point" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72183b"), true, "fr", "Sèche" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72183b"), true, "en", "Dry" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72183f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72183e"), true, "fr", "Fontaine" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721840"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72183e"), true, "en", "Fountain" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721842"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721841"), true, "fr", "Citerne" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72184a"), true, "fr", "Borne sèche" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72184a"), true, "en", "Dry fire hydrant" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72184d"), true, "fr", "Statique" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72184f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72184d"), true, "en", "Static" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721845"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721844"), true, "fr", "Borne fontaine" }
                });

            migrationBuilder.InsertData(
                table: "permission_object",
                columns: new[] { "id", "generic_id", "group_name", "id_permission_object_parent", "id_permission_system", "is_group", "object_table" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), "", "Pompier", null, new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), true, "group" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), "", "Administration", null, new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), true, "group" }
                });

            migrationBuilder.InsertData(
                table: "permission_system_feature",
                columns: new[] { "id", "default_value", "description", "feature_name", "id_permission_system" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721920"), false, "Gestion des codes d'utilisation", "RightUtilisationCodeManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721922"), false, "Gestion des matières dangereuses", "RightHazardousMaterialManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721921"), false, "Gestion des types de PNAPs", "RightRPATypeManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191a"), false, "Gestion des régions", "RightRegionManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191f"), false, "Gestion des niveaux de risque", "RightRiskLevelManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191e"), false, "Gestion des villes", "RightCityManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191d"), false, "Gestion des types de ville", "RightCityTypeManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191c"), false, "Gestion des pays", "RightCountryManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721923"), false, "Gestion des niveaux de risque par SSI", "RightDepartmentRiskLevel", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72191b"), false, "Gestion des provinces/états", "RightStateManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721911"), false, "Gestion des voies", "RightLaneManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721905"), true, "Accès au tableau de bord", "url-inspection-dashboard", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721916"), false, "Gestion des types de connexion", "RightConnectionTypeManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721915"), false, "Gestion des types de borne", "RightFireHydrantTypeManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721914"), false, "Gestion des utilisateurs", "RightUserManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721913"), false, "Gestion des permissions", "RightPermissionManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721912"), false, "Gestion des bâtiments", "RightBuildingManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721924"), false, "Gestion des SSI", "RightDepartmentManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721910"), false, "Gestion des casernes", "RightFireStationManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190f"), false, "Gestion des lots", "RightBatchManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190e"), false, "Acception des inspections", "RightApproveInspection", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190d"), true, "Accès au mobile", "RightMobile", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190c"), false, "Accès à la gestion du SSI", "url-management-department", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190b"), false, "Accès à la gestion des villes", "url-management-address", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72190a"), false, "Accès à la gestion des questionnaires", "url-management-survey", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721909"), false, "Accès à la gestion des types du système", "url-management-typesystem", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721908"), false, "Accès à la gestion système", "url-management-system", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721907"), false, "Accès à la gestion des rapports", "url-report-configuration", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721906"), false, "Accès aux statistiques", "url-statistics", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721919"), false, "Gestion des comtés", "RightCountyManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721925"), false, "Gestion des bornes", "RightFireHydrantManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721918"), false, "Gestion des unités de mesure", "RightUnitManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721917"), false, "Gestion des opérateurs", "RightOperatorManagement", new Guid("f13400a9-70b8-4325-b732-7fe7db721904") }
                });

            migrationBuilder.InsertData(
                table: "person_requiring_assistance_type_localization",
                columns: new[] { "id", "created_on", "id_person_requiring_assistance_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72182c"), true, "en", "Reduced mobility" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721834"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721832"), true, "en", "Elderly" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721833"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721832"), true, "fr", "Personnes agées" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721831"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72182f"), true, "en", "Blind" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721830"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72182f"), true, "fr", "Non-voyants" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72182c"), true, "fr", "Mobilité réduite" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721829"), true, "en", "Hard of hearing" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72182a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721829"), true, "fr", "Malentendants" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721828"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721826"), true, "en", "Nursery" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721827"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721826"), true, "fr", "Garderie" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721825"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721823"), true, "en", "School" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721824"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721823"), true, "fr", "École" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721821"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721820"), true, "fr", "Déficients intellectuels" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721822"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721820"), true, "en", "Intellectual deficient" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72181d"), true, "fr", "Centre médical" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72180b"), true, "fr", "Camp/Terrain de jeu" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72180b"), true, "en", "Camp/playground" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72180f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72180e"), true, "fr", "Personnes handicapées" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721810"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72180e"), true, "en", "Handicapped person" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721812"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721811"), true, "fr", "Trouble vision" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72181d"), true, "en", "Medical center" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721813"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721811"), true, "en", "Visually impaired" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721816"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721814"), true, "en", "Deafness" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721818"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721817"), true, "fr", "Cognitif" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721819"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721817"), true, "en", "Cognitive" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72181a"), true, "fr", "Autre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72181c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72181a"), true, "en", "Other" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721815"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721814"), true, "fr", "Surdité" }
                });

            migrationBuilder.InsertData(
                table: "risk_level_localization",
                columns: new[] { "id", "created_on", "id_risk_level", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721953"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721951"), true, "en", "Very high" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721952"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721951"), true, "fr", "Très élevé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721950"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72194e"), true, "en", "High" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72194e"), true, "fr", "Élevé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721955"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721954"), true, "fr", "Indéterminé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72194b"), true, "fr", "Moyen" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721948"), true, "en", "Low" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721949"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721948"), true, "fr", "Faible" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721956"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721954"), true, "en", "Unknown" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72194d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72194b"), true, "en", "Medium" }
                });

            migrationBuilder.InsertData(
                table: "roof_material_type_localization",
                columns: new[] { "id", "created_on", "id_roof_material_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ce"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217cc"), true, "en", "Wood" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217cd"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217cc"), true, "fr", "Bois" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217cb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c9"), true, "en", "Skylight" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ca"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c9"), true, "fr", "Puit de lumière" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c6"), true, "en", "Tar mat" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c6"), true, "fr", "Tapis de goudron" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c3"), true, "fr", "Tôle" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c0"), true, "en", "Asphalt shingles" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c0"), true, "fr", "Bardeaux d'asphalte" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217c5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217c3"), true, "en", "Sheet metal" }
                });

            migrationBuilder.InsertData(
                table: "roof_type_localization",
                columns: new[] { "id", "created_on", "id_roof_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b4"), true, "fr", "Dôme" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a5"), true, "fr", "1 versant" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b4"), true, "en", "Dome" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b7"), true, "fr", "Mansarde" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b7"), true, "en", "Mansard" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217bb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ba"), true, "fr", "Pente" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217bc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ba"), true, "en", "Slope" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217be"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217bd"), true, "fr", "Plat" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217bf"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217bd"), true, "en", "Flat" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b1"), true, "en", "Diamond" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a5"), true, "en", "1 slope" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217a9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a8"), true, "fr", "2 versants" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217aa"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217a8"), true, "en", "2 slopes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ac"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ab"), true, "fr", "4 versants" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ad"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ab"), true, "en", "3 slopes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217af"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ae"), true, "fr", "Cône français" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ae"), true, "en", "French cone" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217b2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217b1"), true, "fr", "Diamant" }
                });

            migrationBuilder.InsertData(
                table: "siding_type_localization",
                columns: new[] { "id", "created_on", "id_siding_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e7"), true, "en", "Cedar shingles" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217cf"), true, "fr", "Brique" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217cf"), true, "en", "Brick" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d2"), true, "fr", "Béton" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d2"), true, "en", "Concrete" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217eb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ea"), true, "fr", "Masonite" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d5"), true, "fr", "Vinyle" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d8"), true, "fr", "Bois" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217da"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d8"), true, "en", "Wood" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217dc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217db"), true, "fr", "Canexel" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ec"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ea"), true, "en", "Masonite" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217df"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217de"), true, "fr", "Pierre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217de"), true, "en", "Stone" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e1"), true, "fr", "Stucco" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e1"), true, "en", "Stucco" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e4"), true, "fr", "Tôle" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e4"), true, "en", "Sheet metal" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217e8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217e7"), true, "fr", "Bardeaux de cèdre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217d7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217d5"), true, "en", "Vinyl" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217dd"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217db"), true, "en", "Canexel" }
                });

            migrationBuilder.InsertData(
                table: "sprinkler_type_localization",
                columns: new[] { "id", "created_on", "id_sprinkler_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ee"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ed"), true, "fr", "Système sous eau" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217fe"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217fc"), true, "en", "FM 200" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217ef"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217ed"), true, "en", "Wet pipe" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f0"), true, "fr", "Système sous air" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f3"), true, "fr", "Pré action" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f3"), true, "en", "Pre-Action" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f0"), true, "en", "Dry pipe" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f6"), true, "en", "Deluge" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217fa"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f9"), true, "fr", "Mousse" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217fb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f9"), true, "en", "Foam" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217fd"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217fc"), true, "fr", "FM 200" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7217f7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7217f6"), true, "fr", "Déluge" }
                });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "id", "ansi_code", "created_on", "id_country", "is_active" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), "QC", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721957"), true });

            migrationBuilder.InsertData(
                table: "unit_of_measure_localization",
                columns: new[] { "id", "created_on", "id_parent", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721887"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721886"), true, "fr", "Tonnes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721889"), true, "en", "US tons" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721889"), true, "fr", "Tonnes US" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721888"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721886"), true, "en", "Tons" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721885"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721883"), true, "en", "Pints" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72187d"), true, "fr", "Pouces cubes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721882"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721880"), true, "en", "Millilitre" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721881"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721880"), true, "fr", "Millilitres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72187d"), true, "en", "Cubic inches" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72188c"), true, "fr", "Pieds cubes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72187a"), true, "en", "Cubic meters" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721884"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721883"), true, "fr", "Pintes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72188e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72188c"), true, "en", "Cubic feet" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721896"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721895"), true, "fr", "Gallons US" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721891"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72188f"), true, "en", "Imperial gallons" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721893"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721892"), true, "fr", "Aucune" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721894"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721892"), true, "en", "None" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72187b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72187a"), true, "fr", "Mètres cubes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721897"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721895"), true, "en", "US gallons" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721899"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721898"), true, "fr", "Grammes" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721898"), true, "en", "Grams" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72189b"), true, "fr", "Kilos" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72189b"), true, "en", "Kilos" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72189f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72189e"), true, "fr", "Litres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72189e"), true, "en", "Litres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7218a1"), true, "fr", "Livres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7218a1"), true, "en", "Pounds" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721890"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72188f"), true, "fr", "Gallons impériaux" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721879"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721877"), true, "en", "Feet" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721870"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72186e"), true, "en", "Millimeters" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721876"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721874"), true, "en", "Meters" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7218a4"), true, "fr", "Onces" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721851"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721850"), true, "fr", "GIPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721852"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721850"), true, "en", "GIPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721854"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721853"), true, "fr", "GPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721855"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721853"), true, "en", "GPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721857"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721856"), true, "fr", "LPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721858"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721856"), true, "en", "LPM" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721859"), true, "fr", "GI" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721859"), true, "en", "GI" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72185c"), true, "fr", "G" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721878"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721877"), true, "fr", "Pieds" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721860"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72185f"), true, "fr", "L" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72185e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72185c"), true, "en", "G" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721863"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721862"), true, "fr", "Indéterminé" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721875"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721874"), true, "fr", "Mètres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721873"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721871"), true, "en", "Inches" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721872"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721871"), true, "fr", "Pouces" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721861"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72185f"), true, "en", "L" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72186b"), true, "en", "m3/h" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72186e"), true, "fr", "Millimètres" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721868"), true, "en", "KPA" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721869"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721868"), true, "fr", "KPA" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721867"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721865"), true, "en", "PSI" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721866"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721865"), true, "fr", "PSI" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721864"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721862"), true, "en", "Unknown" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72186c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72186b"), true, "fr", "m3/h" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db7218a6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db7218a4"), true, "en", "Onces" }
                });

            migrationBuilder.InsertData(
                table: "webuser_attributes",
                columns: new[] { "id", "attribute_name", "attribute_value", "id_webuser" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721903"), "first_name", "Admin", new Guid("f13400a9-70b8-4325-b732-7fe7db72176c") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721902"), "reset_password", "false", new Guid("f13400a9-70b8-4325-b732-7fe7db72176c") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721901"), "last_name", "Cauca", new Guid("f13400a9-70b8-4325-b732-7fe7db72176c") }
                });

            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "id", "access", "comments", "created_on", "id_permission_object", "id_permission_system", "id_permission_system_feature" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721936"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721914") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721938"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721916") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721939"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721917") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193a"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721918") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193b"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721919") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193c"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191a") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193d"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191b") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721937"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721915") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193e"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191c") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721940"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191e") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721941"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191f") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721942"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721920") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721943"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721921") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721944"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721922") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721945"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721923") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72193f"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72191d") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721946"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721924") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721947"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721925") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721934"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721912") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721929"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721906") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192a"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721907") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192b"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721908") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721935"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721913") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192d"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72190a") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192c"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721909") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192f"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72190c") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721930"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72190e") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721931"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72190f") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721932"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721910") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721933"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db721911") },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72192e"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721927"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), new Guid("f13400a9-70b8-4325-b732-7fe7db72190b") }
                });

            migrationBuilder.InsertData(
                table: "permission_object",
                columns: new[] { "id", "generic_id", "group_name", "id_permission_object_parent", "id_permission_system", "is_group", "object_table" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db721928"), "f13400a9-70b8-4325-b732-7fe7db72176c", "", new Guid("f13400a9-70b8-4325-b732-7fe7db721926"), new Guid("f13400a9-70b8-4325-b732-7fe7db721904"), false, "webuser" });

            migrationBuilder.InsertData(
                table: "region",
                columns: new[] { "id", "code", "created_on", "id_state", "is_active" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db72195f"), "12", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), true });

            migrationBuilder.InsertData(
                table: "state_localization",
                columns: new[] { "id", "created_on", "id_state", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72195e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), true, "en", "Quebec" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72195d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), true, "fr", "Québec" }
                });

            migrationBuilder.InsertData(
                table: "county",
                columns: new[] { "id", "created_on", "id_region", "id_state", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195f"), new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), true },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721963"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195f"), new Guid("f13400a9-70b8-4325-b732-7fe7db721959"), true }
                });

            migrationBuilder.InsertData(
                table: "region_localization",
                columns: new[] { "id", "created_on", "id_region", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721960"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195f"), true, "fr", "Chaudière-Appalaches" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721961"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195f"), true, "en", "Chaudière-Appalaches" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "id", "code", "code3_letters", "created_on", "email_address", "id_city_type", "id_county", "is_active" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721964"), "29045", "SIN", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f13400a9-70b8-4325-b732-7fe7db721958"), new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), true },
                    { new Guid("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5"), "29073", "SGS", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("f13400a9-70b8-4325-b732-7fe7db721958"), new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), true }
                });

            migrationBuilder.InsertData(
                table: "county_localization",
                columns: new[] { "id", "created_on", "id_county", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), true, "fr", "Beauce-Sartigan" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), true, "en", "Beauce-Sartigan" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721963"), true, "fr", "La Nouvelle-Beauce" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721963"), true, "en", "The New-Beauce" }
                });

            migrationBuilder.InsertData(
                table: "fire_safety_department",
                columns: new[] { "id", "created_on", "id_county", "is_active", "language" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721962"), true, "fr" });

            migrationBuilder.InsertData(
                table: "city_localization",
                columns: new[] { "id", "created_on", "id_city", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721965"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721964"), true, "fr", "Causeville" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721966"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db721964"), true, "en", "Causetown" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721967"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5"), true, "fr", "Caucaville" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721968"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5"), true, "en", "Caucatown" }
                });

            migrationBuilder.InsertData(
                table: "fire_safety_department_city_serving",
                columns: new[] { "id", "created_on", "id_city", "id_fire_safety_department", "is_active" },
                values: new object[] { new Guid("f13400a9-70b8-4325-b732-7fe7db721969"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5"), new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true });

            migrationBuilder.InsertData(
                table: "fire_safety_department_localization",
                columns: new[] { "id", "created_on", "id_fire_hydrant_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true, "fr", "Cauca SSI" },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db72196f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true, "en", "Cauca SSI" }
                });

            migrationBuilder.InsertData(
                table: "firestation",
                columns: new[] { "id", "created_on", "email", "fax_number", "id_building", "id_fire_safety_department", "is_active", "name", "phone_number" },
                values: new object[,]
                {
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721970"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true, "Caserne 1", null },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721971"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true, "Caserne 2", null },
                    { new Guid("f13400a9-70b8-4325-b732-7fe7db721972"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("f13400a9-70b8-4325-b732-7fe7db72195a"), true, "Caserne 3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_access_token_id_webuser",
                table: "access_token",
                column: "id_webuser");

            migrationBuilder.CreateIndex(
                name: "IX_alarm_panel_type_localization_id_alarm_panel_type",
                table: "alarm_panel_type_localization",
                column: "id_alarm_panel_type");

            migrationBuilder.CreateIndex(
                name: "IX_batch_id_webuser_created_by",
                table: "batch",
                column: "id_webuser_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_batch_user_id_batch",
                table: "batch_user",
                column: "id_batch");

            migrationBuilder.CreateIndex(
                name: "IX_batch_user_id_webuser",
                table: "batch_user",
                column: "id_webuser");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_city",
                table: "building",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_lane",
                table: "building",
                column: "id_lane");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_lane_transversal",
                table: "building",
                column: "id_lane_transversal");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_parent_building",
                table: "building",
                column: "id_parent_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_picture",
                table: "building",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_risk_level",
                table: "building",
                column: "id_risk_level");

            migrationBuilder.CreateIndex(
                name: "IX_building_id_utilisation_code",
                table: "building",
                column: "id_utilisation_code");

            migrationBuilder.CreateIndex(
                name: "IX_building_alarm_panel_id_alarm_panel_type",
                table: "building_alarm_panel",
                column: "id_alarm_panel_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_alarm_panel_id_building",
                table: "building_alarm_panel",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_anomaly_id_building",
                table: "building_anomaly",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_anomaly_picture_id_building_anomaly",
                table: "building_anomaly_picture",
                column: "id_building_anomaly");

            migrationBuilder.CreateIndex(
                name: "IX_building_anomaly_picture_id_picture",
                table: "building_anomaly_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_building_contact_id_building",
                table: "building_contact",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_course_id_building",
                table: "building_course",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_course_id_firestation",
                table: "building_course",
                column: "id_firestation");

            migrationBuilder.CreateIndex(
                name: "IX_building_course_lane_id_building_course",
                table: "building_course_lane",
                column: "id_building_course");

            migrationBuilder.CreateIndex(
                name: "IX_building_course_lane_id_lane",
                table: "building_course_lane",
                column: "id_lane");

            migrationBuilder.CreateIndex(
                name: "ix_building_detail_fire_resistance_type_id",
                table: "building_detail",
                column: "fire_resistance_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_building",
                table: "building_detail",
                column: "id_building",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_building_siding_type",
                table: "building_detail",
                column: "id_building_siding_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_building_type",
                table: "building_detail",
                column: "id_building_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_construction_type",
                table: "building_detail",
                column: "id_construction_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_picture_plan",
                table: "building_detail",
                column: "id_picture_plan");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_roof_material_type",
                table: "building_detail",
                column: "id_roof_material_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_roof_type",
                table: "building_detail",
                column: "id_roof_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_unit_of_measure_estimated_water_flow",
                table: "building_detail",
                column: "id_unit_of_measure_estimated_water_flow");

            migrationBuilder.CreateIndex(
                name: "IX_building_detail_id_unit_of_measure_height",
                table: "building_detail",
                column: "id_unit_of_measure_height");

            migrationBuilder.CreateIndex(
                name: "IX_building_fire_hydrant_id_building",
                table: "building_fire_hydrant",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_fire_hydrant_id_fire_hydrant",
                table: "building_fire_hydrant",
                column: "id_fire_hydrant");

            migrationBuilder.CreateIndex(
                name: "IX_building_hazardous_material_id_building",
                table: "building_hazardous_material",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_hazardous_material_id_hazardous_material",
                table: "building_hazardous_material",
                column: "id_hazardous_material");

            migrationBuilder.CreateIndex(
                name: "IX_building_hazardous_material_id_unit_of_measure",
                table: "building_hazardous_material",
                column: "id_unit_of_measure");

            migrationBuilder.CreateIndex(
                name: "IX_building_localization_id_building",
                table: "building_localization",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_particular_risk_id_building",
                table: "building_particular_risk",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_particular_risk_picture_id_building_particular_risk",
                table: "building_particular_risk_picture",
                column: "id_building_particular_risk");

            migrationBuilder.CreateIndex(
                name: "IX_building_particular_risk_picture_id_picture",
                table: "building_particular_risk_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_building_person_requiring_assistance_id_building",
                table: "building_person_requiring_assistance",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_person_requiring_assistance_id_person_requiring_as~",
                table: "building_person_requiring_assistance",
                column: "id_person_requiring_assistance_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_sprinkler_id_building",
                table: "building_sprinkler",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_building_sprinkler_id_sprinkler_type",
                table: "building_sprinkler",
                column: "id_sprinkler_type");

            migrationBuilder.CreateIndex(
                name: "IX_building_type_localization_id_building_type",
                table: "building_type_localization",
                column: "id_building_type");

            migrationBuilder.CreateIndex(
                name: "IX_city_id_city_type",
                table: "city",
                column: "id_city_type");

            migrationBuilder.CreateIndex(
                name: "IX_city_id_county",
                table: "city",
                column: "id_county");

            migrationBuilder.CreateIndex(
                name: "IX_city_localization_id_city",
                table: "city_localization",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_city_type_localization_id_city_type",
                table: "city_type_localization",
                column: "id_city_type");

            migrationBuilder.CreateIndex(
                name: "IX_construction_fire_resistance_type_localization_id_parent",
                table: "construction_fire_resistance_type_localization",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "IX_construction_type_localization_id_construction_type",
                table: "construction_type_localization",
                column: "id_construction_type");

            migrationBuilder.CreateIndex(
                name: "IX_country_localization_id_country",
                table: "country_localization",
                column: "id_country");

            migrationBuilder.CreateIndex(
                name: "IX_county_id_region",
                table: "county",
                column: "id_region");

            migrationBuilder.CreateIndex(
                name: "IX_county_id_state",
                table: "county",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_county_localization_id_county",
                table: "county_localization",
                column: "id_county");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_city",
                table: "fire_hydrant",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_fire_hydrant_type",
                table: "fire_hydrant",
                column: "id_fire_hydrant_type");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_intersection",
                table: "fire_hydrant",
                column: "id_intersection");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_lane",
                table: "fire_hydrant",
                column: "id_lane");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_unit_of_measure_pressure",
                table: "fire_hydrant",
                column: "id_unit_of_measure_pressure");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_id_unit_of_measure_rate",
                table: "fire_hydrant",
                column: "id_unit_of_measure_rate");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_id_fire_hydrant",
                table: "fire_hydrant_connection",
                column: "id_fire_hydrant");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_id_fire_hydrant_connection_type",
                table: "fire_hydrant_connection",
                column: "id_fire_hydrant_connection_type");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_id_unit_of_measure_diameter",
                table: "fire_hydrant_connection",
                column: "id_unit_of_measure_diameter");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_connection_type_localization_id_fire_hydrant_c~",
                table: "fire_hydrant_connection_type_localization",
                column: "id_fire_hydrant_connection_type");

            migrationBuilder.CreateIndex(
                name: "IX_fire_hydrant_type_localization_id_fire_hydrant_type",
                table: "fire_hydrant_type_localization",
                column: "id_fire_hydrant_type");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_id_county",
                table: "fire_safety_department",
                column: "id_county");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_city_serving_id_city",
                table: "fire_safety_department_city_serving",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_city_serving_id_fire_safety_departme~",
                table: "fire_safety_department_city_serving",
                column: "id_fire_safety_department");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_localization_id_fire_hydrant_type",
                table: "fire_safety_department_localization",
                column: "id_fire_hydrant_type");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_risk_level_id_risk_level",
                table: "fire_safety_department_risk_level",
                column: "id_risk_level");

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_risk_level_id_survey",
                table: "fire_safety_department_risk_level",
                column: "id_survey");

            migrationBuilder.CreateIndex(
                name: "IX_firestation_id_building",
                table: "firestation",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_firestation_id_fire_safety_department",
                table: "firestation",
                column: "id_fire_safety_department");

            migrationBuilder.CreateIndex(
                name: "IX_hazardous_material_localization_id_hazardous_material_is_ac~",
                table: "hazardous_material_localization",
                columns: new[] { "id_hazardous_material", "is_active", "language_code" });

            migrationBuilder.CreateIndex(
                name: "IX_inspection_id_batch",
                table: "inspection",
                column: "id_batch");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_id_building",
                table: "inspection",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_id_survey",
                table: "inspection",
                column: "id_survey");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_id_webuser_assigned_to",
                table: "inspection",
                column: "id_webuser_assigned_to");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_id_webuser_created_by",
                table: "inspection",
                column: "id_webuser_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_city",
                table: "inspection_building",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_inspection",
                table: "inspection_building",
                column: "id_inspection");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_lane",
                table: "inspection_building",
                column: "id_lane");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_lane_transversal",
                table: "inspection_building",
                column: "id_lane_transversal");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_parent_building",
                table: "inspection_building",
                column: "id_parent_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_picture",
                table: "inspection_building",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_risk_level",
                table: "inspection_building",
                column: "id_risk_level");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_id_utilisation_code",
                table: "inspection_building",
                column: "id_utilisation_code");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_alarm_panel_id_alarm_panel_type",
                table: "inspection_building_alarm_panel",
                column: "id_alarm_panel_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_alarm_panel_id_building",
                table: "inspection_building_alarm_panel",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_anomaly_id_building",
                table: "inspection_building_anomaly",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_anomaly_picture_id_building_anomaly",
                table: "inspection_building_anomaly_picture",
                column: "id_building_anomaly");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_anomaly_picture_id_picture",
                table: "inspection_building_anomaly_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_contact_id_building",
                table: "inspection_building_contact",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_id_building",
                table: "inspection_building_course",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_id_firestation",
                table: "inspection_building_course",
                column: "id_firestation");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_lane_id_building_course",
                table: "inspection_building_course_lane",
                column: "id_building_course");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_course_lane_id_lane",
                table: "inspection_building_course_lane",
                column: "id_lane");

            migrationBuilder.CreateIndex(
                name: "ix_inspection_building_detail_fire_resistance_type_id",
                table: "inspection_building_detail",
                column: "fire_resistance_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_building",
                table: "inspection_building_detail",
                column: "id_building",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_building_siding_type",
                table: "inspection_building_detail",
                column: "id_building_siding_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_building_type",
                table: "inspection_building_detail",
                column: "id_building_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_construction_type",
                table: "inspection_building_detail",
                column: "id_construction_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_picture_plan",
                table: "inspection_building_detail",
                column: "id_picture_plan");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_roof_material_type",
                table: "inspection_building_detail",
                column: "id_roof_material_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_roof_type",
                table: "inspection_building_detail",
                column: "id_roof_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_unit_of_measure_estimated_wat~",
                table: "inspection_building_detail",
                column: "id_unit_of_measure_estimated_water_flow");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_detail_id_unit_of_measure_height",
                table: "inspection_building_detail",
                column: "id_unit_of_measure_height");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_fire_hydrant_id_building",
                table: "inspection_building_fire_hydrant",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_fire_hydrant_id_fire_hydrant",
                table: "inspection_building_fire_hydrant",
                column: "id_fire_hydrant");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_hazardous_material_id_building",
                table: "inspection_building_hazardous_material",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_hazardous_material_id_hazardous_material",
                table: "inspection_building_hazardous_material",
                column: "id_hazardous_material");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_hazardous_material_id_unit_of_measure",
                table: "inspection_building_hazardous_material",
                column: "id_unit_of_measure");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_localization_id_building",
                table: "inspection_building_localization",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_particular_risk_id_building",
                table: "inspection_building_particular_risk",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_particular_risk_picture_id_building_par~",
                table: "inspection_building_particular_risk_picture",
                column: "id_building_particular_risk");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_particular_risk_picture_id_picture",
                table: "inspection_building_particular_risk_picture",
                column: "id_picture");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_person_requiring_assistance_id_building",
                table: "inspection_building_person_requiring_assistance",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_person_requiring_assistance_id_person_r~",
                table: "inspection_building_person_requiring_assistance",
                column: "id_person_requiring_assistance_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_sprinkler_id_building",
                table: "inspection_building_sprinkler",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_sprinkler_id_sprinkler_type",
                table: "inspection_building_sprinkler",
                column: "id_sprinkler_type");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_survey_answer_id_inspection",
                table: "inspection_survey_answer",
                column: "id_inspection");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_survey_answer_id_survey_question",
                table: "inspection_survey_answer",
                column: "id_survey_question");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_survey_answer_id_survey_question_choice",
                table: "inspection_survey_answer",
                column: "id_survey_question_choice");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_visit_id_inspection",
                table: "inspection_visit",
                column: "id_inspection");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_visit_id_webuser_visited_by",
                table: "inspection_visit",
                column: "id_webuser_visited_by");

            migrationBuilder.CreateIndex(
                name: "IX_lane_id_city",
                table: "lane",
                column: "id_city");

            migrationBuilder.CreateIndex(
                name: "IX_lane_id_lane_generic_code",
                table: "lane",
                column: "id_lane_generic_code");

            migrationBuilder.CreateIndex(
                name: "IX_lane_id_public_code",
                table: "lane",
                column: "id_public_code");

            migrationBuilder.CreateIndex(
                name: "IX_lane_localization_id_lane",
                table: "lane_localization",
                column: "id_lane");

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
                name: "IX_person_requiring_assistance_type_localization_id_person_req~",
                table: "person_requiring_assistance_type_localization",
                column: "id_person_requiring_assistance_type");

            migrationBuilder.CreateIndex(
                name: "IX_region_id_state",
                table: "region",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_region_localization_id_region",
                table: "region_localization",
                column: "id_region");

            migrationBuilder.CreateIndex(
                name: "IX_risk_level_localization_id_risk_level",
                table: "risk_level_localization",
                column: "id_risk_level");

            migrationBuilder.CreateIndex(
                name: "IX_roof_material_type_localization_id_roof_material_type",
                table: "roof_material_type_localization",
                column: "id_roof_material_type");

            migrationBuilder.CreateIndex(
                name: "IX_roof_type_localization_id_roof_type",
                table: "roof_type_localization",
                column: "id_roof_type");

            migrationBuilder.CreateIndex(
                name: "IX_siding_type_localization_id_siding_type",
                table: "siding_type_localization",
                column: "id_siding_type");

            migrationBuilder.CreateIndex(
                name: "IX_sprinkler_type_localization_id_sprinkler_type",
                table: "sprinkler_type_localization",
                column: "id_sprinkler_type");

            migrationBuilder.CreateIndex(
                name: "IX_state_id_country",
                table: "state",
                column: "id_country");

            migrationBuilder.CreateIndex(
                name: "IX_state_localization_id_state",
                table: "state_localization",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_survey_localization_id_survey",
                table: "survey_localization",
                column: "id_survey");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_id_survey",
                table: "survey_question",
                column: "id_survey");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_id_survey_question_next",
                table: "survey_question",
                column: "id_survey_question_next");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_choice_id_survey_question",
                table: "survey_question_choice",
                column: "id_survey_question");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_choice_id_survey_question_next",
                table: "survey_question_choice",
                column: "id_survey_question_next");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_choice_localization_id_survey_question_choi~",
                table: "survey_question_choice_localization",
                column: "id_survey_question_choice");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_localization_id_survey_question",
                table: "survey_question_localization",
                column: "id_survey_question");

            migrationBuilder.CreateIndex(
                name: "IX_unit_of_measure_localization_id_parent",
                table: "unit_of_measure_localization",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "IX_utilisation_code_localization_id_utilisation_code",
                table: "utilisation_code_localization",
                column: "id_utilisation_code");

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

			migrationBuilder.CreateInitialInspectionViews();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropInitialInspectionViews();
            migrationBuilder.DropTable(
                name: "access_secret_key");

            migrationBuilder.DropTable(
                name: "access_token");

            migrationBuilder.DropTable(
                name: "alarm_panel_type_localization");

            migrationBuilder.DropTable(
                name: "batch_user");

            migrationBuilder.DropTable(
                name: "building_alarm_panel");

            migrationBuilder.DropTable(
                name: "building_anomaly_picture");

            migrationBuilder.DropTable(
                name: "building_contact");

            migrationBuilder.DropTable(
                name: "building_course_lane");

            migrationBuilder.DropTable(
                name: "building_detail");

            migrationBuilder.DropTable(
                name: "building_fire_hydrant");

            migrationBuilder.DropTable(
                name: "building_hazardous_material");

            migrationBuilder.DropTable(
                name: "building_localization");

            migrationBuilder.DropTable(
                name: "building_particular_risk_picture");

            migrationBuilder.DropTable(
                name: "building_person_requiring_assistance");

            migrationBuilder.DropTable(
                name: "building_sprinkler");

            migrationBuilder.DropTable(
                name: "building_type_localization");

            migrationBuilder.DropTable(
                name: "city_localization");

            migrationBuilder.DropTable(
                name: "city_type_localization");

            migrationBuilder.DropTable(
                name: "construction_fire_resistance_type_localization");

            migrationBuilder.DropTable(
                name: "construction_type_localization");

            migrationBuilder.DropTable(
                name: "country_localization");

            migrationBuilder.DropTable(
                name: "county_localization");

            migrationBuilder.DropTable(
                name: "fire_hydrant_connection");

            migrationBuilder.DropTable(
                name: "fire_hydrant_connection_type_localization");

            migrationBuilder.DropTable(
                name: "fire_hydrant_type_localization");

            migrationBuilder.DropTable(
                name: "fire_safety_department_city_serving");

            migrationBuilder.DropTable(
                name: "fire_safety_department_localization");

            migrationBuilder.DropTable(
                name: "fire_safety_department_risk_level");

            migrationBuilder.DropTable(
                name: "hazardous_material_localization");

            migrationBuilder.DropTable(
                name: "inspection_building_alarm_panel");

            migrationBuilder.DropTable(
                name: "inspection_building_anomaly_picture");

            migrationBuilder.DropTable(
                name: "inspection_building_contact");

            migrationBuilder.DropTable(
                name: "inspection_building_course_lane");

            migrationBuilder.DropTable(
                name: "inspection_building_detail");

            migrationBuilder.DropTable(
                name: "inspection_building_fire_hydrant");

            migrationBuilder.DropTable(
                name: "inspection_building_hazardous_material");

            migrationBuilder.DropTable(
                name: "inspection_building_localization");

            migrationBuilder.DropTable(
                name: "inspection_building_particular_risk_picture");

            migrationBuilder.DropTable(
                name: "inspection_building_person_requiring_assistance");

            migrationBuilder.DropTable(
                name: "inspection_building_sprinkler");

            migrationBuilder.DropTable(
                name: "inspection_survey_answer");

            migrationBuilder.DropTable(
                name: "inspection_visit");

            migrationBuilder.DropTable(
                name: "lane_localization");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "person_requiring_assistance_type_localization");

            migrationBuilder.DropTable(
                name: "region_localization");

            migrationBuilder.DropTable(
                name: "report_configuration_template");

            migrationBuilder.DropTable(
                name: "risk_level_localization");

            migrationBuilder.DropTable(
                name: "roof_material_type_localization");

            migrationBuilder.DropTable(
                name: "roof_type_localization");

            migrationBuilder.DropTable(
                name: "siding_type_localization");

            migrationBuilder.DropTable(
                name: "sprinkler_type_localization");

            migrationBuilder.DropTable(
                name: "state_localization");

            migrationBuilder.DropTable(
                name: "survey_localization");

            migrationBuilder.DropTable(
                name: "survey_question_choice_localization");

            migrationBuilder.DropTable(
                name: "survey_question_localization");

            migrationBuilder.DropTable(
                name: "unit_of_measure_localization");

            migrationBuilder.DropTable(
                name: "utilisation_code_localization");

            migrationBuilder.DropTable(
                name: "webuser_attributes");

            migrationBuilder.DropTable(
                name: "webuser_fire_safety_department");

            migrationBuilder.DropTable(
                name: "building_anomaly");

            migrationBuilder.DropTable(
                name: "building_course");

            migrationBuilder.DropTable(
                name: "building_particular_risk");

            migrationBuilder.DropTable(
                name: "fire_hydrant_connection_type");

            migrationBuilder.DropTable(
                name: "alarm_panel_type");

            migrationBuilder.DropTable(
                name: "inspection_building_anomaly");

            migrationBuilder.DropTable(
                name: "inspection_building_course");

            migrationBuilder.DropTable(
                name: "construction_fire_resistance_type");

            migrationBuilder.DropTable(
                name: "building_type");

            migrationBuilder.DropTable(
                name: "construction_type");

            migrationBuilder.DropTable(
                name: "fire_hydrant");

            migrationBuilder.DropTable(
                name: "hazardous_material");

            migrationBuilder.DropTable(
                name: "inspection_building_particular_risk");

            migrationBuilder.DropTable(
                name: "permission_object");

            migrationBuilder.DropTable(
                name: "permission_system_feature");

            migrationBuilder.DropTable(
                name: "person_requiring_assistance_type");

            migrationBuilder.DropTable(
                name: "roof_material_type");

            migrationBuilder.DropTable(
                name: "roof_type");

            migrationBuilder.DropTable(
                name: "siding_type");

            migrationBuilder.DropTable(
                name: "sprinkler_type");

            migrationBuilder.DropTable(
                name: "survey_question_choice");

            migrationBuilder.DropTable(
                name: "firestation");

            migrationBuilder.DropTable(
                name: "fire_hydrant_type");

            migrationBuilder.DropTable(
                name: "unit_of_measure");

            migrationBuilder.DropTable(
                name: "inspection_building");

            migrationBuilder.DropTable(
                name: "permission_system");

            migrationBuilder.DropTable(
                name: "survey_question");

            migrationBuilder.DropTable(
                name: "fire_safety_department");

            migrationBuilder.DropTable(
                name: "inspection");

            migrationBuilder.DropTable(
                name: "inspection_picture");

            migrationBuilder.DropTable(
                name: "batch");

            migrationBuilder.DropTable(
                name: "building");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "webuser");

            migrationBuilder.DropTable(
                name: "lane");

            migrationBuilder.DropTable(
                name: "picture");

            migrationBuilder.DropTable(
                name: "risk_level");

            migrationBuilder.DropTable(
                name: "utilisation_code");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "lane_generic_code");

            migrationBuilder.DropTable(
                name: "lane_public_code");

            migrationBuilder.DropTable(
                name: "city_type");

            migrationBuilder.DropTable(
                name: "county");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
