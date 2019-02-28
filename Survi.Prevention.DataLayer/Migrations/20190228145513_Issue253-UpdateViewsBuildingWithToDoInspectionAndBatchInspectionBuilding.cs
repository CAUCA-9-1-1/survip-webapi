using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue253UpdateViewsBuildingWithToDoInspectionAndBatchInspectionBuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropInitialInspectionViews();
            migrationBuilder.CreateInitialInspectionViews();

            migrationBuilder.DropInspectionBuildingManagementView();
            migrationBuilder.CreateInspectionBuildingManagementView();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropInitialInspectionViews();
            migrationBuilder.CreateInitialInspectionViews();

            migrationBuilder.DropInspectionBuildingManagementView();
            migrationBuilder.CreateInspectionBuildingManagementView();
        }
    }
}
