using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class UtilizationCode_Localization_DescriptionFieldRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "utilisation_code_localization",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("089d9146-c67d-48de-b2c1-ffb00bfc2a99"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("0bd9e144-1b09-41e6-88bd-fd454fad8342"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("0f05e403-e9be-4f45-93f3-ef6dda52e0ae"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("15375891-f145-4ceb-9978-d9ff84ea1822"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("17a0d69b-6a5f-423c-8a2b-c93c96ddd91a"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("2364ddf8-e5a6-4f3f-91ec-b1d55a1c523f"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("395e7d3b-e747-4faf-af42-936960ae513f"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("3d905da2-e08d-4e55-b024-2402e2572089"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("4eba70e7-1656-41d8-abaa-8f596bda3d85"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("5f4750a2-e4be-48b3-b427-e299947ac2c7"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("96830639-fc48-4673-b2ee-a2c6bdd9acfc"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("99e6098d-2de5-4dc7-811c-e324f1d5dd4b"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("a60472cc-a8ef-42c5-9a72-1baa46c1b96e"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("c27d8877-7b9f-4462-b20b-e71e2c2f963f"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("c54c1bcf-8e0e-4132-8de7-3a926f0d59d9"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("dd5d2540-df8d-4e42-81a1-dd09face8308"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("fc846456-2091-445d-bc85-da22069771d6"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("fe0216da-9b06-4f8d-b38f-4d91796ad4b3"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0197a327-0c6b-40fb-bae3-cbf0876ccd63"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("02df7115-99ed-4585-b34e-35646b447ec3"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0ed50d20-2ec8-4e9d-819a-d0f05ff293e7"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0f28243f-4fd0-4857-a3e0-61bcf4e195d7"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("116521e7-6fd3-4c81-af06-2b7a012f809a"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("1442ef04-ac2d-4330-a8e8-d6bced4f5b04"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("183ce7e6-200d-4343-9a87-e0e9f67c56ba"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("211872bb-6892-44aa-85c6-8590ca3306f4"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("2f682729-d11e-4a22-b577-4ba503f97e0c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("33b95a78-143d-44dc-93ff-3fc7bc3e1ad4"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("33e0126d-4f30-4491-bd9d-af3433a97a60"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("3b6330b2-85f2-4bdc-b195-22a312889585"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4a20f1ee-b37d-4018-8ecd-3f3120fd26da"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4cd1da4a-e4bb-497e-93da-3c4a632c7230"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4e4af5e0-4ed0-409b-8c86-da234ec01c07"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5b4aa5f4-d2a5-4be2-a8d2-3cb8d403f393"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c00c7d3-6a51-4d9b-80d2-840cae69ba68"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c2a4daa-1312-4b83-a5f5-a5287296330b"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c46efb6-eace-47e1-b3cb-94b6cadc40f3"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("61c6bed8-ed26-4041-8a3a-e7aff4d1498f"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("63e441f4-27bc-46bf-8288-01b8d92cd8c4"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("64d0478e-e61b-4749-92d4-1ecc2601cf82"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("659fc7f6-a843-4259-9693-b3d543791c3e"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("673b55cd-47df-40ad-b6da-4cde98e8fe3e"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6c7f0c2b-25ac-45a0-b619-e876cceef57a"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6e3765c2-a5f6-473c-97c2-7288340f7cf9"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6ffc76ff-1ee5-4ce0-8ffb-016ba900c10a"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("70119917-9313-4a41-9e23-a3090ae7ec1d"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("710dafbd-af2b-4a81-b838-b38fc4058485"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("72bd548d-a64c-4467-90cb-c7de605e08bf"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("76947afd-aabe-413c-b4c2-ab71864ec348"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("775be837-5312-47f7-b26a-183a20b849cc"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("78ea1f8b-8087-460c-bc51-5807d1b81f0f"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("7ef21a9e-2818-4e5c-a3a1-94182abb0f6e"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("861203af-8d7a-4263-866b-8093c5365f20"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("86211fe5-c32d-41a9-b2ca-7bb2b71c4822"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("8738ffff-6adc-4683-b2ad-385f2a9f6c21"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("92487acb-c039-40fe-b0f2-9e8b10c74055"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("97d7b645-b0ee-43bf-b4bc-9c8d7441e2ec"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9de3c5be-9151-4663-a43e-99ef16a7b044"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9f480514-00d4-4b14-82c8-81e77795b515"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9ff1ce81-b2fe-4890-8ec4-4a0c03748882"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a0e0125f-fea6-4119-a3d8-d944f49e1329"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a687ace6-6a27-441e-983f-11c3e85ce228"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a8a2d1bb-32f4-4486-b8a9-d81a7a4b440a"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("aa66b652-9333-4776-9024-36385cfaeb9c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ae9182dd-5ff2-48c3-8a2a-1ea01d177926"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("aef889a9-c2c1-402b-abfe-f5d6deac3e55"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b8632077-1760-4a11-ad0b-f1f5351bbafe"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b8d1ab4e-f374-4e09-b090-54d5a920fb8d"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b94dfb3c-bcaa-432e-911d-3dad09d0f917"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("bb955596-9fdb-46b4-be6c-a95d29891a29"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("bdcc94d9-7a15-4af0-8d0f-7beb7a329259"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("c121a6de-3ce1-4c52-8699-21673496512c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("d3b5160c-da84-44f2-8003-63121ab8b3fc"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("d9dcb3c3-81b7-46d2-ae2d-1e269a0fbf46"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("dd2720b7-5911-4f58-a2ae-c9649063fc45"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e0b56a99-7e6e-4dae-a873-f2ea76571394"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e183e9dd-d25c-4b86-880f-6d0785631476"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e19772e4-d798-4dce-aed1-d4658d6b001b"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ea46553d-0c9b-4619-8782-dd7d7587ff76"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("eacbbabc-35a0-4fba-8f75-9a3a700461f4"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ed0d9f99-6e1b-473d-965a-84ec85cbba1c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ed7222b0-aaa4-4190-ba68-f6ad1ae9a93d"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("efa9bcc1-1790-415f-a04b-ab54e9d5f266"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f237c131-bc90-49c7-9397-6e0c1944ed96"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f24472cc-9a41-46a3-b2ce-e3d8b078530c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f253087e-dc1a-4098-a2d4-6ba7312329df"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f3bc54f2-acc4-419f-954b-715486cd1dad"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f6632d1e-9c1a-460d-b9f5-2b28a16aa2f2"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("fd4a80a3-07eb-4c97-9a04-9d384041ff4c"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("fee1058f-84e6-4277-b11e-6ab1dfcdc774"),
                column: "created_on",
                value: new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "utilisation_code_localization",
                newName: "description");

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("089d9146-c67d-48de-b2c1-ffb00bfc2a99"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("0bd9e144-1b09-41e6-88bd-fd454fad8342"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("0f05e403-e9be-4f45-93f3-ef6dda52e0ae"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("15375891-f145-4ceb-9978-d9ff84ea1822"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("17a0d69b-6a5f-423c-8a2b-c93c96ddd91a"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("2364ddf8-e5a6-4f3f-91ec-b1d55a1c523f"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("395e7d3b-e747-4faf-af42-936960ae513f"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("3d905da2-e08d-4e55-b024-2402e2572089"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("4eba70e7-1656-41d8-abaa-8f596bda3d85"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("5f4750a2-e4be-48b3-b427-e299947ac2c7"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("96830639-fc48-4673-b2ee-a2c6bdd9acfc"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("99e6098d-2de5-4dc7-811c-e324f1d5dd4b"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("a60472cc-a8ef-42c5-9a72-1baa46c1b96e"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("c27d8877-7b9f-4462-b20b-e71e2c2f963f"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("c54c1bcf-8e0e-4132-8de7-3a926f0d59d9"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("dd5d2540-df8d-4e42-81a1-dd09face8308"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("fc846456-2091-445d-bc85-da22069771d6"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 206, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_generic_code",
                keyColumn: "id",
                keyValue: new Guid("fe0216da-9b06-4f8d-b38f-4d91796ad4b3"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 205, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0197a327-0c6b-40fb-bae3-cbf0876ccd63"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("02df7115-99ed-4585-b34e-35646b447ec3"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0ed50d20-2ec8-4e9d-819a-d0f05ff293e7"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("0f28243f-4fd0-4857-a3e0-61bcf4e195d7"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("116521e7-6fd3-4c81-af06-2b7a012f809a"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("1442ef04-ac2d-4330-a8e8-d6bced4f5b04"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("183ce7e6-200d-4343-9a87-e0e9f67c56ba"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("211872bb-6892-44aa-85c6-8590ca3306f4"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("2f682729-d11e-4a22-b577-4ba503f97e0c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("33b95a78-143d-44dc-93ff-3fc7bc3e1ad4"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("33e0126d-4f30-4491-bd9d-af3433a97a60"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("3b6330b2-85f2-4bdc-b195-22a312889585"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4a20f1ee-b37d-4018-8ecd-3f3120fd26da"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4cd1da4a-e4bb-497e-93da-3c4a632c7230"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("4e4af5e0-4ed0-409b-8c86-da234ec01c07"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5b4aa5f4-d2a5-4be2-a8d2-3cb8d403f393"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c00c7d3-6a51-4d9b-80d2-840cae69ba68"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c2a4daa-1312-4b83-a5f5-a5287296330b"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("5c46efb6-eace-47e1-b3cb-94b6cadc40f3"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("61c6bed8-ed26-4041-8a3a-e7aff4d1498f"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("63e441f4-27bc-46bf-8288-01b8d92cd8c4"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("64d0478e-e61b-4749-92d4-1ecc2601cf82"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("659fc7f6-a843-4259-9693-b3d543791c3e"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("673b55cd-47df-40ad-b6da-4cde98e8fe3e"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6c7f0c2b-25ac-45a0-b619-e876cceef57a"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6e3765c2-a5f6-473c-97c2-7288340f7cf9"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("6ffc76ff-1ee5-4ce0-8ffb-016ba900c10a"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("70119917-9313-4a41-9e23-a3090ae7ec1d"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("710dafbd-af2b-4a81-b838-b38fc4058485"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("72bd548d-a64c-4467-90cb-c7de605e08bf"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("76947afd-aabe-413c-b4c2-ab71864ec348"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("775be837-5312-47f7-b26a-183a20b849cc"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("78ea1f8b-8087-460c-bc51-5807d1b81f0f"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("7ef21a9e-2818-4e5c-a3a1-94182abb0f6e"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("861203af-8d7a-4263-866b-8093c5365f20"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("86211fe5-c32d-41a9-b2ca-7bb2b71c4822"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("8738ffff-6adc-4683-b2ad-385f2a9f6c21"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("92487acb-c039-40fe-b0f2-9e8b10c74055"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("97d7b645-b0ee-43bf-b4bc-9c8d7441e2ec"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9de3c5be-9151-4663-a43e-99ef16a7b044"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9f480514-00d4-4b14-82c8-81e77795b515"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("9ff1ce81-b2fe-4890-8ec4-4a0c03748882"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a0e0125f-fea6-4119-a3d8-d944f49e1329"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a687ace6-6a27-441e-983f-11c3e85ce228"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("a8a2d1bb-32f4-4486-b8a9-d81a7a4b440a"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("aa66b652-9333-4776-9024-36385cfaeb9c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ae9182dd-5ff2-48c3-8a2a-1ea01d177926"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("aef889a9-c2c1-402b-abfe-f5d6deac3e55"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b8632077-1760-4a11-ad0b-f1f5351bbafe"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b8d1ab4e-f374-4e09-b090-54d5a920fb8d"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("b94dfb3c-bcaa-432e-911d-3dad09d0f917"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("bb955596-9fdb-46b4-be6c-a95d29891a29"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("bdcc94d9-7a15-4af0-8d0f-7beb7a329259"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("c121a6de-3ce1-4c52-8699-21673496512c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("d3b5160c-da84-44f2-8003-63121ab8b3fc"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("d9dcb3c3-81b7-46d2-ae2d-1e269a0fbf46"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("dd2720b7-5911-4f58-a2ae-c9649063fc45"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e0b56a99-7e6e-4dae-a873-f2ea76571394"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e183e9dd-d25c-4b86-880f-6d0785631476"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("e19772e4-d798-4dce-aed1-d4658d6b001b"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ea46553d-0c9b-4619-8782-dd7d7587ff76"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("eacbbabc-35a0-4fba-8f75-9a3a700461f4"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ed0d9f99-6e1b-473d-965a-84ec85cbba1c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("ed7222b0-aaa4-4190-ba68-f6ad1ae9a93d"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("efa9bcc1-1790-415f-a04b-ab54e9d5f266"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f237c131-bc90-49c7-9397-6e0c1944ed96"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f24472cc-9a41-46a3-b2ce-e3d8b078530c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f253087e-dc1a-4098-a2d4-6ba7312329df"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f3bc54f2-acc4-419f-954b-715486cd1dad"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("f6632d1e-9c1a-460d-b9f5-2b28a16aa2f2"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("fd4a80a3-07eb-4c97-9a04-9d384041ff4c"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 211, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "lane_public_code",
                keyColumn: "id",
                keyValue: new Guid("fee1058f-84e6-4277-b11e-6ab1dfcdc774"),
                column: "created_on",
                value: new DateTime(2018, 11, 23, 8, 27, 45, 212, DateTimeKind.Local));
        }
    }
}
