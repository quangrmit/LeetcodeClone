using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class NewTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cppAnswerTemplate",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "javaAnswerTemplate",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                columns: new[] { "cppAnswerTemplate", "javaAnswerTemplate", "pythonAnswerTemplate" },
                values: new object[] { "class Solution {\r\n    public: \r\n boolean isValid(std::string s) {\r\n        \r\n    }\r\n};", "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}", "class Solution:\r\n    def isValid(String s):\r\n        \r\n    \r\n" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                columns: new[] { "cppAnswerTemplate", "javaAnswerTemplate", "pythonAnswerTemplate" },
                values: new object[] { "class Solution {\r\n    public: \r\n vector<int> twoSum(vector<int>& nums, int target)  {\r\n        \r\n    }\r\n};", "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}", "class Solution:\r\n    def twoSum(self, nums: List[int], target: int) -> List[int]:\r\n        \r\n    \r\n" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cppAnswerTemplate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "javaAnswerTemplate",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "pythonAnswerTemplate",
                value: "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "pythonAnswerTemplate",
                value: "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}");
        }
    }
}
