using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue287AddUtilizationYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "utilisation_code",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "utilization_code_year",
                table: "city",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "utilisation_code");

            migrationBuilder.DropColumn(
                name: "utilization_code_year",
                table: "city");
        }
    }
}
