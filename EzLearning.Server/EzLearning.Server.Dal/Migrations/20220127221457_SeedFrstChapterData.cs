using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedFrstChapterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "Basic Concepts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
