using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedQuestionAnswersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "print" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { @"print(""A"")
print(""B"")
print(""C"")" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "6" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "6.0" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "7.3" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "15.0" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "**" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "2.0" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "2" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "1" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "13" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "print, )" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "4" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "%" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "//" });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "Answer" },
                values: new object[] { "print, 10, 5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
