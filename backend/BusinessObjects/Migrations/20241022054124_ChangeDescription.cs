using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "Content",
                value: "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\n\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\n\nYou can return the answer in any order.\n\n#### Example 1\n> **Input**: nums = [2,7,11,15], target = 9\n> **Output**: [0,1]\n> **Explanation**: Because nums[0] + nums[1] == 9, we return [0, 1]\n#### Example 2\n> **Input**: nums = [3,3], target = 6\n> **Output**: [1,2]\n\n#### Constraints\n- <div class='code'>2 <= nums.length <= 10<sup>4</sup></div>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "Content",
                value: "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?");
        }
    }
}
