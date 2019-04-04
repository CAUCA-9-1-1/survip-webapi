using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class issue531IncorrectContactFieldsLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "inspection_building_contact",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "inspection_building_contact",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "inspection_building_contact",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "inspection_building_contact",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
