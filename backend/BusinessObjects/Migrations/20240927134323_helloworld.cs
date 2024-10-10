using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    QuestionTitle = table.Column<string>(type: "longtext", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Testcases",
                columns: table => new
                {
                    TestcaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cases = table.Column<string>(type: "longtext", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testcases", x => x.TestcaseId);
                    table.ForeignKey(
                        name: "FK_Testcases_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Content", "QuestionTitle" },
                values: new object[,]
                {
                    { 1, "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'.", "Valid Parentheses" },
                    { 2, "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?", "Two Sum" }
                });

            migrationBuilder.InsertData(
                table: "Testcases",
                columns: new[] { "TestcaseId", "QuestionId", "cases" },
                values: new object[,]
                {
                    { 1, 1, "'{\"data\":[{\"input\":[\"()\"],\"output\":[true]},{\"input\":[\"()[]{}\"],\"output\":[true]},{\"input\":[\"(]\"],\"output\":[false]}]}'" },
                    { 2, 2, "{\"data\":[{\"input\":[[2,7,11,15],9],\"output\":[[0,1]]},{\"input\":[[3,2,4],6],\"output\":[[0,1]]},{\"input\":[[3,3],6],\"output\":[[0,1]]}]}'" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testcases_QuestionId",
                table: "Testcases",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testcases");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
