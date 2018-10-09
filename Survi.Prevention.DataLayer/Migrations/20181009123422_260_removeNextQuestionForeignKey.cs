using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class _260_removeNextQuestionForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_survey_question_survey_question_next_question_id",
                table: "survey_question");

            migrationBuilder.DropIndex(
                name: "IX_survey_question_id_survey_question_next",
                table: "survey_question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_survey_question_id_survey_question_next",
                table: "survey_question",
                column: "id_survey_question_next");

            migrationBuilder.AddForeignKey(
                name: "fk_survey_question_survey_question_next_question_id",
                table: "survey_question",
                column: "id_survey_question_next",
                principalTable: "survey_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
