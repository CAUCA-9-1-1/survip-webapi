using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Survi.Prevention.DataLayer.Migrations
{
	public partial class feat334TransferOldSecurityTablesToCauseSecurityManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("06ffc22d-a4be-4f82-be8c-e16c7af7d545"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("1af5197a-8ace-40f0-bf7c-48bba2eb3d60"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("2cbb34de-f16f-43ee-867d-e08a563dd933"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("32790928-3c71-4b47-8c17-f0fdf8f6b581"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("450e7c38-d7df-4c11-a94d-374ecdb02055"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("4933e10e-8e28-48af-9274-79be3bd73280"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("495197bb-9c4a-4ab9-9406-422f4dcf0067"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("4b6f558e-e01c-4021-882e-844316bd2733"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("55052fb1-2255-498e-8357-1a80cf78a9f5"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("56e2527f-3756-483b-a73f-64941b4bb3c2"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("5dd530fd-cd76-410b-831f-e5e622873adc"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("5fac4dd5-cf70-43a6-90b1-1aadf658b648"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("64932c3a-f076-478b-bff2-7e3ad0be0d78"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("6beff07d-4e88-4cb3-8949-efe28464f758"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("78fc2ced-6991-48cc-b4be-136eea1a1c5f"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("872ea6b1-dea4-4659-8565-80377b9db400"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("8d54e7b7-cb3b-46f0-941f-f0b9096aeec3"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("8d6b8a38-68ac-495b-acb1-cafb6a01477d"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("99a6f22f-abc8-49e7-8f24-b9dea748bc3b"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("ad24a65f-591d-46b7-8171-435ae682ad33"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("b0d43ffe-d193-47b4-a642-c42afec0ac62"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("bad368be-56e3-43ce-a044-0648ab74d76a"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("badc1374-3ff0-4435-ab26-d2a47fa71b23"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("bb932956-fdc2-4a64-927a-23c0de9aa474"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("bff55537-0be7-45af-8a67-2c7c4a0ae4f6"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("ca32c7a0-6b4d-44cb-8a3e-98fbbad6946a"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("cd5b0c7b-aa7b-4f86-9272-914c0bf7dcde"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("d0a8770c-2f0a-4e1f-9e69-9cbd39f3df83"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("da274395-1694-4f6d-a84a-ef992e631b79"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("e01f7e53-2ab0-469a-82ef-c0ce10107dcf"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("ea2d7d77-ea60-4d71-9d5e-59213d674992"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("f1167645-adad-4a71-84c6-3d844e46718b"));

            migrationBuilder.DeleteData(
                table: "group_permission",
                keyColumn: "id",
                keyValue: new Guid("f93526e7-6ab0-4777-9410-a17725516d7c"));

            migrationBuilder.DeleteData(
                table: "user_group",
                keyColumn: "id",
                keyValue: new Guid("de8f5b33-4c45-414c-8802-b75e83794e72"));

            migrationBuilder.DeleteData(
                table: "group",
                keyColumn: "id",
                keyValue: new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b"));

            migrationBuilder.Sql(@"
				--add users
				insert into ""user"" (id, user_name, first_name, last_name, password, email, is_active)
				select id,
				       username,
				       (SELECT attribute_value from webuser_attributes where id_webuser = webuser.id and attribute_name = 'first_name' limit 1) as first_name,
				       (SELECT attribute_value from webuser_attributes where id_webuser = webuser.id and attribute_name = 'last_name' limit 1) as last_name,
				       password,
				      COALESCE((SELECT attribute_value from webuser_attributes where id_webuser = webuser.id and attribute_name = 'email' limit 1),'') as email,
				      is_active,
				from webuser;
				--add groups
				insert into ""group"" (id, name)
				select id, group_name as name
				from permission_object
				where is_group = true;

				--add user in group
				insert into user_group (id, id_user, id_group)
				select CAST(id as uuid ), CAST(generic_id as uuid) as id_user, CAST(id_permission_object_parent as uuid) as id_group
				from permission_object
				where is_group = false and id_permission_object_parent is not null and generic_id is not null;

				--add groups permissions
				insert into group_permission (id, is_allowed, id_module_permission, id_group)
				select CAST(id as uuid ), access as is_allowed,
				       CAST(id_permission_system_feature as uuid)as id_module_permission,
				       CAST(id_permission_object as uuid) as id_group
				from permission
				where id_permission_object=ANY(select id from permission_object where is_group = true) ;

				--add user permissions
				insert into user_permission (id, is_allowed, id_module_permission, id_user)
				select CAST(id as uuid ), access as is_allowed,
				       CAST(id_permission_system_feature as uuid)as id_module_permission,
				       CAST((select generic_id from permission_object where id = permission.id_permission_object) as uuid) as id_user
				from permission
				where id_permission_object=ANY(select id from permission_object where is_group = false);
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
                table: "group",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), "Administration" },
                    { new Guid("aa69bf4d-d9ef-4f33-8c09-dfb2b48c06c1"), "Pompier" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "first_name", "is_active", "last_name", "password", "user_name" },
                values: new object[] { new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b"), "dev@cause911.ca", "Dev", true, "Cause", "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247", "admin" });

            migrationBuilder.InsertData(
                table: "group_permission",
                columns: new[] { "id", "id_group", "id_module_permission", "is_allowed" },
                values: new object[,]
                {
                    { new Guid("64932c3a-f076-478b-bff2-7e3ad0be0d78"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("2cba3c2f-4d78-4294-853d-9c5f0c0d5162"), true },
                    { new Guid("450e7c38-d7df-4c11-a94d-374ecdb02055"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("26d14cda-d321-4db2-a604-6daaff0483e9"), true },
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
                    { new Guid("4933e10e-8e28-48af-9274-79be3bd73280"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("314b0c77-b8e7-411c-9002-3a56a54f6749"), true },
                    { new Guid("495197bb-9c4a-4ab9-9406-422f4dcf0067"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("89dbc380-186b-440c-a069-bd42d0664ed8"), true },
                    { new Guid("e01f7e53-2ab0-469a-82ef-c0ce10107dcf"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4b920789-e3bf-4b8c-a1fe-a09128e30843"), true },
                    { new Guid("4b6f558e-e01c-4021-882e-844316bd2733"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("f7bf8f9a-768e-4570-bddc-7cff2c1f1780"), true },
                    { new Guid("8d54e7b7-cb3b-46f0-941f-f0b9096aeec3"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("4a679efb-16d7-4b67-8cf5-0f1d1da8733b"), true },
                    { new Guid("d0a8770c-2f0a-4e1f-9e69-9cbd39f3df83"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("05d57316-7b0a-4195-bfdb-796262d4128a"), true },
                    { new Guid("2cbb34de-f16f-43ee-867d-e08a563dd933"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("1f350fa7-60a5-4b8c-9696-d2331545012d"), true },
                    { new Guid("32790928-3c71-4b47-8c17-f0fdf8f6b581"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("c21611c3-e1b2-4d74-a7df-7503ca7fda60"), true },
                    { new Guid("99a6f22f-abc8-49e7-8f24-b9dea748bc3b"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("612b33fa-7209-4bd1-a21a-fa610d73f4d2"), true },
                    { new Guid("bff55537-0be7-45af-8a67-2c7c4a0ae4f6"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("b104208c-f7a9-4f70-b414-5352b55fb7c4"), true },
                    { new Guid("872ea6b1-dea4-4659-8565-80377b9db400"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("aa163670-487c-461e-8112-9bf98070f5b3"), true },
                    { new Guid("5fac4dd5-cf70-43a6-90b1-1aadf658b648"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("c4237a41-fbf3-481b-aa18-a7e469331c43"), true },
                    { new Guid("da274395-1694-4f6d-a84a-ef992e631b79"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("33f4995e-d5cb-45cb-91a3-7b60c07f7465"), true },
                    { new Guid("bad368be-56e3-43ce-a044-0648ab74d76a"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("0615bbba-ae42-472b-b768-227b80efd4f1"), true },
                    { new Guid("78fc2ced-6991-48cc-b4be-136eea1a1c5f"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("98075263-e986-4823-aa11-cfca837adcbc"), true },
                    { new Guid("bb932956-fdc2-4a64-927a-23c0de9aa474"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("3614fb19-6ce4-4322-b8dc-8cdd2b187a0b"), true },
                    { new Guid("cd5b0c7b-aa7b-4f86-9272-914c0bf7dcde"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("1257e63b-b40a-4410-a9ce-00d8d0abdf43"), true }
                });

            migrationBuilder.InsertData(
                table: "user_group",
                columns: new[] { "id", "id_group", "id_user" },
                values: new object[] { new Guid("de8f5b33-4c45-414c-8802-b75e83794e72"), new Guid("98db62c4-51b1-492e-b616-cfbd3ff53875"), new Guid("0540e8f7-dc44-4b2f-8e42-5004cca3700b") });
        }
    }
}
