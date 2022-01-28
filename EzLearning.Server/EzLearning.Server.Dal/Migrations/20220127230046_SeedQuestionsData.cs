using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedQuestionsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"Choose the correct option to output ""EzLearning""\n\n___(""EzLearning"")", 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"Which of the following will give this output?\n\nA\n\nB\nC", 2 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"What is the output of this code?\n\nprint(1 + 2 + 3)", 3 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"Which option is the output of this code? \n\nprint((4 + 8) / 2)", 4 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"Which of these will be stored as a float?", 5 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"What is the output of this code?\n\nprint(1 + 2 + 3 + 4.0 + 5)", 6 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"Fill in the blank to output 5 rised to the 3rd power:\n\nprint( 5__3 )", 7 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"What is the output of this code?\n\nprint( 8 ** (1/3) )", 8 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"What is the output of this code?\n\nprint( 10//4 )", 9 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId" },
                values: new object[] {
                    @"What is the result of this code?\n\nprint( 7%(5 // 2 ))", 10 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"What is the result of the following operation?\n\nprint( 1 + 4*3 )", 11, 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"Fill in the  blanks to output ""I love Python""\n\n___(""I love Python""__", 12, 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"Guess the output of this code:\n\nprint( (3**2)//2)", 13, 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"Which of the following operators is used to calculate the reminder of division?", 14, 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"Fill in the blank to output the quotient of dividing 100 by 42:\n\nprint(100__42)", 15, 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "Content", "CorrectAnswerId", "ChapterTestId" },
                values: new object[] {
                    @"In which order should you fill in the blanks with given options to produce code that output 10 raised to the 5th power:\n\n___ ( __**__ )", 16, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
