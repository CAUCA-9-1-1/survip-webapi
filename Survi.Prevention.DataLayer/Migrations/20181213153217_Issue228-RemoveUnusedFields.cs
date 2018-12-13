using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue228RemoveUnusedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_county_states_state_id",
                table: "county");

            migrationBuilder.DropIndex(
                name: "IX_county_id_state",
                table: "county");

            migrationBuilder.DropColumn(
                name: "is_valid",
                table: "lane");

            migrationBuilder.DropColumn(
                name: "id_state",
                table: "county");

            migrationBuilder.AddColumn<Guid>(
                name: "state_id",
                table: "county",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_county_state_id",
                table: "county",
                column: "state_id");

            migrationBuilder.AddForeignKey(
                name: "fk_county_states_state_id",
                table: "county",
                column: "state_id",
                principalTable: "state",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_county_states_state_id",
                table: "county");

            migrationBuilder.DropIndex(
                name: "ix_county_state_id",
                table: "county");

            migrationBuilder.DropColumn(
                name: "state_id",
                table: "county");

            migrationBuilder.AddColumn<bool>(
                name: "is_valid",
                table: "lane",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "id_state",
                table: "county",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_county_id_state",
                table: "county",
                column: "id_state");

            migrationBuilder.AddForeignKey(
                name: "fk_county_states_state_id",
                table: "county",
                column: "id_state",
                principalTable: "state",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
