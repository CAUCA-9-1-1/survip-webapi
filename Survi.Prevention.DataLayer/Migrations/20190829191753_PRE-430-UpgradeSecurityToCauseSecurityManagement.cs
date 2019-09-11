using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Survi.Prevention.DataLayer.Migrations
{
	public partial class PRE430UpgradeSecurityToCauseSecurityManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_objectives_fire_safety_departments_fire_safety_department_id",
                table: "objectives");

            migrationBuilder.CreateTable(
                name: "data_protection_element",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    xml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_data_protection_element", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user_name = table.Column<string>(maxLength: 100, nullable: false),
                    first_name = table.Column<string>(maxLength: 100, nullable: false),
                    last_name = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
					phone_number = table.Column<string>(nullable:true),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    tag = table.Column<string>(maxLength: 100, nullable: false),
                    id_module = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_module_permission_module_module_id",
                        column: x => x.id_module,
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_fire_safety_department",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    fire_safety_department_id = table.Column<string>(nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_fire_safety_department", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_fire_safety_department_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_group",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false),
                    id_group = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_group", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_group_group_group_id",
                        column: x => x.id_group,
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_group_users_user_id",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    access_token = table.Column<string>(maxLength: 500, nullable: false),
                    refresh_token = table.Column<string>(maxLength: 100, nullable: false),
                    expires_on = table.Column<DateTime>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_token_users_user_id",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    is_allowed = table.Column<bool>(nullable: false),
                    id_module_permission = table.Column<Guid>(nullable: false),
                    id_group = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_group_permission_group_group_id",
                        column: x => x.id_group,
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_group_permission_module_permissions_permission_id",
                        column: x => x.id_module_permission,
                        principalTable: "module_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    is_allowed = table.Column<bool>(nullable: false),
                    id_module_permission = table.Column<Guid>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_permission_module_permission_permission_id",
                        column: x => x.id_module_permission,
                        principalTable: "module_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_permission_users_user_id",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "group",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), "Administration" },
                    { new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), "Pompier" }
                });

            migrationBuilder.InsertData(
                table: "module",
                columns: new[] { "id", "name", "tag" },
                values: new object[] { new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "SURVI-Prevention", "SURVIPrevention" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "first_name", "is_active", "last_name", "password", "user_name" },
                values: new object[] { new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b"), "dev@cause911.ca", "Dev", true, "Cause", "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247", "admin" });

            migrationBuilder.InsertData(
                table: "module_permission",
                columns: new[] { "id", "id_module", "name", "tag" },
                values: new object[,]
                {
                    { new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès au tableau de bord", "url-inspection-dashboard" },
                    { new Guid("26d14cda-d321-4db2-a604-6daaff0483e9"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des SSI", "RightDepartmentManagement" },
                    { new Guid("9898d805-e8ef-4595-a0d2-66d1b022ea86"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des niveaux de risque par SSI", "RightDepartmentRiskLevel" },
                    { new Guid("e8c4cc98-7e17-450b-8333-9d87cd8f695a"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des matières dangereuses", "RightHazardousMaterialManagement" },
                    { new Guid("6da8395e-4057-415c-9710-ea098fdf2e9e"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des types de PNAPs", "RightRPATypeManagement" },
                    { new Guid("4e5be439-7249-4f7c-b9c1-e0a448046c57"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des codes d'utilisation", "RightUtilisationCodeManagement" },
                    { new Guid("2dfaae63-39a2-471c-9a42-705cba52c565"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des niveaux de risque", "RightRiskLevelManagement" },
                    { new Guid("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des villes", "RightCityManagement" },
                    { new Guid("8a9896a5-0ab5-4c33-a01f-7e97742c9570"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des types de ville", "RightCityTypeManagement" },
                    { new Guid("08dfbdb1-6cf4-449b-85e3-8134de4ed052"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des pays", "RightCountryManagement" },
                    { new Guid("193ab58d-0a0f-48d5-bb65-6a2d67db58c4"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des provinces/états", "RightStateManagement" },
                    { new Guid("62982bdc-2ae9-407b-9396-01bfb3c50d23"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des régions", "RightRegionManagement" },
                    { new Guid("d68c1911-e063-4b22-a635-413004d3bd60"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des comtés", "RightCountyManagement" },
                    { new Guid("78b19b2a-f31b-4027-8b92-105a0ac44282"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des unités de mesure", "RightUnitManagement" },
                    { new Guid("b38a094f-b0a6-494b-9104-009d30199cbf"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des opérateurs", "RightOperatorManagement" },
                    { new Guid("1864a414-64a3-4f67-9556-059ad9c5a672"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des types de connexion", "RightConnectionTypeManagement" },
                    { new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des types de bornes", "RightFireHydrantTypeManagement" },
                    { new Guid("89dbc380-186b-440c-a069-bd42d0664ed8"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des utilisateurs", "RightUserManagement" },
                    { new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès aux statistiques", "url-statistics" },
                    { new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion des rapports", "url-report-configuration" },
                    { new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion système", "url-management-system" },
                    { new Guid("05d57316-7b0a-4195-bfdb-796262d4128a"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion des types du système", "url-management-typesystem" },
                    { new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion des questionnaires", "url-management-survey" },
                    { new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion des villes", "url-management-address" },
                    { new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des bornes", "RightFireHydrantManagement" },
                    { new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès à la gestion du SSI", "url-management-department" },
                    { new Guid("aa163670-487c-461e-8112-9bf98070f5b3"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Acception des inspections", "RightApproveInspection" },
                    { new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des lots", "RightBatchManagement" },
                    { new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des casernes", "RightFireStationManagement" },
                    { new Guid("0615bbba-ae42-472b-b768-227b80efd4f1"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des voies", "RightLaneManagement" },
                    { new Guid("98075263-e986-4823-aa11-cfca837adcbc"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des bâtiments", "RightBuildingManagement" },
                    { new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Gestion des permissions", "RightPermissionManagement" },
                    { new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), new Guid("1c365d12-a809-11e9-9916-525400cc3eb9"), "Accès au mobile", "RightMobile" }
                });

            migrationBuilder.InsertData(
                table: "user_group",
                columns: new[] { "id", "id_group", "id_user" },
                values: new object[] { new Guid("de8f5b33-4c45-414c-8802-b75e83794e72"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b") });

            migrationBuilder.InsertData(
                table: "group_permission",
                columns: new[] { "id", "id_group", "id_module_permission", "is_allowed" },
                values: new object[,]
                {
                    { new Guid("64932c3a-f076-478b-bff2-7e3ad0be0d78"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), true },
                    { new Guid("1af5197a-8ace-40f0-bf7c-48bba2eb3d60"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("9898d805-e8ef-4595-a0d2-66d1b022ea86"), true },
                    { new Guid("ad24a65f-591d-46b7-8171-435ae682ad33"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("e8c4cc98-7e17-450b-8333-9d87cd8f695a"), true },
                    { new Guid("56e2527f-3756-483b-a73f-64941b4bb3c2"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("6da8395e-4057-415c-9710-ea098fdf2e9e"), true },
                    { new Guid("6beff07d-4e88-4cb3-8949-efe28464f758"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4e5be439-7249-4f7c-b9c1-e0a448046c57"), true },
                    { new Guid("ca32c7a0-6b4d-44cb-8a3e-98fbbad6946a"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("2dfaae63-39a2-471c-9a42-705cba52c565"), true },
                    { new Guid("b0d43ffe-d193-47b4-a642-c42afec0ac62"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("0afb3f9b-da1c-4625-a18e-d4f72c7ba0cd"), true },
                    { new Guid("5dd530fd-cd76-410b-831f-e5e622873adc"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("8a9896a5-0ab5-4c33-a01f-7e97742c9570"), true },
                    { new Guid("f1167645-adad-4a71-84c6-3d844e46718b"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("08dfbdb1-6cf4-449b-85e3-8134de4ed052"), true },
                    { new Guid("ea2d7d77-ea60-4d71-9d5e-59213d674992"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("193ab58d-0a0f-48d5-bb65-6a2d67db58c4"), true },
                    { new Guid("8d6b8a38-68ac-495b-acb1-cafb6a01477d"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("62982bdc-2ae9-407b-9396-01bfb3c50d23"), true },
                    { new Guid("f93526e7-6ab0-4777-9410-a17725516d7c"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("d68c1911-e063-4b22-a635-413004d3bd60"), true },
                    { new Guid("06ffc22d-a4be-4f82-be8c-e16c7af7d545"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("78b19b2a-f31b-4027-8b92-105a0ac44282"), true },
                    { new Guid("badc1374-3ff0-4435-ab26-d2a47fa71b23"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("b38a094f-b0a6-494b-9104-009d30199cbf"), true },
                    { new Guid("55052fb1-2255-498e-8357-1a80cf78a9f5"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("1864a414-64a3-4f67-9556-059ad9c5a672"), true },
                    { new Guid("450e7c38-d7df-4c11-a94d-374ecdb02055"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("26d14cda-d321-4db2-a604-6daaff0483e9"), true },
                    { new Guid("4933e10e-8e28-48af-9274-79be3bd73280"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749"), true },
                    { new Guid("bb932956-fdc2-4a64-927a-23c0de9aa474"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), true },
                    { new Guid("78fc2ced-6991-48cc-b4be-136eea1a1c5f"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("98075263-e986-4823-aa11-cfca837adcbc"), true },
                    { new Guid("bad368be-56e3-43ce-a044-0648ab74d76a"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("0615bbba-ae42-472b-b768-227b80efd4f1"), true },
                    { new Guid("da274395-1694-4f6d-a84a-ef992e631b79"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), true },
                    { new Guid("5fac4dd5-cf70-43a6-90b1-1aadf658b648"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43"), true },
                    { new Guid("872ea6b1-dea4-4659-8565-80377b9db400"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("aa163670-487c-461e-8112-9bf98070f5b3"), true },
                    { new Guid("cd5b0c7b-aa7b-4f86-9272-914c0bf7dcde"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), true },
                    { new Guid("bff55537-0be7-45af-8a67-2c7c4a0ae4f6"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4"), true },
                    { new Guid("32790928-3c71-4b47-8c17-f0fdf8f6b581"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), true },
                    { new Guid("2cbb34de-f16f-43ee-867d-e08a563dd933"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d"), true },
                    { new Guid("d0a8770c-2f0a-4e1f-9e69-9cbd39f3df83"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("05d57316-7b0a-4195-bfdb-796262d4128a"), true },
                    { new Guid("8d54e7b7-cb3b-46f0-941f-f0b9096aeec3"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), true },
                    { new Guid("4b6f558e-e01c-4021-882e-844316bd2733"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), true },
                    { new Guid("e01f7e53-2ab0-469a-82ef-c0ce10107dcf"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843"), true },
                    { new Guid("495197bb-9c4a-4ab9-9406-422f4dcf0067"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("89dbc380-186b-440c-a069-bd42d0664ed8"), true },
                    { new Guid("99a6f22f-abc8-49e7-8f24-b9dea748bc3b"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_group_permission_id_group",
                table: "group_permission",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_group_permission_id_module_permission",
                table: "group_permission",
                column: "id_module_permission");

            migrationBuilder.CreateIndex(
                name: "IX_module_permission_id_module",
                table: "module_permission",
                column: "id_module");

            migrationBuilder.CreateIndex(
                name: "ix_user_fire_safety_department_user_id",
                table: "user_fire_safety_department",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_id_group",
                table: "user_group",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_id_user",
                table: "user_group",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_id_module_permission",
                table: "user_permission",
                column: "id_module_permission");

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_id_user",
                table: "user_permission",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_user_token_id_user",
                table: "user_token",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "fk_objectives_fire_safety_department_fire_safety_department_id",
                table: "objectives",
                column: "id_fire_safety_department",
                principalTable: "fire_safety_department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_objectives_fire_safety_department_fire_safety_department_id",
                table: "objectives");

            migrationBuilder.DropTable(
                name: "data_protection_element");

            migrationBuilder.DropTable(
                name: "group_permission");

            migrationBuilder.DropTable(
                name: "user_fire_safety_department");

            migrationBuilder.DropTable(
                name: "user_group");

            migrationBuilder.DropTable(
                name: "user_permission");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "module_permission");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.AddForeignKey(
                name: "fk_objectives_fire_safety_departments_fire_safety_department_id",
                table: "objectives",
                column: "id_fire_safety_department",
                principalTable: "fire_safety_department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
