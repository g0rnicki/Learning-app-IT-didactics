using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class ChangeForeignKeyForQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_CorrectAnswerId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_CorrectAnswerId",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerId",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_CorrectAnswerId",
                table: "questions",
                column: "CorrectAnswerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_CorrectAnswerId",
                table: "questions",
                column: "CorrectAnswerId",
                principalTable: "answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_CorrectAnswerId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_CorrectAnswerId",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerId",
                table: "questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_questions_CorrectAnswerId",
                table: "questions",
                column: "CorrectAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_CorrectAnswerId",
                table: "questions",
                column: "CorrectAnswerId",
                principalTable: "answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
