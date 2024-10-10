using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "funcName",
                table: "Testcases",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "pythonAnswerTemplate",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "pythonAnswerTemplate",
                value: "");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "pythonAnswerTemplate",
                value: "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}");

            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 1,
                column: "funcName",
                value: "validParant");

            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 2,
                column: "funcName",
                value: "twoSum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "funcName",
                table: "Testcases");

            migrationBuilder.DropColumn(
                name: "pythonAnswerTemplate",
                table: "Questions");
        }
    }
}
