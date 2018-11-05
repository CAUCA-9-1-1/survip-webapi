using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue375BatchFormOptimization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.CreateInspectionBuildingManagementView();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropInspectionBuildingManagementView();
		}
    }
}
