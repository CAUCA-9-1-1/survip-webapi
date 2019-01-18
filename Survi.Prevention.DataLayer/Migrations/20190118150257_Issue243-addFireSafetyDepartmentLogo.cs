using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue243addFireSafetyDepartmentLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.AddColumn<Guid>(
                name: "id_picture",
                table: "fire_safety_department",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fire_safety_department_id_picture",
                table: "fire_safety_department",
                column: "id_picture");

            migrationBuilder.AddForeignKey(
                name: "fk_fire_safety_department_pictures_picture_id",
                table: "fire_safety_department",
                column: "id_picture",
                principalTable: "picture",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fire_safety_department_pictures_picture_id",
                table: "fire_safety_department");

            migrationBuilder.DropIndex(
                name: "IX_fire_safety_department_id_picture",
                table: "fire_safety_department");

            migrationBuilder.DropColumn(
                name: "id_picture",
                table: "fire_safety_department");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
