﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "javaWrapper",
                table: "Questions",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "javaWrapper",
                value: "Nothing here");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "javaWrapper",
                value: "import java.util.*;\r\nimport java.io.IOException;\r\nimport java.nio.file.Files;\r\nimport java.nio.file.Paths;\r\nimport java.io.*;\r\n\r\n\r\npublic class App {\r\n    public static void main(String[] args) {\r\n        // Print environment variable\r\n        String envVariable2 = System.getenv(\"JOB_COMPLETION_INDEX\");\r\n        System.out.println(\"JOB_INDEX: \" + (envVariable2 != null ? envVariable2 : \"Not Set\"));\r\n\r\n        // Print file content\r\n        String content = \"\";\r\n        try {\r\n            content = new String(Files.readAllBytes(Paths.get(\"/etc/config/input-\" + envVariable2)));\r\n            // System.out.println(\"File Content:\\n\" + content);\r\n        } catch (Exception e) {\r\n            System.out.println(\"Error reading file: \" + e.getMessage());\r\n        }\r\n\r\n        // Combine arguments into a single string\r\n        args = content.split(\"\\\\s+\");\r\n        // System.out.println(Arrays.toString(args));\r\n        StringBuilder inputBuilder = new StringBuilder();\r\n        for (String arg : args) {\r\n            inputBuilder.append(arg).append(\" \");\r\n        }\r\n        String input = inputBuilder.toString().trim();\r\n\r\n        // Split the input based on the # symbol\r\n        String[] parts = input.split(\"#\");\r\n        if (parts.length != 2) {\r\n            System.err.println(\"Invalid input format! Expected format: numbers target # result\");\r\n            return;\r\n        }\r\n\r\n        // Parse the numbers before the # symbol\r\n        String[] numStrings = parts[0].trim().split(\" \");\r\n        int[] nums = new int[numStrings.length - 1];\r\n        for (int i = 0; i < numStrings.length - 1; i++) {\r\n            nums[i] = Integer.parseInt(numStrings[i]);\r\n        }\r\n\r\n        // Target value is the last number before #\r\n        int target = Integer.parseInt(numStrings[numStrings.length - 1]);\r\n\r\n        // Parse the expected result after the # symbol\r\n        String[] expectedResultStrings = parts[1].trim().split(\" \");\r\n        int[] expectedResult = new int[expectedResultStrings.length];\r\n        for (int i = 0; i < expectedResultStrings.length; i++) {\r\n            expectedResult[i] = Integer.parseInt(expectedResultStrings[i]);\r\n        }\r\n\r\n        try {\r\n            // Call the twoSum method\r\n            Solution sol = new Solution();\r\n            int[] result = sol.twoSum(nums, target);\r\n\r\n            // Compare the result with the expected result\r\n            if (Arrays.equals(result, expectedResult)) {\r\n                System.out.println(\"true\");\r\n                System.out.println(Arrays.toString(result));\r\n            } else {\r\n                System.out.println(\"false\");\r\n                System.out.println(Arrays.toString(result));\r\n            }\r\n\r\n        } catch (Exception e) {\r\n            System.out.println(\"error\");\r\n            // System.out.println(e.getMessage());\r\n            e.printStackTrace(System.out);\r\n        }\r\n    }\r\n}\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "javaWrapper",
                table: "Questions");
        }
    }
}
