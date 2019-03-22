using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue493_CorporateNameAndRemoveLocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropInitialInspectionViews();

            migrationBuilder.DropTable(
                name: "building_localization");

            migrationBuilder.DropTable(
                name: "inspection_building_localization");

            migrationBuilder.AddColumn<string>(
                name: "alias_name",
                table: "inspection_building",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "corporate_name",
                table: "inspection_building",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alias_name",
                table: "building",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "corporate_name",
                table: "building",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateInitialInspectionViews();            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropInitialInspectionViews();

            migrationBuilder.DropColumn(
                name: "alias_name",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "corporate_name",
                table: "inspection_building");

            migrationBuilder.DropColumn(
                name: "alias_name",
                table: "building");

            migrationBuilder.DropColumn(
                name: "corporate_name",
                table: "building");

            migrationBuilder.CreateTable(
                name: "building_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_building_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_building_localization_building_building_id",
                        column: x => x.id_building,
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspection_building_localization",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    id_building = table.Column<Guid>(nullable: false),
                    id_web_user_last_modified_by = table.Column<Guid>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    language_code = table.Column<string>(maxLength: 2, nullable: false),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inspection_building_localization", x => x.id);
                    table.ForeignKey(
                        name: "fk_inspection_building_localization_inspection_building_inspec~",
                        column: x => x.id_building,
                        principalTable: "inspection_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_building_localization_id_building",
                table: "building_localization",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_building_localization_id_building",
                table: "inspection_building_localization",
                column: "id_building");

            migrationBuilder.CreateInitialInspectionViews();
        }
    }
}
