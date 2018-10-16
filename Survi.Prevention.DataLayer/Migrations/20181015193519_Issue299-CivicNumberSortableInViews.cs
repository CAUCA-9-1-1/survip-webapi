using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue299CivicNumberSortableInViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropInitialInspectionViews();
	        migrationBuilder.CreateInitialInspectionViews();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropInitialInspectionViews();
        }
    }
}
