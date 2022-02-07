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
                values: new object[] { "Strings" });

            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "Variables" });

            migrationBuilder.InsertData(
                table: "chapters",
                columns: new[] { "Name" },
                values: new object[] { "Control Flow" });

            migrationBuilder.InsertData(
               table: "chapters",
               columns: new[] { "Name" },
               values: new object[] { "Lists" });
            
            migrationBuilder.InsertData(
               table: "chapters",
               columns: new[] { "Name" },
               values: new object[] { "Functions" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
