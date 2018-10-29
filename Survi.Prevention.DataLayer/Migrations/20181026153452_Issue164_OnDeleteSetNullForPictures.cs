using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class Issue164_OnDeleteSetNullForPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_building_anomaly_picture_pictures_picture_id",
                table: "building_anomaly_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_building_particular_risk_picture_pictures_picture_id",
                table: "building_particular_risk_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_anomaly_picture_inspection_pictures_pict~",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_particular_risk_picture_inspection_pictu~",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.AddForeignKey(
                name: "fk_building_anomaly_picture_pictures_picture_id",
                table: "building_anomaly_picture",
                column: "id_picture",
                principalTable: "picture",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_building_particular_risk_picture_pictures_picture_id",
                table: "building_particular_risk_picture",
                column: "id_picture",
                principalTable: "picture",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_anomaly_picture_inspection_pictures_pict~",
                table: "inspection_building_anomaly_picture",
                column: "id_picture",
                principalTable: "inspection_picture",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_particular_risk_picture_inspection_pictu~",
                table: "inspection_building_particular_risk_picture",
                column: "id_picture",
                principalTable: "inspection_picture",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_building_anomaly_picture_pictures_picture_id",
                table: "building_anomaly_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_building_particular_risk_picture_pictures_picture_id",
                table: "building_particular_risk_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_anomaly_picture_inspection_pictures_pict~",
                table: "inspection_building_anomaly_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_inspection_building_particular_risk_picture_inspection_pictu~",
                table: "inspection_building_particular_risk_picture");

            migrationBuilder.AddForeignKey(
                name: "fk_building_anomaly_picture_pictures_picture_id",
                table: "building_anomaly_picture",
                column: "id_picture",
                principalTable: "picture",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_building_particular_risk_picture_pictures_picture_id",
                table: "building_particular_risk_picture",
                column: "id_picture",
                principalTable: "picture",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_anomaly_picture_inspection_pictures_pict~",
                table: "inspection_building_anomaly_picture",
                column: "id_picture",
                principalTable: "inspection_picture",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_inspection_building_particular_risk_picture_inspection_pictu~",
                table: "inspection_building_particular_risk_picture",
                column: "id_picture",
                principalTable: "inspection_picture",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
