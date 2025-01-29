using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cppWrapper",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "cppWrapper",
                value: "Nothing here");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "cppWrapper",
                value: "#include <iostream>\r\n#include <fstream>\r\n#include <sstream>\r\n#include <vector>\r\n#include <cstdlib>\r\n#include <cstring>\r\n#include <iterator>\r\n#include \"solution.h\"\r\n\r\nint main()\r\n{\r\n    // Print environment variable\r\n    const char *envVariable2 = std::getenv(\"JOB_COMPLETION_INDEX\");\r\n    std::cout << \"JOB_INDEX: \" << (envVariable2 ? envVariable2 : \"Not Set\") << std::endl;\r\n\r\n    // Read file content\r\n    std::string content;\r\n    std::ifstream file(std::string(\"/etc/config/input-\") + (envVariable2 ? envVariable2 : \"\"));\r\n    if (file)\r\n    {\r\n        std::ostringstream ss;\r\n        ss << file.rdbuf();\r\n        content = ss.str();\r\n    }\r\n    else\r\n    {\r\n        std::cerr << \"Error reading file\" << std::endl;\r\n        return 1;\r\n    }\r\n\r\n    // Split content into arguments\r\n    std::istringstream iss(content);\r\n    std::vector<std::string> args((std::istream_iterator<std::string>(iss)), std::istream_iterator<std::string>());\r\n\r\n    // Combine arguments into a single string\r\n    std::string input;\r\n    for (const auto &arg : args)\r\n    {\r\n        input += arg + \" \";\r\n    }\r\n    input = input.substr(0, input.size() - 1);\r\n\r\n    // Split the input based on the # symbol\r\n    size_t pos = input.find('#');\r\n    if (pos == std::string::npos)\r\n    {\r\n        std::cerr << \"Invalid input format! Expected format: numbers target # result\" << std::endl;\r\n        return 1;\r\n    }\r\n\r\n    std::string numbersPart = input.substr(0, pos);\r\n    std::string resultPart = input.substr(pos + 1);\r\n\r\n    // Parse numbers before #\r\n    std::istringstream numStream(numbersPart);\r\n    std::vector<int> nums;\r\n    int value;\r\n    while (numStream >> value)\r\n    {\r\n        nums.push_back(value);\r\n    }\r\n    if (nums.empty())\r\n    {\r\n        std::cerr << \"Invalid input! No numbers provided.\" << std::endl;\r\n        return 1;\r\n    }\r\n    int target = nums.back();\r\n    nums.pop_back();\r\n\r\n    // Parse expected result after #\r\n    std::istringstream resultStream(resultPart);\r\n    std::vector<int> expectedResult;\r\n    while (resultStream >> value)\r\n    {\r\n        expectedResult.push_back(value);\r\n    }\r\n\r\n    try\r\n    {\r\n        // Call the twoSum method\r\n        Solution sol;\r\n        std::vector<int> result = sol.twoSum(nums, target);\r\n\r\n        // Compare result with expected result\r\n        if (result == expectedResult)\r\n        {\r\n            std::cout << \"true\" << std::endl;\r\n        }\r\n        else\r\n        {\r\n            std::cout << \"false\" << std::endl;\r\n        }\r\n\r\n        std::cout << \"[\"; // Start the array print\r\n        for (size_t i = 0; i < result.size(); ++i)\r\n        {\r\n            std::cout << result[i];\r\n            if (i != result.size() - 1)\r\n            {\r\n                std::cout << \",\"; // Add comma if it's not the last element\r\n            }\r\n        }\r\n        std::cout << \"]\" << std::endl;\r\n    }\r\n    catch (const std::exception &e)\r\n    {\r\n        std::cerr << \"error\" << std::endl;\r\n        std::cerr << e.what() << std::endl;\r\n    }\r\n\r\n    return 0;\r\n}\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cppWrapper",
                table: "Questions");
        }
    }
}
