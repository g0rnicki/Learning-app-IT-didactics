using Microsoft.EntityFrameworkCore.Migrations;

namespace EzLearning.Server.Dal.Migrations
{
    public partial class SeedLessonsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    1, 1, "Hello world",
                    @"Let's kick things off by creating a simple program that displays the text ""Hello world!"".\n\nIn Python, we use the print function to output text.\n\nSo to generate our message, the code would look like this:\n\nprint('Hello world!')",
                    1, 1
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    1, 2, "Printing Text",
                    @"More to say? Of course you do!\n\nYou can use the print statement to output multiple lines of text.",
                    1, 2
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    2, 1, "Simple Operations",
                    @"So Python can spell, but can it count? Let’s talk about calculations.\nDoing a calculation in Python is simple, just enter it into the print statement (don’t forget the parentheses!):\n\nprint(2 + 2)",
                    1, 3
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    2, 2, "Simple Operations",
                    @"Multiplication and division in Python are also pretty simple. We use an asterisk * to multiply and a forward slash / to divide. \n\nAgain, we just enter it straight into the print statement. Like this:\n\nprint( 10 / 2 )\nJust like in regular math, we can use parentheses to indicate the operations we want performed first (but we still need to include the ones around the statement too!). Like this:\nprint( 2 * (3 + 4) )",
                    1, 4
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    3, 1, "Data Types",
                    @"Before we go any further, it’s a good idea to introduce the main types of data that we use in Python. Each value in Python has a type.\n\nText, like ""Hello world"", is called a string.\nWhole numbers are called integers.\nAnd numbers with a decimal point are called floats.\nNow, we’ve already encountered strings and integers, so you know what that means...Time to float!",
                    1, 5
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    3, 2, "Floats",
                    @"So we know what floats are, they’re numbers with a decimal, but how do we produce them? \n\nWell, we can produce a float by dividing any two integers. \nOr we can also run an operation on two floats, or on a float and an integer.\n\nprint( 8 / 2)\nprint( 6 * 7.0 )\nprint( 4 + 1.65 )",
                    1, 6
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    4, 1, "Exponentiation",
                    @"Alright, that covers the very basic operations, addition, subtraction, multiplication, and division. You’re doing great!\n\nIt’s time to kick it up a notch and introduce exponentiation–which is what we call it when we raise one number to the power of another. \n\nThe exponentiation operation is performed using two asterisks. Like this:\n\nprint( 2**5 )",
                    1, 7
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    4, 2, "Exponentiation",
                    @"Too easy? Yeah, thought so. How about exponentiation with floats! Because we can totally use floats in exponentiation. \n\nCheck it out. The following code will result in the square root of 9:\n\nprint( 9 ** (1/2) )",
                    1, 8
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    5, 1, "Quotient",
                    @"Floor division is done using two forward slashes and is used to determine the quotient of a division. Wait! What?! ""Floor Division""? ""Quotient""? \n\nQuotient just means the quantity produced by the division of two numbers. \n\nAnd Floor division is just like a normal division operation except that it returns the largest possible integer. This integer is either less than or equal to the normal division result.\n\nFor example:\nprint( 20 // 6 )",
                    1, 9
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "LessonNumber", "Part", "Title", "Content", "ChapterId", "QuestionId" },
                values: new object[]
                {
                    5, 2, "Remainder",
                    @"Ahh those pesky remainders. But, they’re not so pesky in Python. We can use the modulo operator–which is carried out with a percent symbol (%)–to get the remainder of a given division.\n\nFor example:\nprint( 20 % 6 )\nprint( 1.25 % 0.5 )",
                    1, 10
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
