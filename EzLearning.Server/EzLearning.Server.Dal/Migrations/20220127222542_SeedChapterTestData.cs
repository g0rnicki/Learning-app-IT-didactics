using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedChapterTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tests",
                columns: new[] { "ChapterId" },
                values: new object[] { 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
