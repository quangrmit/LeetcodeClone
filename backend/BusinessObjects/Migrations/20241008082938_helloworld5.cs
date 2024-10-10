using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "pythonAnswerTemplate",
                value: "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}");

            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 1,
                column: "funcName",
                value: "isValid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "pythonAnswerTemplate",
                value: "");

            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 1,
                column: "funcName",
                value: "validParant");
        }
    }
}
