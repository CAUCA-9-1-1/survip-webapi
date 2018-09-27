using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class InitialVersion : Migration
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
                    rate_from = table.Column<decimal>(nullable: true),
                    rate_to = table.Column<decimal>(nullable: true),
                    pressure_from = table.Column<decimal>(nullable: true),
                    pressure_to = table.Column<decimal>(nullable: true),
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
                    id_building_anomaly = table.Column<Guid>(nullable: false),
                    id_picture = table.Column<Guid>(nullable: false)
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
                    { new Guid("9eaab857-ee8d-456f-aa4c-db54577a78be"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5b79c12a-8bb2-4f2e-99e5-148cabd3e01b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("e2624494-61a9-43e8-8c80-7b951ccf890b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("8df88764-3d85-4c3f-8d0c-bedeca587660"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "building_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("7f64d446-ee04-4be4-8884-d478b2205015"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("56c0186b-9c3f-4f9a-9b31-526505eb2f27"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("2a6ce3e4-41a4-4279-81d7-2302273932e9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("3f39af62-ab3f-4792-a83a-42e1a33bc4e6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "construction_fire_resistance_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("b6d79902-1622-47b2-b44c-391fa2dd35f1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("e4f66e0d-87d5-47f8-a825-e5ea38819d20"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("37b22728-8de2-4f85-ad21-4fa7ba95aaa2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("1bf7bd80-a821-49b7-95c2-c1683ae4d97d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("08271a20-bd18-445e-8ba5-ec89bfd3f042"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "construction_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("80994dae-01a0-4701-be45-7271abe7364f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("87ad142b-119a-4757-9b4c-4281469b3810"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("2543bae8-9f96-4fb9-81d7-fd78fcabec5c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("088798b8-31ef-4644-a735-1091a28d0e75"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("723839fb-0d7f-4f5f-b1c4-dde687ddf416"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("025f20b1-9a98-482a-8e11-a2daae3d08f2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("1c727c63-2579-4035-baac-39df4c09bbe8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("6e706db7-c12c-4d8f-8e9a-556822193d48"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("af8b5c51-d1c8-4b20-b5ce-dd54c24581e5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("121e0751-ea21-4746-808c-6f09a45bd687"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_connection_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("7358ab2d-d6f2-4d0f-af9a-a2146e0c46b1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("0fc2d8b3-5485-48eb-9573-0ad7d9ca2edb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("29f3c611-db28-4500-8d27-944527e006c1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("7fc0daf9-6b33-4928-92a6-353986acd40e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("694f3f50-3476-4f4c-895b-7a14ff52e7d9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("3e021bff-d493-4e8c-be32-a62a7ad91f95"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5f2fbabf-a5d1-4471-a093-2e8614690044"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("353badcc-5530-403e-8f9a-71b4ff7969d6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5148b24f-1c77-470f-a32f-34b63f191e5d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "lane_generic_code",
                columns: new[] { "id", "add_white_space_after", "code", "description", "is_active" },
                values: new object[,]
                {
                    { new Guid("2364ddf8-e5a6-4f3f-91ec-b1d55a1c523f"), false, "H", "D'", true },
                    { new Guid("fe0216da-9b06-4f8d-b38f-4d91796ad4b3"), false, "A", "", true },
                    { new Guid("17a0d69b-6a5f-423c-8a2b-c93c96ddd91a"), true, "B", "À", true },
                    { new Guid("96830639-fc48-4673-b2ee-a2c6bdd9acfc"), false, "C", "À L'", true },
                    { new Guid("0f05e403-e9be-4f45-93f3-ef6dda52e0ae"), true, "D", "À LA", true },
                    { new Guid("3d905da2-e08d-4e55-b024-2402e2572089"), true, "E", "AU", true },
                    { new Guid("0bd9e144-1b09-41e6-88bd-fd454fad8342"), true, "F", "AUX", true },
                    { new Guid("5f4750a2-e4be-48b3-b427-e299947ac2c7"), true, "G", "CHEZ", true },
                    { new Guid("089d9146-c67d-48de-b2c1-ffb00bfc2a99"), true, "I", "DE", true },
                    { new Guid("99e6098d-2de5-4dc7-811c-e324f1d5dd4b"), true, "R", "THE", true },
                    { new Guid("fc846456-2091-445d-bc85-da22069771d6"), true, "K", "DE LA", true },
                    { new Guid("15375891-f145-4ceb-9978-d9ff84ea1822"), true, "L", "DES", true },
                    { new Guid("395e7d3b-e747-4faf-af42-936960ae513f"), true, "M", "DU", true },
                    { new Guid("4eba70e7-1656-41d8-abaa-8f596bda3d85"), false, "N", "L'", true },
                    { new Guid("c54c1bcf-8e0e-4132-8de7-3a926f0d59d9"), true, "O", "LA", true },
                    { new Guid("a60472cc-a8ef-42c5-9a72-1baa46c1b96e"), true, "P", "LE", true },
                    { new Guid("dd5d2540-df8d-4e42-81a1-dd09face8308"), true, "Q", "LES", true },
                    { new Guid("c27d8877-7b9f-4462-b20b-e71e2c2f963f"), false, "J", "DE L'", true }
                });

            migrationBuilder.InsertData(
                table: "lane_public_code",
                columns: new[] { "id", "abbreviation", "code", "description", "is_active" },
                values: new object[,]
                {
                    { new Guid("efa9bcc1-1790-415f-a04b-ab54e9d5f266"), "", "44", "GARDEN", true },
                    { new Guid("9ff1ce81-b2fe-4890-8ec4-4a0c03748882"), "", "41", "FIEF", true },
                    { new Guid("659fc7f6-a843-4259-9693-b3d543791c3e"), "", "40", "ESPLANADE", true },
                    { new Guid("5c46efb6-eace-47e1-b3cb-94b6cadc40f3"), "", "3a", "ALLEY", true },
                    { new Guid("5c00c7d3-6a51-4d9b-80d2-840cae69ba68"), "", "25", "COURS", true },
                    { new Guid("6c7f0c2b-25ac-45a0-b619-e876cceef57a"), "", "26", "COURT", true },
                    { new Guid("f6632d1e-9c1a-460d-b9f5-2b28a16aa2f2"), "", "35", "DESSERTE", true },
                    { new Guid("0197a327-0c6b-40fb-bae3-cbf0876ccd63"), "CR", "32", "CROISSANT", true },
                    { new Guid("fd4a80a3-07eb-4c97-9a04-9d384041ff4c"), "", "34", "DESCENTE", true },
                    { new Guid("b8632077-1760-4a11-ad0b-f1f5351bbafe"), "DO", "36", "DOMAINE", true },
                    { new Guid("92487acb-c039-40fe-b0f2-9e8b10c74055"), "", "38", "DRIVE", true },
                    { new Guid("eacbbabc-35a0-4fba-8f75-9a3a700461f4"), "", "39", "ÉCHANGEUR", true },
                    { new Guid("aef889a9-c2c1-402b-abfe-f5d6deac3e55"), "", "45", "GARDENS", true },
                    { new Guid("ea46553d-0c9b-4619-8782-dd7d7587ff76"), "", "29", "CRESCENT", true },
                    { new Guid("e19772e4-d798-4dce-aed1-d4658d6b001b"), "", "46", "HILL", true },
                    { new Guid("d9dcb3c3-81b7-46d2-ae2d-1e269a0fbf46"), "", "60", "PISTE", true },
                    { new Guid("fee1058f-84e6-4277-b11e-6ab1dfcdc774"), "", "4a", "ANSE", true },
                    { new Guid("4cd1da4a-e4bb-497e-93da-3c4a632c7230"), "", "74", "ROAD", true },
                    { new Guid("9f480514-00d4-4b14-82c8-81e77795b515"), "", "75", "ROND-POINT", true },
                    { new Guid("0f28243f-4fd0-4857-a3e0-61bcf4e195d7"), "", "76", "GRAND RANG", true },
                    { new Guid("f253087e-dc1a-4098-a2d4-6ba7312329df"), "RT", "77", "ROUTE", true },
                    { new Guid("1442ef04-ac2d-4330-a8e8-d6bced4f5b04"), "", "78", "ROUTE RURALE", true },
                    { new Guid("63e441f4-27bc-46bf-8288-01b8d92cd8c4"), "", "79", "RIVIÈRE", true },
                    { new Guid("861203af-8d7a-4263-866b-8093c5365f20"), "RU", "80", "RUE", true },
                    { new Guid("d3b5160c-da84-44f2-8003-63121ab8b3fc"), "RL", "83", "RUELLE", true },
                    { new Guid("e183e9dd-d25c-4b86-880f-6d0785631476"), "", "73", "PETIT RANG", true },
                    { new Guid("6ffc76ff-1ee5-4ce0-8ffb-016ba900c10a"), "SN", "85", "SENTIER", true },
                    { new Guid("dd2720b7-5911-4f58-a2ae-c9649063fc45"), "TE", "89", "TERRASSE", true },
                    { new Guid("76947afd-aabe-413c-b4c2-ab71864ec348"), "", "91", "TRAVERSE", true },
                    { new Guid("710dafbd-af2b-4a81-b838-b38fc4058485"), "", "92", "TRAIT-CARRÉ", true },
                    { new Guid("bdcc94d9-7a15-4af0-8d0f-7beb7a329259"), "", "93", "TUNNEL", true },
                    { new Guid("b94dfb3c-bcaa-432e-911d-3dad09d0f917"), "", "94", "VIADUC", true },
                    { new Guid("5b4aa5f4-d2a5-4be2-a8d2-3cb8d403f393"), "", "95", "VOIE", true },
                    { new Guid("4e4af5e0-4ed0-409b-8c86-da234ec01c07"), "", "96", "RUISSEAU", true },
                    { new Guid("4a20f1ee-b37d-4018-8ecd-3f3120fd26da"), "", "97", "ÎLOT", true },
                    { new Guid("f24472cc-9a41-46a3-b2ce-e3d8b078530c"), "", "86", "SQUARE", true },
                    { new Guid("183ce7e6-200d-4343-9a87-e0e9f67c56ba"), "", "72", "RIDGE", true },
                    { new Guid("ed7222b0-aaa4-4190-ba68-f6ad1ae9a93d"), "RG", "71", "RANG", true },
                    { new Guid("7ef21a9e-2818-4e5c-a3a1-94182abb0f6e"), "", "70", "QUAI", true },
                    { new Guid("9de3c5be-9151-4663-a43e-99ef16a7b044"), "", "50", "IMPASSE", true },
                    { new Guid("673b55cd-47df-40ad-b6da-4cde98e8fe3e"), "", "52", "JARDIN", true },
                    { new Guid("bb955596-9fdb-46b4-be6c-a95d29891a29"), "", "53", "LANE", true },
                    { new Guid("61c6bed8-ed26-4041-8a3a-e7aff4d1498f"), "LA", "54", "LAC", true },
                    { new Guid("aa66b652-9333-4776-9024-36385cfaeb9c"), "", "55", "LIGNE", true },
                    { new Guid("a8a2d1bb-32f4-4486-b8a9-d81a7a4b440a"), "MT", "56", "MONTÉE", true },
                    { new Guid("116521e7-6fd3-4c81-af06-2b7a012f809a"), "", "57", "PARK", true },
                    { new Guid("b8d1ab4e-f374-4e09-b090-54d5a920fb8d"), "", "58", "PASSERELLE", true },
                    { new Guid("8738ffff-6adc-4683-b2ad-385f2a9f6c21"), "", "59", "PARC", true },
                    { new Guid("70119917-9313-4a41-9e23-a3090ae7ec1d"), "CT", "23", "COTE", true },
                    { new Guid("3b6330b2-85f2-4bdc-b195-22a312889585"), "", "61", "PASSAGE", true },
                    { new Guid("86211fe5-c32d-41a9-b2ca-7bb2b71c4822"), "PL", "62", "PLACE", true },
                    { new Guid("f237c131-bc90-49c7-9397-6e0c1944ed96"), "", "63", "PLAGE", true },
                    { new Guid("ed0d9f99-6e1b-473d-965a-84ec85cbba1c"), "", "64", "PLAZA", true },
                    { new Guid("33b95a78-143d-44dc-93ff-3fc7bc3e1ad4"), "", "65", "PONT", true },
                    { new Guid("0ed50d20-2ec8-4e9d-819a-d0f05ff293e7"), "", "66", "PLATEAU", true },
                    { new Guid("ae9182dd-5ff2-48c3-8a2a-1ea01d177926"), "", "67", "PORTAGE", true },
                    { new Guid("5c2a4daa-1312-4b83-a5f5-a5287296330b"), "", "68", "RAMPE", true },
                    { new Guid("f3bc54f2-acc4-419f-954b-715486cd1dad"), "PR", "69", "PROMENADE", true },
                    { new Guid("78ea1f8b-8087-460c-bc51-5807d1b81f0f"), "", "47", "ILE", true },
                    { new Guid("97d7b645-b0ee-43bf-b4bc-9c8d7441e2ec"), "", "22", "CONCESSION", true },
                    { new Guid("775be837-5312-47f7-b26a-183a20b849cc"), "AL", "02", "ALLÉE", true },
                    { new Guid("a0e0125f-fea6-4119-a3d8-d944f49e1329"), "", "20", "CERCLE", true },
                    { new Guid("64d0478e-e61b-4749-92d4-1ecc2601cf82"), "", "21", "CIRCUIT", true },
                    { new Guid("a687ace6-6a27-441e-983f-11c3e85ce228"), "", "01", "", true },
                    { new Guid("c121a6de-3ce1-4c52-8699-21673496512c"), "AV", "08", "AVENUE", true },
                    { new Guid("02df7115-99ed-4585-b34e-35646b447ec3"), "BD", "11", "BOULEVARD", true },
                    { new Guid("6e3765c2-a5f6-473c-97c2-7288340f7cf9"), "AU", "05", "AUTOROUTE", true },
                    { new Guid("2f682729-d11e-4a22-b577-4ba503f97e0c"), "", "15", "CARREFOUR", true },
                    { new Guid("72bd548d-a64c-4467-90cb-c7de605e08bf"), "", "16", "CHAUSSÉE", true },
                    { new Guid("e0b56a99-7e6e-4dae-a873-f2ea76571394"), "CH", "17", "CHEMIN", true },
                    { new Guid("33e0126d-4f30-4491-bd9d-af3433a97a60"), "", "19", "CIRCLE", true },
                    { new Guid("211872bb-6892-44aa-85c6-8590ca3306f4"), "CA", "14", "CARRÉ", true }
                });

            migrationBuilder.InsertData(
                table: "permission_system",
                columns: new[] { "id", "description" },
                values: new object[] { new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), "SURVI-Prevention" });

            migrationBuilder.InsertData(
                table: "person_requiring_assistance_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("3ed291a4-39fb-4625-93e5-1e0efd76bdea"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("078ebd48-9843-43cf-b9fd-cb262b7540df"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("016af358-f9ac-4f72-becc-2b486bb6646b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("7efe2297-c9ca-473f-b48e-3430e6778272"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("e54c9200-d7c1-4fbf-a08a-833f491e9e50"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("3dc24fa2-e091-487f-8d0b-7d0932edcbbe"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5c2b2097-8e67-4fe5-be33-9adea39fb90a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("b76531bc-460c-4ff8-889c-9504e6003e20"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("1bbd7cc9-49ae-490f-a175-ca253d12c21e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("9a056318-cb54-4240-8637-0b38cfcaf9f3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("fec9e14d-e357-40ba-97d8-fcbfe2c6642c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("ec2d9d88-79ac-41ab-8b5c-caac90db4b28"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("895aa8c5-f5fa-4d71-90c9-0f9b48e818f8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("aaf8e4ca-c2d8-4b68-acb5-bc43bf059b6d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "risk_level",
                columns: new[] { "id", "code", "color", "created_on", "is_active", "sequence" },
                values: new object[,]
                {
                    { new Guid("7b7f3db7-ca71-4ef4-ac7d-0f89a79a651d"), 4, "-65536", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("9da4d106-116f-42dc-b92e-323f90d672cd"), 2, "-256", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("90e4f73a-0c96-4da7-b9e0-4243cd29c2e8"), 3, "-23296", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("ee9f0456-d6c3-4763-86ad-bd174a76b629"), 0, "-16777216", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("aa91450d-3528-44b3-b589-6fcbba77ad3f"), 1, "-16744448", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 }
                });

            migrationBuilder.InsertData(
                table: "roof_material_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("d88e6309-f67a-43f6-a961-bdf56f928cbc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("d61be0bd-fff0-422a-909e-2ba5d92757eb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("be830279-4687-4e1f-bd97-23a3f879ffb8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("acb67374-bb4e-4a27-82ef-2b83db82e7c1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("a5c7abf1-1b2a-4296-b2c4-c035df4c9a5b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "roof_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("773de910-a94a-41cb-9f17-38e69d788700"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5cc36bd7-fe6a-47d9-a490-2d4560505445"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("75802958-7ee5-4fe3-b7f7-59edc5a3b712"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5e5509fd-e91b-4e0a-8e84-e2bf3027f949"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("b3f36659-bb7e-4553-8d4e-6a7abd9fb697"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("0e23640f-2a4b-4b37-9a93-dc694c3f228d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("4801d403-5564-4ac3-91e6-4c679c44f085"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("d0b106f0-0751-4a96-b2c6-c16ecf9ba2bc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("a8964d13-7910-433d-9513-88995ccf0820"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "siding_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("e58e7209-e151-49f1-b241-775401036425"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("d0079e8f-b0d1-4fe8-ac69-84087a4ea42c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("947c3969-430b-4ee3-9453-b24ca1a35a9c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("d951897a-949f-4b80-9208-1b3b340c82c6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("174ed7a6-c79c-4aa5-ab87-6f7ceabcbd32"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("78397b1c-f2bf-4bc2-b05e-2206a1249503"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("aa3aabab-e510-4df1-86d7-cadb7e9b8a54"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("5258d5e9-846a-4f33-9246-49aa25ce4fe3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("9a2fdec1-5e2d-4868-958f-747ec719a888"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("3ee73750-2034-4bcb-84e2-52c87b7cf47c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "sprinkler_type",
                columns: new[] { "id", "created_on", "is_active" },
                values: new object[,]
                {
                    { new Guid("2bcb05e1-5788-4beb-8395-07ec55c2ed60"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("f745efd4-3851-4440-9502-15eb1fcf4b40"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("0f0da61b-8bbd-4f79-927a-e2a98a87ca3d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("90a001d9-1348-47cd-b44e-ac2a0484cd57"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("758e5835-deeb-4167-8732-be9d2c338968"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("2cdd734c-0ffe-4c39-b874-59f1743db693"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "unit_of_measure",
                columns: new[] { "id", "abbreviation", "created_on", "is_active", "measure_type" },
                values: new object[,]
                {
                    { new Guid("c1ca6d9b-0808-4add-a609-ed50ca8cd23c"), "sh tn", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("eb9d70c4-3b1b-4c84-99dd-684700e84484"), "ml", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("db98476e-04bf-4502-9a0a-6e4a14797915"), "po3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("ef8f06ac-6718-489b-b833-eb0b24926812"), "pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("6414f1c7-73a7-434b-9217-caba747ec10e"), "t", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("1d79513f-faeb-4bc8-801d-964dd07afa10"), "pi3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("b2974a84-ed50-4660-85d0-39d7d394d308"), "Kg", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("47d931ed-da80-4643-b7ce-1a32fc86366d"), "", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("0a89ee7d-1205-4e9b-ac34-5231df0477cb"), "G", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("d2f7d529-f330-44f7-a522-c1248fd0f68d"), "g", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("fa616ff7-f819-497c-a80b-e0adf04f4b40"), "L", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("a29dd195-53b0-4e5f-857d-6236f6faf588"), "m3", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("556b2773-cd90-413c-a666-a8825a0cc2a3"), "GI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("ada51f7e-2aef-4879-99e2-cd11fe8ca93b"), "pi", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("18ac17a4-623a-404f-a8e3-ffe8e0d5436b"), "lb", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { new Guid("71feff9f-c32d-44e6-82a8-b86b82d64bb5"), "po", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("32d7e795-31e6-4b07-9784-c2de1c63980d"), "mm", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { new Guid("5f45f2f3-cd97-4ba4-a17c-f191df34ee4a"), "m3/h", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("2ee63245-6a57-4c01-8746-b10acc473b1a"), "KPA", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("d5a9dd30-c345-496e-8669-ca9f09295878"), "PSI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { new Guid("a6b0949f-d056-4aa9-8281-d6f93941369a"), "", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("3015ac3e-43c5-4b74-9b3d-6f4cec3d1409"), "L", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("3ac84278-7606-4cb9-bc5a-9bdc3a8fb9d0"), "G", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("845d7bb3-6554-441d-bf41-6ec003598f20"), "GI", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("14ea0d1c-a434-47d1-ba17-57967e79b4c9"), "LPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("96801d59-e01e-4219-a918-0a570a174b74"), "GPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("f4f46acc-3aa5-4a77-9a75-25d66c23a917"), "GIPM", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0 },
                    { new Guid("900edc6d-7658-46d6-a696-77b57e32a3c7"), "m", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { new Guid("01952575-4d87-4bc2-a087-b4b5ec2cb979"), "oz", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 }
                });

            migrationBuilder.InsertData(
                table: "webuser",
                columns: new[] { "id", "created_on", "is_active", "password", "username" },
                values: new object[] { new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247", "admin" });

            migrationBuilder.InsertData(
                table: "alarm_panel_type_localization",
                columns: new[] { "id", "created_on", "id_alarm_panel_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("eaa9876f-c242-4288-a88c-856e5cb20229"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9eaab857-ee8d-456f-aa4c-db54577a78be"), true, "fr", "Intrusion" },
                    { new Guid("3242a0d5-8206-4cec-891f-5540e59f8164"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9eaab857-ee8d-456f-aa4c-db54577a78be"), true, "en", "Intrusion" },
                    { new Guid("b8e11d29-8ba4-4525-8037-0469931417c1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b79c12a-8bb2-4f2e-99e5-148cabd3e01b"), true, "fr", "Non zoné" },
                    { new Guid("da11be29-00f5-4877-83d0-da8ca2bd7186"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b79c12a-8bb2-4f2e-99e5-148cabd3e01b"), true, "en", "Not zoned" },
                    { new Guid("d536c44b-671d-45be-b065-2cf47efa4dde"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e2624494-61a9-43e8-8c80-7b951ccf890b"), true, "fr", "Zoné" },
                    { new Guid("3583c264-0d3a-4022-bb6f-2d8760ec91a6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e2624494-61a9-43e8-8c80-7b951ccf890b"), true, "en", "Zoned" },
                    { new Guid("f6bf1b90-9901-4378-a9b2-e453cd6236ae"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8df88764-3d85-4c3f-8d0c-bedeca587660"), true, "fr", "Adressable" },
                    { new Guid("c25b9219-849d-4f9d-8f89-c27b9af975ce"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8df88764-3d85-4c3f-8d0c-bedeca587660"), true, "en", "Adressable" }
                });

            migrationBuilder.InsertData(
                table: "building_type_localization",
                columns: new[] { "id", "created_on", "id_building_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("cb0461e3-bff7-4f67-b7af-aac02de5bc22"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f39af62-ab3f-4792-a83a-42e1a33bc4e6"), true, "en", "Other" },
                    { new Guid("a3495dbe-238f-43c5-95ab-f6e7e1182b85"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f39af62-ab3f-4792-a83a-42e1a33bc4e6"), true, "fr", "Autre" },
                    { new Guid("ade71aa8-8104-4f0b-8b70-b09afd1c0149"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a6ce3e4-41a4-4279-81d7-2302273932e9"), true, "en", "Semi-detached" },
                    { new Guid("b7592a40-405b-4d2b-b5bf-ee6ea095c97f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a6ce3e4-41a4-4279-81d7-2302273932e9"), true, "fr", "Jumelé" },
                    { new Guid("55bbce33-b0ba-4ff1-9072-9c6f36e60a5a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56c0186b-9c3f-4f9a-9b31-526505eb2f27"), true, "fr", "Détaché" },
                    { new Guid("fe1e2e0d-cf3e-440e-af40-3c4aa89ca476"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f64d446-ee04-4be4-8884-d478b2205015"), true, "en", "Attached" },
                    { new Guid("98af843d-a6b4-45c6-8c06-bd2ecd10bbf7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f64d446-ee04-4be4-8884-d478b2205015"), true, "fr", "Attaché" },
                    { new Guid("5cbaa810-c9eb-432f-9562-285d69a1daea"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56c0186b-9c3f-4f9a-9b31-526505eb2f27"), true, "en", "Detached" }
                });

            migrationBuilder.InsertData(
                table: "construction_fire_resistance_type_localization",
                columns: new[] { "id", "created_on", "id_parent", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("42bdb80b-2909-49fc-8509-739c4f4b1abb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4f66e0d-87d5-47f8-a825-e5ea38819d20"), true, "fr", "Résistante au feu" },
                    { new Guid("3236e848-4139-4484-930a-bf83006228b0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6d79902-1622-47b2-b44c-391fa2dd35f1"), true, "en", "Hybrid" },
                    { new Guid("eeb2abcf-1af5-4561-81a4-d233b77c8ad0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6d79902-1622-47b2-b44c-391fa2dd35f1"), true, "fr", "Hybride" },
                    { new Guid("8a9cd98f-0bd4-417c-9c5b-e936f610a20e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4f66e0d-87d5-47f8-a825-e5ea38819d20"), true, "en", "Fire resistant" },
                    { new Guid("6cc720c2-67ab-4e77-9159-1c2faee12c67"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("08271a20-bd18-445e-8ba5-ec89bfd3f042"), true, "en", "Nonflammable" },
                    { new Guid("57df3d48-2755-44da-8e9c-0b4df88c344f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37b22728-8de2-4f85-ad21-4fa7ba95aaa2"), true, "en", "Regular" },
                    { new Guid("8a321a84-d5da-4542-bd41-8d603f68a7d0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bf7bd80-a821-49b7-95c2-c1683ae4d97d"), true, "en", "Flammable" },
                    { new Guid("d61fa446-ad4d-48b7-a755-0da80a93b5a3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bf7bd80-a821-49b7-95c2-c1683ae4d97d"), true, "fr", "Combustible" },
                    { new Guid("df258851-5140-429a-b022-e29301f10844"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("37b22728-8de2-4f85-ad21-4fa7ba95aaa2"), true, "fr", "Ordinaire" },
                    { new Guid("5e51e28e-025d-48b2-a3c6-3b10c8ac9883"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("08271a20-bd18-445e-8ba5-ec89bfd3f042"), true, "fr", "Incombustible" }
                });

            migrationBuilder.InsertData(
                table: "construction_type_localization",
                columns: new[] { "id", "created_on", "id_construction_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("4ef8b821-3631-40bf-aa05-311e55f9f246"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("088798b8-31ef-4644-a735-1091a28d0e75"), true, "en", "Steel with protected steel joists" },
                    { new Guid("82ecd48c-ba4d-4bbc-b254-f4b83a12bf28"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("87ad142b-119a-4757-9b4c-4281469b3810"), true, "en", "Undetermined" },
                    { new Guid("ca867ce0-9331-406c-9587-df12dd551372"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("87ad142b-119a-4757-9b4c-4281469b3810"), true, "fr", "Indéterminé" },
                    { new Guid("5cf5ce19-e6aa-4a79-8101-6d61f60271f1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2543bae8-9f96-4fb9-81d7-fd78fcabec5c"), true, "en", "Other" },
                    { new Guid("bb1f1be0-c570-4cb1-a4ed-fd2dc20f4c4b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2543bae8-9f96-4fb9-81d7-fd78fcabec5c"), true, "fr", "Autre type" },
                    { new Guid("c911cf12-2ef0-481c-a904-0814796e29d8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("723839fb-0d7f-4f5f-b1c4-dde687ddf416"), true, "en", "Concrete" },
                    { new Guid("aaf71bb3-7313-4e22-9955-cf5a22040e01"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("723839fb-0d7f-4f5f-b1c4-dde687ddf416"), true, "fr", "Béton" },
                    { new Guid("71413cfa-9383-4347-8ca5-d736a03c061b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80994dae-01a0-4701-be45-7271abe7364f"), true, "en", "Steel with unprotected steel joists" },
                    { new Guid("9629f2b5-8e41-46d2-ada8-1eae746232a5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80994dae-01a0-4701-be45-7271abe7364f"), true, "fr", "Acier avec solives en acier non protégées" },
                    { new Guid("774c53de-df84-49bd-90d5-bfccadad6cb2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("088798b8-31ef-4644-a735-1091a28d0e75"), true, "fr", "Acier avec solives en acier protégées" },
                    { new Guid("ea131d1c-633e-4a19-9881-6ac0554d8d5e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af8b5c51-d1c8-4b20-b5ce-dd54c24581e5"), true, "en", "Wood frame and prefabricated joists" },
                    { new Guid("e3cac5a9-2bc0-4577-adfe-38754fc726a1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("121e0751-ea21-4746-808c-6f09a45bd687"), true, "fr", "Mur porteur en maçonnerie et solives en aciers ou dalle de béton" },
                    { new Guid("c5394200-4ea1-4c1b-9e66-054e2a306a56"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("121e0751-ea21-4746-808c-6f09a45bd687"), true, "en", "Masonry bearing wall and steel joists or concrete slab" },
                    { new Guid("d4b4ed94-b8fd-4bce-9338-016cd8642610"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e706db7-c12c-4d8f-8e9a-556822193d48"), true, "fr", "Gros bois d'oeuvre" },
                    { new Guid("be8ac495-3fd3-49bd-8fbc-ce75f5ced1bd"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e706db7-c12c-4d8f-8e9a-556822193d48"), true, "en", "Lumber" },
                    { new Guid("6831736c-8c66-44a9-a3dc-93bbaea0f455"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af8b5c51-d1c8-4b20-b5ce-dd54c24581e5"), true, "fr", "Ossature de bois avec solives préfabriquées" },
                    { new Guid("ec4f297d-4e7c-46a7-a694-6ceb89a7d6f9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1c727c63-2579-4035-baac-39df4c09bbe8"), true, "en", "Masonry bearing wall and solid wood joists" },
                    { new Guid("1ae424b2-3bf3-4970-8842-eaa5cb4f2da8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("025f20b1-9a98-482a-8e11-a2daae3d08f2"), true, "fr", "Mur porteur en maçonnerie et solives préfabriquées" },
                    { new Guid("0b954872-07d1-4263-82fb-00bf04d68f7b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("025f20b1-9a98-482a-8e11-a2daae3d08f2"), true, "en", "Masonry bearing wall and prefabricated joists" },
                    { new Guid("cd7504b2-a0e1-4507-b842-1a8696a3a4fb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1c727c63-2579-4035-baac-39df4c09bbe8"), true, "fr", "Mur porteur en maçonnerie avec mur solives en bois solides" }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_connection_type_localization",
                columns: new[] { "id", "created_on", "id_fire_hydrant_connection_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("73022941-bcff-4319-96e0-ecd904bfc2b4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7358ab2d-d6f2-4d0f-af9a-a2146e0c46b1"), true, "fr", "Fileté" },
                    { new Guid("c802d0b9-a5ef-4005-a6fd-97faf994abaa"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7358ab2d-d6f2-4d0f-af9a-a2146e0c46b1"), true, "en", "Threaded" },
                    { new Guid("63c49005-623d-4ff3-80d8-ae5c6b3d3e0f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0fc2d8b3-5485-48eb-9573-0ad7d9ca2edb"), true, "fr", "Storz" },
                    { new Guid("bc883ad5-cfde-482c-b05b-3802ee873643"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0fc2d8b3-5485-48eb-9573-0ad7d9ca2edb"), true, "en", "Storz" }
                });

            migrationBuilder.InsertData(
                table: "fire_hydrant_type_localization",
                columns: new[] { "id", "created_on", "id_fire_hydrant_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("7342589c-297d-44a2-a592-06d9d3e8cf4e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f2fbabf-a5d1-4471-a093-2e8614690044"), true, "en", "Fountain" },
                    { new Guid("6c739381-2fe8-4bf8-b95b-a7b99131947e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("353badcc-5530-403e-8f9a-71b4ff7969d6"), true, "fr", "Sèche" },
                    { new Guid("4b05ea0b-b20a-4232-aedd-e39c8c94771f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("353badcc-5530-403e-8f9a-71b4ff7969d6"), true, "en", "Dry" },
                    { new Guid("99f5c70f-bec8-473c-b3a7-8f7229a09aae"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f2fbabf-a5d1-4471-a093-2e8614690044"), true, "fr", "Fontaine" },
                    { new Guid("f0e5c2a6-36fd-4f12-8698-3c3cd80179f5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5148b24f-1c77-470f-a32f-34b63f191e5d"), true, "fr", "Citerne" },
                    { new Guid("75539adb-c971-4901-b251-c3a75145bed2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("29f3c611-db28-4500-8d27-944527e006c1"), true, "fr", "Statique" },
                    { new Guid("a7b90d2c-6b37-4d1e-b580-591fe4f8eaeb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("694f3f50-3476-4f4c-895b-7a14ff52e7d9"), true, "fr", "Borne fontaine" },
                    { new Guid("35d759eb-abe8-400b-bd28-ea1c4ad9c705"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("694f3f50-3476-4f4c-895b-7a14ff52e7d9"), true, "en", "Fire hydrant" },
                    { new Guid("fbf3a7d8-c9ff-4bad-b225-f2e260befdb4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e021bff-d493-4e8c-be32-a62a7ad91f95"), true, "fr", "Point d'eau" },
                    { new Guid("2998c6ff-c26e-4908-a4a0-60f1be244585"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e021bff-d493-4e8c-be32-a62a7ad91f95"), true, "en", "Water point" },
                    { new Guid("fcb0c181-f9de-46b3-a480-66158de4ceee"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7fc0daf9-6b33-4928-92a6-353986acd40e"), true, "fr", "Borne sèche" },
                    { new Guid("38146953-dc9f-4929-bbf9-6dd48eca2292"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7fc0daf9-6b33-4928-92a6-353986acd40e"), true, "en", "Dry fire hydrant" },
                    { new Guid("bcef3322-18a7-4768-9878-1bd183a5a0bf"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("29f3c611-db28-4500-8d27-944527e006c1"), true, "en", "Static" },
                    { new Guid("c81b0038-41f6-45ec-8f6f-4ed1a58d9fe0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5148b24f-1c77-470f-a32f-34b63f191e5d"), true, "en", "Tank" }
                });

            migrationBuilder.InsertData(
                table: "permission_object",
                columns: new[] { "id", "generic_id", "group_name", "id_permission_object_parent", "id_permission_system", "is_group", "object_table" },
                values: new object[,]
                {
                    { new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), "", "Administration", null, new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), true, "group" },
                    { new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), "", "Pompier", null, new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), true, "group" }
                });

            migrationBuilder.InsertData(
                table: "permission_system_feature",
                columns: new[] { "id", "default_value", "description", "feature_name", "id_permission_system" },
                values: new object[,]
                {
                    { new Guid("b38a094f-b0a6-494b-9104-009d30199cbf"), false, "Gestion des opérateurs", "RightOperatorManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("78b19b2a-f31b-4027-8b92-105a0ac44282"), false, "Gestion des unités de mesure", "RightUnitManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("d68c1911-e063-4b22-a635-413004d3bd60"), false, "Gestion des comtés", "RightCountyManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("62982bdc-2ae9-407b-9396-01bfb3c50d23"), false, "Gestion des régions", "RightRegionManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("193ab58d-0a0f-48d5-bb65-6a2d67db58c4"), false, "Gestion des provinces/états", "RightStateManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4e5be439-7249-4f7c-b9c1-e0a448046c57"), false, "Gestion des codes d'utilisation", "RightUtilisationCodeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("8a9896a5-0ab5-4c33-a01f-7e97742c9570"), false, "Gestion des types de ville", "RightCityTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd"), false, "Gestion des villes", "RightCityManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("2dfaae63-39a2-471c-9a42-705cba52c565"), false, "Gestion des niveaux de risque", "RightRiskLevelManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("6da8395e-4057-415c-9710-ea098fdf2e9e"), false, "Gestion des types de PNAPs", "RightRPATypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("e8c4cc98-7e17-450b-8333-9d87cd8f695a"), false, "Gestion des matières dangereuses", "RightHazardousMaterialManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("9898d805-e8ef-4595-a0d2-66d1b022ea86"), false, "Gestion des niveaux de risque par SSI", "RightDepartmentRiskLevel", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("08dfbdb1-6cf4-449b-85e3-8134de4ed052"), false, "Gestion des pays", "RightCountryManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1864a414-64a3-4f67-9556-059ad9c5a672"), false, "Gestion des types de connexion", "RightConnectionTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("0615bbba-ae42-472b-b768-227b80efd4f1"), false, "Gestion des voies", "RightLaneManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("89dbc380-186b-440c-a069-bd42d0664ed8"), false, "Gestion des utilisateurs", "RightUserManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("26d14cda-d321-4db2-a604-6daaff0483e9"), false, "Gestion des SSI", "RightDepartmentManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843"), false, "Accès aux statistiques", "url-statistics", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), false, "Accès à la gestion des rapports", "url-report-configuration", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), false, "Accès à la gestion système", "url-management-system", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("05d57316-7b0a-4195-bfdb-796262d4128a"), false, "Accès à la gestion des types du système", "url-management-typesystem", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d"), false, "Accès à la gestion des questionnaires", "url-management-survey", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749"), false, "Gestion des types de borne", "RightFireHydrantTypeManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), false, "Accès à la gestion des villes", "url-management-address", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), true, "Accès au mobile", "RightMobile", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("aa163670-487c-461e-8112-9bf98070f5b3"), false, "Acception des inspections", "RightApproveInspection", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43"), false, "Gestion des lots", "RightBatchManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), false, "Gestion des casernes", "RightFireStationManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("98075263-e986-4823-aa11-cfca837adcbc"), false, "Gestion des bâtiments", "RightBuildingManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), false, "Gestion des permissions", "RightPermissionManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4"), false, "Accès à la gestion du SSI", "url-management-department", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), false, "Gestion des bornes", "RightFireHydrantManagement", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") },
                    { new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), true, "Accès au tableau de bord", "url-inspection-dashboard", new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4") }
                });

            migrationBuilder.InsertData(
                table: "person_requiring_assistance_type_localization",
                columns: new[] { "id", "created_on", "id_person_requiring_assistance_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("00cd08c2-00b4-4e1f-9c1d-8927db5bedb4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaf8e4ca-c2d8-4b68-acb5-bc43bf059b6d"), true, "fr", "Déficients intellectuels" },
                    { new Guid("99c58d75-2700-41f4-8d1b-e90bd6f7c4d5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("016af358-f9ac-4f72-becc-2b486bb6646b"), true, "en", "Blind" },
                    { new Guid("831609a5-c7b6-4c3f-80e9-e19448db0eda"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("016af358-f9ac-4f72-becc-2b486bb6646b"), true, "fr", "Non-voyants" },
                    { new Guid("7b4c01fe-ba09-4db4-90f9-9de61c32f179"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7efe2297-c9ca-473f-b48e-3430e6778272"), true, "en", "Reduced mobility" },
                    { new Guid("f69c1037-d381-4524-a6ae-e05f5624b832"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7efe2297-c9ca-473f-b48e-3430e6778272"), true, "fr", "Mobilité réduite" },
                    { new Guid("e3ed7e5a-ff65-4f47-b032-b86fa783e4b6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e54c9200-d7c1-4fbf-a08a-833f491e9e50"), true, "en", "Hard of hearing" },
                    { new Guid("7a897396-f98b-4290-b620-580182a283b8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e54c9200-d7c1-4fbf-a08a-833f491e9e50"), true, "fr", "Malentendants" },
                    { new Guid("352b62b5-0f59-4e87-967d-12d1b17be2b4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ed291a4-39fb-4625-93e5-1e0efd76bdea"), true, "en", "Nursery" },
                    { new Guid("68a9742b-48c9-43b0-9a92-89cda72bbb6f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ed291a4-39fb-4625-93e5-1e0efd76bdea"), true, "fr", "Garderie" },
                    { new Guid("2049151a-43a0-483e-89c7-7ccc62991f9d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3dc24fa2-e091-487f-8d0b-7d0932edcbbe"), true, "en", "School" },
                    { new Guid("d4d6aab8-aa99-41e3-b2fd-dd887fb96737"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3dc24fa2-e091-487f-8d0b-7d0932edcbbe"), true, "fr", "École" },
                    { new Guid("b3c6ef63-b480-4143-9b80-bbda483cf3ce"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaf8e4ca-c2d8-4b68-acb5-bc43bf059b6d"), true, "en", "Intellectual deficient" },
                    { new Guid("2b25c4c1-b5fd-4db2-8d91-fec3b6b5180d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("078ebd48-9843-43cf-b9fd-cb262b7540df"), true, "fr", "Personnes agées" },
                    { new Guid("8b6acc43-00f6-41f2-93d4-9dd8ddc7095b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b76531bc-460c-4ff8-889c-9504e6003e20"), true, "en", "Medical center" },
                    { new Guid("f6a9e651-52a7-4a7e-ab95-f4c6ebfa568f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bbd7cc9-49ae-490f-a175-ca253d12c21e"), true, "en", "Other" },
                    { new Guid("c143742a-e9a1-4f0d-b095-108d12da184a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1bbd7cc9-49ae-490f-a175-ca253d12c21e"), true, "fr", "Autre" },
                    { new Guid("fa9bcff7-9e18-4c0e-8f69-a936b754bbb0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a056318-cb54-4240-8637-0b38cfcaf9f3"), true, "en", "Cognitive" },
                    { new Guid("56c81cd9-d07c-4986-a475-a5814e88c7d2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a056318-cb54-4240-8637-0b38cfcaf9f3"), true, "fr", "Cognitif" },
                    { new Guid("729d73fa-a8ac-4412-9667-268e633c4eef"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c2b2097-8e67-4fe5-be33-9adea39fb90a"), true, "en", "Deafness" },
                    { new Guid("d26d0cda-68ce-49c3-9eb2-696d1e02916c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c2b2097-8e67-4fe5-be33-9adea39fb90a"), true, "fr", "Surdité" },
                    { new Guid("fe739214-f81d-4e12-916e-e2d0aef6e1d8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fec9e14d-e357-40ba-97d8-fcbfe2c6642c"), true, "en", "Visually impaired" },
                    { new Guid("38152889-a72a-4673-acc1-35165c23d8d8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fec9e14d-e357-40ba-97d8-fcbfe2c6642c"), true, "fr", "Trouble vision" },
                    { new Guid("506d6909-cdfa-4417-882b-c37a42fb0177"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec2d9d88-79ac-41ab-8b5c-caac90db4b28"), true, "en", "Handicapped person" },
                    { new Guid("819db690-b8ad-4bca-9c24-f5908acf87b3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec2d9d88-79ac-41ab-8b5c-caac90db4b28"), true, "fr", "Personnes handicapées" },
                    { new Guid("8ee314bb-fab1-496f-805b-2647bfae85b4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("895aa8c5-f5fa-4d71-90c9-0f9b48e818f8"), true, "en", "Camp/playground" },
                    { new Guid("03827c16-2907-4b31-9235-dc0aa41ddc77"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("895aa8c5-f5fa-4d71-90c9-0f9b48e818f8"), true, "fr", "Camp/Terrain de jeu" },
                    { new Guid("1d7914fa-cd6b-4ee6-9bd8-372d4e755f16"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b76531bc-460c-4ff8-889c-9504e6003e20"), true, "fr", "Centre médical" },
                    { new Guid("ba10c7cc-ed99-4df8-a0f5-c4d0d14e56cb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("078ebd48-9843-43cf-b9fd-cb262b7540df"), true, "en", "Elderly" }
                });

            migrationBuilder.InsertData(
                table: "risk_level_localization",
                columns: new[] { "id", "created_on", "id_risk_level", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("39e352db-07a5-4d9b-b736-20dd19be1752"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa91450d-3528-44b3-b589-6fcbba77ad3f"), true, "fr", "Faible" },
                    { new Guid("4bd93cf9-7ff5-412b-819a-5ef49c103b3c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9da4d106-116f-42dc-b92e-323f90d672cd"), true, "en", "Medium" },
                    { new Guid("1523aed4-853b-42fe-b57b-7269ea96e01f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa91450d-3528-44b3-b589-6fcbba77ad3f"), true, "en", "Low" },
                    { new Guid("d96503f6-09ba-46be-bfe0-543012cdc676"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9da4d106-116f-42dc-b92e-323f90d672cd"), true, "fr", "Moyen" },
                    { new Guid("7bce3236-009c-4a7c-aea8-fe8fdfb91b96"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ee9f0456-d6c3-4763-86ad-bd174a76b629"), true, "fr", "Indéterminé" },
                    { new Guid("3d07f034-9b74-48f4-92fc-03da6225719f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90e4f73a-0c96-4da7-b9e0-4243cd29c2e8"), true, "fr", "Élevé" },
                    { new Guid("08d04860-f1d1-4e14-a7b8-d464ec2737eb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90e4f73a-0c96-4da7-b9e0-4243cd29c2e8"), true, "en", "High" },
                    { new Guid("718a742b-707b-4580-96ab-3b19a272e839"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7b7f3db7-ca71-4ef4-ac7d-0f89a79a651d"), true, "fr", "Très élevé" },
                    { new Guid("d6771676-0c5c-47b2-ba86-b3469898ecd5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7b7f3db7-ca71-4ef4-ac7d-0f89a79a651d"), true, "en", "Very high" },
                    { new Guid("fcd6d560-bd16-44d7-9230-b7f205c38bcb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ee9f0456-d6c3-4763-86ad-bd174a76b629"), true, "en", "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "roof_material_type_localization",
                columns: new[] { "id", "created_on", "id_roof_material_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("c8218002-6904-4033-8e39-2ebabf700840"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d61be0bd-fff0-422a-909e-2ba5d92757eb"), true, "en", "Wood" },
                    { new Guid("c45526dc-6d5f-4473-b4cb-8506ed7d48fe"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d61be0bd-fff0-422a-909e-2ba5d92757eb"), true, "fr", "Bois" },
                    { new Guid("f3aa5521-568d-41c7-8710-bde6cec6c61f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be830279-4687-4e1f-bd97-23a3f879ffb8"), true, "en", "Skylight" },
                    { new Guid("b5831b33-8eef-413c-ad95-625a3ce56f0e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("acb67374-bb4e-4a27-82ef-2b83db82e7c1"), true, "en", "Tar mat" },
                    { new Guid("87a68248-9828-4ccc-8fe9-60a4cfa7efeb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be830279-4687-4e1f-bd97-23a3f879ffb8"), true, "fr", "Puit de lumière" },
                    { new Guid("9e59695c-7227-472d-9b43-86324206ac13"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d88e6309-f67a-43f6-a961-bdf56f928cbc"), true, "en", "Sheet metal" },
                    { new Guid("0c122e8e-1ec5-4741-ab72-346bfb39def6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d88e6309-f67a-43f6-a961-bdf56f928cbc"), true, "fr", "Tôle" },
                    { new Guid("658df9f3-024c-48f1-be6a-b33d13098f35"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c7abf1-1b2a-4296-b2c4-c035df4c9a5b"), true, "en", "Asphalt shingles" },
                    { new Guid("5febbedc-c0cb-4f41-83ed-49db713383f2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c7abf1-1b2a-4296-b2c4-c035df4c9a5b"), true, "fr", "Bardeaux d'asphalte" },
                    { new Guid("402c2c4e-0478-477a-88fd-adc40ada03b9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("acb67374-bb4e-4a27-82ef-2b83db82e7c1"), true, "fr", "Tapis de goudron" }
                });

            migrationBuilder.InsertData(
                table: "roof_type_localization",
                columns: new[] { "id", "created_on", "id_roof_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("244e1b8b-e08b-4260-884c-73eb37095e94"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5e5509fd-e91b-4e0a-8e84-e2bf3027f949"), true, "fr", "Mansarde" },
                    { new Guid("d191edd8-376d-40bd-8004-dc1f8f098227"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8964d13-7910-433d-9513-88995ccf0820"), true, "fr", "Cône français" },
                    { new Guid("28e8fde4-3771-4ae6-9b3b-b158ba1d474e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8964d13-7910-433d-9513-88995ccf0820"), true, "en", "French cone" },
                    { new Guid("dea17fbe-4c98-4a16-90f9-b157f7c17866"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3f36659-bb7e-4553-8d4e-6a7abd9fb697"), true, "fr", "Diamant" },
                    { new Guid("bf01d730-5489-41d3-9210-6b7ea13faf1d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3f36659-bb7e-4553-8d4e-6a7abd9fb697"), true, "en", "Diamond" },
                    { new Guid("4f246487-3254-413c-a737-936cdf3ea5de"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("773de910-a94a-41cb-9f17-38e69d788700"), true, "fr", "Dôme" },
                    { new Guid("30bb690c-a146-45c8-83a4-9f2185c5a611"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("773de910-a94a-41cb-9f17-38e69d788700"), true, "en", "Dome" },
                    { new Guid("a903ba9e-6a42-4d8c-91d5-99c4c40af03e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5e5509fd-e91b-4e0a-8e84-e2bf3027f949"), true, "en", "Mansard" },
                    { new Guid("4f1fe925-5653-4fc9-ac72-04126e9dbe2e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e23640f-2a4b-4b37-9a93-dc694c3f228d"), true, "en", "1 slope" },
                    { new Guid("b448162f-2840-4de2-999a-f75abcfb239d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75802958-7ee5-4fe3-b7f7-59edc5a3b712"), true, "en", "Slope" },
                    { new Guid("140d3f25-1819-43fe-8a0d-28b65aa55630"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cc36bd7-fe6a-47d9-a490-2d4560505445"), true, "fr", "Plat" },
                    { new Guid("519e1c86-c15e-4ad3-a5ca-5cdd8c462dcb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cc36bd7-fe6a-47d9-a490-2d4560505445"), true, "en", "Flat" },
                    { new Guid("f98bab94-e1a9-45bb-b7b9-6ea8e7128c0d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4801d403-5564-4ac3-91e6-4c679c44f085"), true, "en", "2 slopes" },
                    { new Guid("db57ba45-7d1b-4812-b0f9-0b6e45e5ba49"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4801d403-5564-4ac3-91e6-4c679c44f085"), true, "fr", "2 versants" },
                    { new Guid("72dca069-e359-4d89-8536-9f6979a58952"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0b106f0-0751-4a96-b2c6-c16ecf9ba2bc"), true, "fr", "4 versants" },
                    { new Guid("9c28bc1d-3b65-4c0a-a6f7-3cca6d344faa"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e23640f-2a4b-4b37-9a93-dc694c3f228d"), true, "fr", "1 versant" },
                    { new Guid("037d2be4-0a50-4a6f-827e-00e4a58cae47"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75802958-7ee5-4fe3-b7f7-59edc5a3b712"), true, "fr", "Pente" },
                    { new Guid("95101771-4d13-4401-8958-1684ca89da39"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0b106f0-0751-4a96-b2c6-c16ecf9ba2bc"), true, "en", "3 slopes" }
                });

            migrationBuilder.InsertData(
                table: "siding_type_localization",
                columns: new[] { "id", "created_on", "id_siding_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("a3972b78-6039-43ce-a285-9975faaa4361"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174ed7a6-c79c-4aa5-ab87-6f7ceabcbd32"), true, "fr", "Bardeaux de cèdre" },
                    { new Guid("770fba5e-75e5-4ea1-b313-15cb1d31db16"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ee73750-2034-4bcb-84e2-52c87b7cf47c"), true, "en", "Brick" },
                    { new Guid("8f00d828-3db9-4296-aa38-ad8bf6b8ccfa"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("947c3969-430b-4ee3-9453-b24ca1a35a9c"), true, "en", "Stucco" },
                    { new Guid("5da4c4ed-850e-482a-9222-33c18bdf27ae"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0079e8f-b0d1-4fe8-ac69-84087a4ea42c"), true, "fr", "Tôle" },
                    { new Guid("8d505447-4146-4a26-bf1e-6733f3c1b05e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0079e8f-b0d1-4fe8-ac69-84087a4ea42c"), true, "en", "Sheet metal" },
                    { new Guid("6698affd-3310-44e9-ad5f-94c5a187bc95"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d951897a-949f-4b80-9208-1b3b340c82c6"), true, "fr", "Pierre" },
                    { new Guid("fa2717e9-4890-4310-ac0b-e1fedcd86d28"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("174ed7a6-c79c-4aa5-ab87-6f7ceabcbd32"), true, "en", "Cedar shingles" },
                    { new Guid("e0beebfd-ad61-4e87-a5ed-d407cccb198a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e58e7209-e151-49f1-b241-775401036425"), true, "fr", "Masonite" },
                    { new Guid("c2e68a37-0e20-4fa8-86b9-f5b7774e5b18"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e58e7209-e151-49f1-b241-775401036425"), true, "en", "Masonite" },
                    { new Guid("9b4402f8-656e-4c4d-9f36-4ea1f644d02b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5258d5e9-846a-4f33-9246-49aa25ce4fe3"), true, "en", "Canexel" },
                    { new Guid("1376d1eb-6221-408d-ad45-430347935312"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5258d5e9-846a-4f33-9246-49aa25ce4fe3"), true, "fr", "Canexel" },
                    { new Guid("b0440e97-3d82-4e23-b003-4f89f0242cb4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("78397b1c-f2bf-4bc2-b05e-2206a1249503"), true, "en", "Wood" },
                    { new Guid("f3e9c9b1-0a50-4ce3-b764-597e69c731db"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("78397b1c-f2bf-4bc2-b05e-2206a1249503"), true, "fr", "Bois" },
                    { new Guid("026b6b9c-1a96-4f61-9e74-2771b520c265"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa3aabab-e510-4df1-86d7-cadb7e9b8a54"), true, "en", "Vinyl" },
                    { new Guid("e4023573-08d9-47a3-b35c-7bbdad0016f0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa3aabab-e510-4df1-86d7-cadb7e9b8a54"), true, "fr", "Vinyle" },
                    { new Guid("8c9d3d7f-1d2e-48b4-8b26-bd9c495f5cd4"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a2fdec1-5e2d-4868-958f-747ec719a888"), true, "en", "Concrete" },
                    { new Guid("9b5fb7d1-bade-41ba-8d5a-1fa541272636"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a2fdec1-5e2d-4868-958f-747ec719a888"), true, "fr", "Béton" },
                    { new Guid("cafe52e4-271c-4281-b647-9afb47308e2f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ee73750-2034-4bcb-84e2-52c87b7cf47c"), true, "fr", "Brique" },
                    { new Guid("7f0a6e34-f5ee-427b-8935-71e6c87f068a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("947c3969-430b-4ee3-9453-b24ca1a35a9c"), true, "fr", "Stucco" },
                    { new Guid("98f8304c-468e-44a6-a44f-ab24508292c0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d951897a-949f-4b80-9208-1b3b340c82c6"), true, "en", "Stone" }
                });

            migrationBuilder.InsertData(
                table: "sprinkler_type_localization",
                columns: new[] { "id", "created_on", "id_sprinkler_type", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("704c4f7e-c3ea-473f-b9b7-6237e9e85342"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2bcb05e1-5788-4beb-8395-07ec55c2ed60"), true, "en", "FM 200" },
                    { new Guid("536b74f4-21ca-46d5-a9dd-aa38c7f6ad98"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2bcb05e1-5788-4beb-8395-07ec55c2ed60"), true, "fr", "FM 200" },
                    { new Guid("b260a409-897b-4007-af26-9ed430f59138"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("758e5835-deeb-4167-8732-be9d2c338968"), true, "fr", "Système sous eau" },
                    { new Guid("ee1b31da-1539-40ef-92e7-aa1d69075dc5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("758e5835-deeb-4167-8732-be9d2c338968"), true, "en", "Wet pipe" },
                    { new Guid("faf15cd3-ce59-4aa5-aff1-982900aa96c5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90a001d9-1348-47cd-b44e-ac2a0484cd57"), true, "fr", "Système sous air" },
                    { new Guid("7ea70243-8935-40d4-b843-a82cc6b10be1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90a001d9-1348-47cd-b44e-ac2a0484cd57"), true, "en", "Dry pipe" },
                    { new Guid("a5c30a93-8ff4-4778-9be3-3c1e522e35c1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2cdd734c-0ffe-4c39-b874-59f1743db693"), true, "fr", "Pré action" },
                    { new Guid("3763b5b8-8f8a-404d-9323-43c809d99975"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2cdd734c-0ffe-4c39-b874-59f1743db693"), true, "en", "Pre-Action" },
                    { new Guid("51412199-75c8-4a31-bb9b-17bd0251b296"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f745efd4-3851-4440-9502-15eb1fcf4b40"), true, "fr", "Déluge" },
                    { new Guid("8f170e4b-8ea1-4943-9da7-5b7dd64af268"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f745efd4-3851-4440-9502-15eb1fcf4b40"), true, "en", "Deluge" },
                    { new Guid("e8ed792d-aa4f-48f4-bfe8-ac0079abad26"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f0da61b-8bbd-4f79-927a-e2a98a87ca3d"), true, "fr", "Mousse" },
                    { new Guid("d13f78bb-c98c-4778-84a3-675e2decd875"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f0da61b-8bbd-4f79-927a-e2a98a87ca3d"), true, "en", "Foam" }
                });

            migrationBuilder.InsertData(
                table: "unit_of_measure_localization",
                columns: new[] { "id", "created_on", "id_parent", "is_active", "language_code", "name" },
                values: new object[,]
                {
                    { new Guid("2dfd45bb-3f3e-4f27-b71e-11dd1a0718ce"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1d79513f-faeb-4bc8-801d-964dd07afa10"), true, "fr", "Pieds cubes" },
                    { new Guid("0755bd90-d621-42aa-85bc-b7a44177aaf2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1ca6d9b-0808-4add-a609-ed50ca8cd23c"), true, "en", "US tons" },
                    { new Guid("1d484b28-1cd4-4943-ad4d-b2253443aa6d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1ca6d9b-0808-4add-a609-ed50ca8cd23c"), true, "fr", "Tonnes US" },
                    { new Guid("b0a5d1b1-d474-487e-8edc-e8375dd20117"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6414f1c7-73a7-434b-9217-caba747ec10e"), true, "en", "Tons" },
                    { new Guid("ac20811f-493a-4ed9-aa83-7dc114f7888d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6414f1c7-73a7-434b-9217-caba747ec10e"), true, "fr", "Tonnes" },
                    { new Guid("c5831049-3947-45b8-8410-760e4c057dfc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db98476e-04bf-4502-9a0a-6e4a14797915"), true, "en", "Cubic inches" },
                    { new Guid("a2da656a-d18f-4ec2-a8ea-9e8d77be4e3e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef8f06ac-6718-489b-b833-eb0b24926812"), true, "fr", "Pintes" },
                    { new Guid("f24d5ff3-1be5-46b1-9263-a19781042fd5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb9d70c4-3b1b-4c84-99dd-684700e84484"), true, "en", "Millilitre" },
                    { new Guid("d32460bb-1ee8-4e91-b39c-7a235a1e15ed"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb9d70c4-3b1b-4c84-99dd-684700e84484"), true, "fr", "Millilitres" },
                    { new Guid("bb8866b5-5fc2-435a-a9ce-90975cf8cf64"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db98476e-04bf-4502-9a0a-6e4a14797915"), true, "fr", "Pouces cubes" },
                    { new Guid("7679719f-a90d-4b5e-ab1e-7306b9a79412"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a29dd195-53b0-4e5f-857d-6236f6faf588"), true, "en", "Cubic meters" },
                    { new Guid("a6fae969-1e74-4843-b473-917b3090c710"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef8f06ac-6718-489b-b833-eb0b24926812"), true, "en", "Pints" },
                    { new Guid("13fe2a8a-0fb6-422f-b342-f2422338d821"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1d79513f-faeb-4bc8-801d-964dd07afa10"), true, "en", "Cubic feet" },
                    { new Guid("d826bae7-bac3-445d-b6d9-1560b060f72b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47d931ed-da80-4643-b7ce-1a32fc86366d"), true, "en", "None" },
                    { new Guid("7fce8abf-8b56-45ff-9bb2-bf0698d748de"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("556b2773-cd90-413c-a666-a8825a0cc2a3"), true, "en", "Imperial gallons" },
                    { new Guid("6c2e8bc0-aa97-4097-b1ae-a772f7f992c5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47d931ed-da80-4643-b7ce-1a32fc86366d"), true, "fr", "Aucune" },
                    { new Guid("ace3489e-af53-4b38-ae18-e0ce84473ccf"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18ac17a4-623a-404f-a8e3-ffe8e0d5436b"), true, "en", "Pounds" },
                    { new Guid("44a11937-a9c1-4f46-b426-bea5e4492cd5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0a89ee7d-1205-4e9b-ac34-5231df0477cb"), true, "fr", "Gallons US" },
                    { new Guid("16674fc7-89f4-408c-bc33-7d77b20d6d8b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0a89ee7d-1205-4e9b-ac34-5231df0477cb"), true, "en", "US gallons" },
                    { new Guid("ff8ae4c7-bea2-4034-9835-d7faf2475a9d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d2f7d529-f330-44f7-a522-c1248fd0f68d"), true, "fr", "Grammes" },
                    { new Guid("895c3f09-52a8-4876-bca0-5c5b1b9b80e3"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d2f7d529-f330-44f7-a522-c1248fd0f68d"), true, "en", "Grams" },
                    { new Guid("0a18ecff-62e4-45bd-9570-8b8f46ee2498"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2974a84-ed50-4660-85d0-39d7d394d308"), true, "fr", "Kilos" },
                    { new Guid("d9641dee-cd87-4cc4-af35-26b19e97ec5a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2974a84-ed50-4660-85d0-39d7d394d308"), true, "en", "Kilos" },
                    { new Guid("0e369bef-bd66-4f4c-b827-c2b3c706701f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa616ff7-f819-497c-a80b-e0adf04f4b40"), true, "fr", "Litres" },
                    { new Guid("f1b0b099-259f-4276-86af-7f87998a33f6"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa616ff7-f819-497c-a80b-e0adf04f4b40"), true, "en", "Litres" },
                    { new Guid("e0acfa33-b725-40e6-9010-051cd13e2160"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18ac17a4-623a-404f-a8e3-ffe8e0d5436b"), true, "fr", "Livres" },
                    { new Guid("a9bc22e3-ae2e-4f37-b1a2-cbf7f9f57b29"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a29dd195-53b0-4e5f-857d-6236f6faf588"), true, "fr", "Mètres cubes" },
                    { new Guid("0b926f99-3046-4780-8ed7-f69e692e49a1"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("556b2773-cd90-413c-a666-a8825a0cc2a3"), true, "fr", "Gallons impériaux" },
                    { new Guid("f5c1bc3c-9220-4a54-9b37-40823c988460"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ada51f7e-2aef-4879-99e2-cd11fe8ca93b"), true, "en", "Feet" },
                    { new Guid("e672cde8-4751-476a-85bd-63286429c26e"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3015ac3e-43c5-4b74-9b3d-6f4cec3d1409"), true, "en", "L" },
                    { new Guid("c9cc27ce-653c-4846-8a7c-dad6d8e1761c"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("900edc6d-7658-46d6-a696-77b57e32a3c7"), true, "en", "Meters" },
                    { new Guid("5d20c6a6-da86-4db5-a40c-3249ad9e5a66"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("01952575-4d87-4bc2-a087-b4b5ec2cb979"), true, "fr", "Onces" },
                    { new Guid("a5adc39c-87db-47ba-b9f3-b7ca57b1cc64"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f4f46acc-3aa5-4a77-9a75-25d66c23a917"), true, "fr", "GIPM" },
                    { new Guid("e62794be-4dd3-47e2-a24c-57daadc8e798"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f4f46acc-3aa5-4a77-9a75-25d66c23a917"), true, "en", "GIPM" },
                    { new Guid("58e46d9b-2c54-4f6f-bc85-e82002cd28e5"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("96801d59-e01e-4219-a918-0a570a174b74"), true, "fr", "GPM" },
                    { new Guid("c25b755f-1a2e-40c8-8d72-8412d3e91fec"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("96801d59-e01e-4219-a918-0a570a174b74"), true, "en", "GPM" },
                    { new Guid("d4e10a5f-a2d1-4e00-aeec-11e33576f13a"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("14ea0d1c-a434-47d1-ba17-57967e79b4c9"), true, "fr", "LPM" },
                    { new Guid("9238cdd2-dd75-4f64-b2c0-063a3df56f25"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("14ea0d1c-a434-47d1-ba17-57967e79b4c9"), true, "en", "LPM" },
                    { new Guid("ff23e766-ab8a-4019-a4da-9e5dcda63bb8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("845d7bb3-6554-441d-bf41-6ec003598f20"), true, "fr", "GI" },
                    { new Guid("7ddf2111-9497-49fa-a57e-ddcb776858cb"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("845d7bb3-6554-441d-bf41-6ec003598f20"), true, "en", "GI" },
                    { new Guid("0cd5110a-f0a7-4a46-b650-c028cc23731f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ac84278-7606-4cb9-bc5a-9bdc3a8fb9d0"), true, "fr", "G" },
                    { new Guid("6b257f96-5e76-4427-a648-53c7b7eaef93"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ada51f7e-2aef-4879-99e2-cd11fe8ca93b"), true, "fr", "Pieds" },
                    { new Guid("c6aabfee-0d80-42f5-8157-a23afcf848fe"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3015ac3e-43c5-4b74-9b3d-6f4cec3d1409"), true, "fr", "L" },
                    { new Guid("0c771b77-b0ba-4a6a-890c-b83e9d89bad0"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ac84278-7606-4cb9-bc5a-9bdc3a8fb9d0"), true, "en", "G" },
                    { new Guid("1422ae64-85db-47cc-a647-20753f0fe420"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6b0949f-d056-4aa9-8281-d6f93941369a"), true, "en", "Unknown" },
                    { new Guid("8a152e9e-cceb-4ddc-b8ba-065ca99143a2"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("900edc6d-7658-46d6-a696-77b57e32a3c7"), true, "fr", "Mètres" },
                    { new Guid("2dad6387-b63f-4f64-ac17-96f168755a58"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("71feff9f-c32d-44e6-82a8-b86b82d64bb5"), true, "en", "Inches" },
                    { new Guid("44034780-45d9-4ec6-b77c-c94b199e945b"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("71feff9f-c32d-44e6-82a8-b86b82d64bb5"), true, "fr", "Pouces" },
                    { new Guid("8d7c21db-320b-449d-a55a-781f97c26dd8"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6b0949f-d056-4aa9-8281-d6f93941369a"), true, "fr", "Indéterminé" },
                    { new Guid("25a3a165-49c3-4a17-881a-aa650f1c27dc"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("32d7e795-31e6-4b07-9784-c2de1c63980d"), true, "fr", "Millimètres" },
                    { new Guid("bd915193-bc2a-4821-9161-ed95f8c497ad"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("32d7e795-31e6-4b07-9784-c2de1c63980d"), true, "en", "Millimeters" },
                    { new Guid("30376b32-e5a2-431e-b9ee-1cc74a15f49f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f45f2f3-cd97-4ba4-a17c-f191df34ee4a"), true, "fr", "m3/h" },
                    { new Guid("3ff72c23-0049-43fe-8a5c-93affe13051d"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2ee63245-6a57-4c01-8746-b10acc473b1a"), true, "en", "KPA" },
                    { new Guid("b3f79de8-8b91-4010-9151-2dc43ed94123"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2ee63245-6a57-4c01-8746-b10acc473b1a"), true, "fr", "KPA" },
                    { new Guid("f9bb8fae-f8c3-4971-be25-7082804e016f"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5a9dd30-c345-496e-8669-ca9f09295878"), true, "en", "PSI" },
                    { new Guid("41150af7-9750-4808-ab4f-1b52e61a3ca9"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5a9dd30-c345-496e-8669-ca9f09295878"), true, "fr", "PSI" },
                    { new Guid("f3fd4d74-85f4-425a-a0e2-98ae50025db7"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f45f2f3-cd97-4ba4-a17c-f191df34ee4a"), true, "en", "m3/h" },
                    { new Guid("f4aa0d84-6f2f-4ea7-bfa9-3c44bb486c53"), new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("01952575-4d87-4bc2-a087-b4b5ec2cb979"), true, "en", "Onces" }
                });

            migrationBuilder.InsertData(
                table: "webuser_attributes",
                columns: new[] { "id", "attribute_name", "attribute_value", "id_webuser" },
                values: new object[,]
                {
                    { new Guid("4c55d7dd-ee76-473b-be0d-4d8ec7cb3e10"), "first_name", "Admin", new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b") },
                    { new Guid("aa8b3277-1717-456e-bafb-e5752dcc5e12"), "reset_password", "false", new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b") },
                    { new Guid("f90d28fd-4069-4c6a-af1c-fc08f416a1fe"), "last_name", "Cauca", new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b") }
                });

            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "id", "access", "comments", "created_on", "id_permission_object", "id_permission_system", "id_permission_system_feature" },
                values: new object[,]
                {
                    { new Guid("de5c78f3-4123-4807-938a-99e623a55851"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("98075263-e986-4823-aa11-cfca837adcbc") },
                    { new Guid("7da38ff6-de80-4754-b9f6-aff4d7d89d18"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("89dbc380-186b-440c-a069-bd42d0664ed8") },
                    { new Guid("7f2eea9e-c182-4ea1-996d-97ce53f39254"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749") },
                    { new Guid("e9ed4961-ed94-4121-b0d5-8de86f708236"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("1864a414-64a3-4f67-9556-059ad9c5a672") },
                    { new Guid("f3878fca-4056-453f-80d3-6a2f8004c9a1"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("b38a094f-b0a6-494b-9104-009d30199cbf") },
                    { new Guid("f4ec1514-3298-4fd2-b2ed-042d79272ccc"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("78b19b2a-f31b-4027-8b92-105a0ac44282") },
                    { new Guid("35f99f12-af9f-460b-8b27-63be4a326699"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("d68c1911-e063-4b22-a635-413004d3bd60") },
                    { new Guid("cb28d006-1d03-4db9-836e-205876d5ba48"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("62982bdc-2ae9-407b-9396-01bfb3c50d23") },
                    { new Guid("b35943a3-3b7c-4cc4-af82-8a5c7271f611"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("193ab58d-0a0f-48d5-bb65-6a2d67db58c4") },
                    { new Guid("5fe3c4f5-6b71-4c11-97ea-7264ed5c37ee"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("08dfbdb1-6cf4-449b-85e3-8134de4ed052") },
                    { new Guid("40d5f714-f0cd-4ebd-813d-96c79c724517"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("8a9896a5-0ab5-4c33-a01f-7e97742c9570") },
                    { new Guid("a9fc0734-99ad-4f95-8c49-760ddcba6e62"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd") },
                    { new Guid("53560ea6-e0bd-46d9-bc06-66823d5091f6"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("2dfaae63-39a2-471c-9a42-705cba52c565") },
                    { new Guid("86f8f414-30fc-4972-9006-37b051117aa2"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("4e5be439-7249-4f7c-b9c1-e0a448046c57") },
                    { new Guid("8a7ea586-c5ad-4881-869a-90ef73804f8f"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("6da8395e-4057-415c-9710-ea098fdf2e9e") },
                    { new Guid("243272d7-e069-4cef-a377-25e8e7d02e4e"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("e8c4cc98-7e17-450b-8333-9d87cd8f695a") },
                    { new Guid("f131976a-07cd-42bc-8a2c-ee7c8f20e5a9"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("9898d805-e8ef-4595-a0d2-66d1b022ea86") },
                    { new Guid("ce91dc37-a08e-4f4f-863b-f793fc992092"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("26d14cda-d321-4db2-a604-6daaff0483e9") },
                    { new Guid("54af869b-e07f-4845-b5f9-d12683a9ccf6"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b") },
                    { new Guid("e7441fbb-77e0-424c-bd79-c7e04cd83f34"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2") },
                    { new Guid("aee63ddd-b33e-4904-b453-9dde916fce6d"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2") },
                    { new Guid("17a95e77-6763-481a-b53d-c4372cb1db62"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("0615bbba-ae42-472b-b768-227b80efd4f1") },
                    { new Guid("1cc19dbd-6cf3-47cb-b718-07340e8cd0b6"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162") },
                    { new Guid("d2794eb1-aba7-4326-98a8-a1ec1385790f"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843") },
                    { new Guid("88bbb9fc-0ec9-43b1-a3fd-3ab40efd3122"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780") },
                    { new Guid("100f6d6e-3320-4b8e-b314-aab14c61d41f"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b") },
                    { new Guid("8002ec95-24ba-4c0a-984d-3262031669f6"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("05d57316-7b0a-4195-bfdb-796262d4128a") },
                    { new Guid("7db5bb12-37d0-4587-b8fe-e10c64e22fd8"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d") },
                    { new Guid("82f426ea-9488-4f5e-bab4-0b1e2e43cbff"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60") },
                    { new Guid("b78e99ed-b653-4192-80f4-f1e9d3c6b454"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60") },
                    { new Guid("c643389a-3e12-445d-813e-19b0451bdda9"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4") },
                    { new Guid("66a210e8-4ad6-42e8-96b5-1f54ef91d6f4"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4") },
                    { new Guid("e0341e26-d2a1-4adb-a2b3-5425dc0c4937"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43") },
                    { new Guid("5d5011ec-048a-4ea7-8588-ca7287dbd137"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("aa163670-487c-461e-8112-9bf98070f5b3") },
                    { new Guid("3d46a013-93b7-4094-be7a-8c1810ccb7ae"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("aa163670-487c-461e-8112-9bf98070f5b3") },
                    { new Guid("bcbdce89-ab74-44ef-82ca-6e57728fa696"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43") },
                    { new Guid("e7aa95d5-8ec2-4e2c-972a-a2a903c74c77"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43") },
                    { new Guid("f11ccda4-779c-4231-8517-815f4938992b"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465") },
                    { new Guid("1309a734-a7a2-4b82-a80c-c07b6b7850e5"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("0615bbba-ae42-472b-b768-227b80efd4f1") },
                    { new Guid("651a2ccd-10a7-47a6-9d0a-91b81ac19e16"), true, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), new Guid("98075263-e986-4823-aa11-cfca837adcbc") }
                });

            migrationBuilder.InsertData(
                table: "permission_object",
                columns: new[] { "id", "generic_id", "group_name", "id_permission_object_parent", "id_permission_system", "is_group", "object_table" },
                values: new object[] { new Guid("e325886d-e950-4067-ad8f-847de181dcd0"), "0540e8f7-dc44-4b2f-8e42-5004cca3700b", "", new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4c0b5365-c308-4bb6-b412-36b22eea59a4"), false, "webuser" });

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
