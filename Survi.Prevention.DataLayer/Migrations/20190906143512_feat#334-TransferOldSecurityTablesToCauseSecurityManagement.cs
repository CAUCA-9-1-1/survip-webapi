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
				      is_active
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
		}
	}
}
