using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedMoreChaptersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "" });

            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "" });

            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
