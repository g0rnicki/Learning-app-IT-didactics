using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedWrongAnswersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "write", 1 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "output", 1 });
            
            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "echo", 1 });
            
            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { @"print(""A B C"")", 2 });
            
            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { @"write(""A"")\nwrite(""B"")\nwrite(""C"")", 2 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { @"print(A)\nprint(B)\nprint(C)", 2 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "1 + 2 + 3", 3 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "error ", 3 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { @"1\n2\n3", 3 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "8", 4 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "6", 4 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "8.0", 4 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { @"""hey""", 5 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "42", 5 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "True", 5 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "15", 6 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "14.0", 6 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "14", 6 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "*", 7 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "^", 7 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "***", 7 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "2", 8 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "3", 8 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "3.0", 8 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "3", 9 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "0", 9 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "2.5", 9 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "0", 10 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "7", 10 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "3.5", 10 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "15", 11 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "12", 11 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "10", 11 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "write, )", 12 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "print, ;", 12 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "echo, )", 12 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "4.5", 13 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "3", 13 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "6", 13 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "**", 14 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "//", 14 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "/", 14 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "**", 15 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "^^", 15 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "&&", 15 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "print, 5, 10", 16 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "write, 5, 10", 16 });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer", "QuestionId" },
                values: new object[] { "10, 5, print", 16 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
