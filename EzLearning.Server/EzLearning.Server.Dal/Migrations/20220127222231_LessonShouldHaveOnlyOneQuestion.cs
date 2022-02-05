using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class LessonShouldHaveOnlyOneQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_questions_QuestionsId",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_lessons_QuestionsId",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "lessons");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lessons_QuestionId",
                table: "lessons",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_questions_QuestionId",
                table: "lessons",
                column: "QuestionId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_questions_QuestionId",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_lessons_QuestionId",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "lessons");

            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lessons_QuestionsId",
                table: "lessons",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_questions_QuestionsId",
                table: "lessons",
                column: "QuestionsId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
