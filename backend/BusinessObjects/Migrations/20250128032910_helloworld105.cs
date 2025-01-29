using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pythonWrapper",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "pythonWrapper",
                value: "Nothing here");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "pythonWrapper",
                value: "import os\r\nimport sys\r\nfrom solution import Solution\r\n\r\ndef main():\r\n    # Print environment variable\r\n    env_variable2 = os.getenv(\"JOB_COMPLETION_INDEX\")\r\n    print(\"JOB_INDEX:\", env_variable2 if env_variable2 else \"Not Set\")\r\n\r\n    # Read file content\r\n    content = \"\"\r\n    try:\r\n        with open(f\"/etc/config/input-{env_variable2}\", \"r\") as file:\r\n            content = file.read()\r\n    except Exception as e:\r\n        print(\"Error reading file:\", str(e))\r\n\r\n    # Combine arguments into a single string\r\n    args = content.split()\r\n    input_str = \" \".join(args).strip()\r\n\r\n    # Split the input based on the # symbol\r\n    parts = input_str.split(\"#\")\r\n    if len(parts) != 2:\r\n        print(\"Invalid input format! Expected format: numbers target # result\", file=sys.stderr)\r\n        return\r\n\r\n    # Parse the numbers before the # symbol\r\n    num_strings = parts[0].strip().split()\r\n    nums = list(map(int, num_strings[:-1]))\r\n\r\n    # Target value is the last number before #\r\n    target = int(num_strings[-1])\r\n\r\n    # Parse the expected result after the # symbol\r\n    expected_result_strings = parts[1].strip().split()\r\n    expected_result = list(map(int, expected_result_strings))\r\n\r\n    try:\r\n        # Call the two_sum method\r\n        sol = Solution()\r\n        result = sol.twoSum(nums, target)\r\n\r\n        # Compare the result with the expected result\r\n        if result == expected_result:\r\n            print(\"true\")\r\n            print(result)\r\n        else:\r\n            print(\"false\")\r\n            print(result)\r\n\r\n    except Exception as e:\r\n        print(\"error\")\r\n        print(str(e))\r\n\r\nif __name__ == \"__main__\":\r\n    main()\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pythonWrapper",
                table: "Questions");
        }
    }
}
