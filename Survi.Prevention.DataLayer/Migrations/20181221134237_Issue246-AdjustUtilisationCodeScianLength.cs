using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue246AdjustUtilisationCodeScianLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "scian",
                table: "utilisation_code",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "scian",
                table: "utilisation_code",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }
    }
}
