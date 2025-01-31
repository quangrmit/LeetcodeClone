using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseMySQL(config.GetConnectionString("MySQL"));
        }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Testcase> Testcases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Testcases)
                .WithOne(e => e.question)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();


            //modelBuilder.Entity<Testcase>(entity =>
            //{
            //    entity.HasKey(e => e.TestcaseId);
            //    entity.HasOne(e => e.question).WithMany(
            //            e => e.Testcases);
            //});
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionTitle = "Valid Parentheses",
                    javaWrapper = "Nothing here",
                    pythonWrapper = "Nothing here",
                    cppWrapper = "Nothing here",
                    pythonAnswerTemplate = "class Solution:\r\n    def isValid(String s):\r\n        \r\n    \r\n",
                    javaAnswerTemplate = "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}",
                    cppAnswerTemplate = "class Solution {\r\n    public: \r\n boolean isValid(std::string s) {\r\n        \r\n    }\r\n};",
                    Content = "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'."
                },
                
                new Question
                {
                    QuestionId = 2,
                    QuestionTitle = "Two Sum",

                    javaWrapper = "import java.util.*;\r\nimport java.io.IOException;\r\nimport java.nio.file.Files;\r\nimport java.nio.file.Paths;\r\nimport java.io.*;\r\n\r\n\r\npublic class App {\r\n    public static void main(String[] args) {\r\n        // Print environment variable\r\n        String envVariable2 = System.getenv(\"JOB_COMPLETION_INDEX\");\r\n        System.out.println(\"JOB_INDEX: \" + (envVariable2 != null ? envVariable2 : \"Not Set\"));\r\n\r\n        // Print file content\r\n        String content = \"\";\r\n        try {\r\n            content = new String(Files.readAllBytes(Paths.get(\"/etc/config/input-\" + envVariable2)));\r\n        } catch (Exception e) {\r\n            System.out.println(\"Error reading file: \" + e.getMessage());\r\n        }\r\n\r\n        // Combine arguments into a single string\r\n        args = content.split(\"\\\\s+\");\r\n        StringBuilder inputBuilder = new StringBuilder();\r\n        for (String arg : args) {\r\n            inputBuilder.append(arg).append(\" \");\r\n        }\r\n        String input = inputBuilder.toString().trim();\r\n\r\n        // Split the input based on the # symbol\r\n        String[] parts = input.split(\"#\");\r\n        if (parts.length != 2) {\r\n            System.err.println(\"Invalid input format! Expected format: numbers target # result\");\r\n            return;\r\n        }\r\n\r\n        // Parse the numbers before the # symbol\r\n        String[] numStrings = parts[0].trim().split(\" \");\r\n        int[] nums = new int[numStrings.length - 1];\r\n        for (int i = 0; i < numStrings.length - 1; i++) {\r\n            nums[i] = Integer.parseInt(numStrings[i]);\r\n        }\r\n\r\n        // Target value is the last number before #\r\n        int target = Integer.parseInt(numStrings[numStrings.length - 1]);\r\n\r\n        // Parse the expected result after the # symbol\r\n        String[] expectedResultStrings = parts[1].trim().split(\" \");\r\n        int[] expectedResult = new int[expectedResultStrings.length];\r\n        for (int i = 0; i < expectedResultStrings.length; i++) {\r\n            expectedResult[i] = Integer.parseInt(expectedResultStrings[i]);\r\n        }\r\n\r\n        try {\r\n            // Call the twoSum method\r\n            Solution sol = new Solution();\r\n            int[] result = sol.twoSum(nums, target);\r\n\r\n            // Compare the result with the expected result\r\n            if (Arrays.equals(result, expectedResult)) {\r\n                System.out.println(\"true\");\r\n                System.out.println(Arrays.toString(result));\r\n            } else {\r\n                System.out.println(\"false\");\r\n                System.out.println(Arrays.toString(result));\r\n            }\r\n\r\n        } catch (Exception e) {\r\n            System.out.println(\"error\");\r\n            e.printStackTrace(System.out);\r\n        }\r\n    }\r\n}\r\n",
                    javaAnswerTemplate = "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}",

                    pythonWrapper = "import os\r\nimport sys\r\nimport traceback\r\n\r\nfrom solution import Solution\r\n\r\ndef main():\r\n    # Print environment variable\r\n    env_variable2 = os.getenv(\"JOB_COMPLETION_INDEX\")\r\n    print(\"JOB_INDEX:\", env_variable2 if env_variable2 else \"Not Set\")\r\n\r\n    # Read file content\r\n    content = \"\"\r\n    try:\r\n        with open(f\"/etc/config/input-{env_variable2}\", \"r\") as file:\r\n            content = file.read()\r\n    except Exception as e:\r\n        print(\"Error reading file:\", str(e))\r\n\r\n    # Combine arguments into a single string\r\n    args = content.split()\r\n    input_str = \" \".join(args).strip()\r\n\r\n    # Split the input based on the # symbol\r\n    parts = input_str.split(\"#\")\r\n    if len(parts) != 2:\r\n        print(\"Invalid input format! Expected format: numbers target # result\", file=sys.stderr)\r\n        return\r\n\r\n    # Parse the numbers before the # symbol\r\n    num_strings = parts[0].strip().split()\r\n    nums = list(map(int, num_strings[:-1]))\r\n\r\n    # Target value is the last number before #\r\n    target = int(num_strings[-1])\r\n\r\n    # Parse the expected result after the # symbol\r\n    expected_result_strings = parts[1].strip().split()\r\n    expected_result = list(map(int, expected_result_strings))\r\n\r\n    try:\r\n        # Call the two_sum method\r\n        sol = Solution()\r\n        result = sol.twoSum(nums, target)\r\n\r\n        # Compare the result with the expected result\r\n        if result == expected_result:\r\n            print(\"true\")\r\n            print(result)\r\n        else:\r\n            print(\"false\")\r\n            print(result)\r\n\r\n    except Exception as e:\r\n        print(\"error\")\r\n        print(traceback.format_exc())\r\n\r\nif __name__ == \"__main__\":\r\n    main()\r\n",
                    pythonAnswerTemplate = "class Solution:\r\n    def twoSum(self, nums: List[int], target: int) -> List[int]:\r\n        \r\n    \r\n",
                    
                    cppWrapper = "#include <iostream>\r\n#include <fstream>\r\n#include <sstream>\r\n#include <vector>\r\n#include <cstdlib>\r\n#include <cstring>\r\n#include <iterator>\r\n#include \"solution.h\"\r\n\r\nint main()\r\n{\r\n    // Print environment variable\r\n    const char *envVariable2 = std::getenv(\"JOB_COMPLETION_INDEX\");\r\n    std::cout << \"JOB_INDEX: \" << (envVariable2 ? envVariable2 : \"Not Set\") << std::endl;\r\n\r\n    // Read file content\r\n    std::string content;\r\n    std::ifstream file(std::string(\"/etc/config/input-\") + (envVariable2 ? envVariable2 : \"\"));\r\n    if (file)\r\n    {\r\n        std::ostringstream ss;\r\n        ss << file.rdbuf();\r\n        content = ss.str();\r\n    }\r\n    else\r\n    {\r\n        std::cerr << \"Error reading file\" << std::endl;\r\n        return 1;\r\n    }\r\n\r\n    // Split content into arguments\r\n    std::istringstream iss(content);\r\n    std::vector<std::string> args((std::istream_iterator<std::string>(iss)), std::istream_iterator<std::string>());\r\n\r\n    // Combine arguments into a single string\r\n    std::string input;\r\n    for (const auto &arg : args)\r\n    {\r\n        input += arg + \" \";\r\n    }\r\n    input = input.substr(0, input.size() - 1);\r\n\r\n    // Split the input based on the # symbol\r\n    size_t pos = input.find('#');\r\n    if (pos == std::string::npos)\r\n    {\r\n        std::cerr << \"Invalid input format! Expected format: numbers target # result\" << std::endl;\r\n        return 1;\r\n    }\r\n\r\n    std::string numbersPart = input.substr(0, pos);\r\n    std::string resultPart = input.substr(pos + 1);\r\n\r\n    // Parse numbers before #\r\n    std::istringstream numStream(numbersPart);\r\n    std::vector<int> nums;\r\n    int value;\r\n    while (numStream >> value)\r\n    {\r\n        nums.push_back(value);\r\n    }\r\n    if (nums.empty())\r\n    {\r\n        std::cerr << \"Invalid input! No numbers provided.\" << std::endl;\r\n        return 1;\r\n    }\r\n    int target = nums.back();\r\n    nums.pop_back();\r\n\r\n    // Parse expected result after #\r\n    std::istringstream resultStream(resultPart);\r\n    std::vector<int> expectedResult;\r\n    while (resultStream >> value)\r\n    {\r\n        expectedResult.push_back(value);\r\n    }\r\n\r\n    try\r\n    {\r\n        // Call the twoSum method\r\n        Solution sol;\r\n        std::vector<int> result = sol.twoSum(nums, target);\r\n\r\n        // Compare result with expected result\r\n        if (result == expectedResult)\r\n        {\r\n            std::cout << \"true\" << std::endl;\r\n        }\r\n        else\r\n        {\r\n            std::cout << \"false\" << std::endl;\r\n        }\r\n\r\n        std::cout << \"[\"; // Start the array print\r\n        for (size_t i = 0; i < result.size(); ++i)\r\n        {\r\n            std::cout << result[i];\r\n            if (i != result.size() - 1)\r\n            {\r\n                std::cout << \",\"; // Add comma if it's not the last element\r\n            }\r\n        }\r\n        std::cout << \"]\" << std::endl;\r\n    }\r\n    catch (const std::exception &e)\r\n    {\r\n        std::cerr << \"error\" << std::endl;\r\n        std::cerr << e.what() << std::endl;\r\n    }\r\n\r\n    return 0;\r\n}\r\n",
                    cppAnswerTemplate = "class Solution {\r\n    public: \r\n vector<int> twoSum(vector<int>& nums, int target)  {\r\n        \r\n    }\r\n};",

                    // Content = "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?"\
                    
                    Content = "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\n\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\n\nYou can return the answer in any order.\n\n#### Example 1\n> **Input**: nums = [2,7,11,15], target = 9\n> **Output**: [0,1]\n> **Explanation**: Because nums[0] + nums[1] == 9, we return [0, 1]\n#### Example 2\n> **Input**: nums = [3,3], target = 6\n> **Output**: [1,2]\n\n#### Constraints\n- <div class='code'>2 <= nums.length <= 10<sup>4</sup></div>"
                }
            );

            modelBuilder.Entity<Testcase>().HasData(
                new Testcase { TestcaseId = 1, QuestionId = 1, funcName = "isValid", cases = "{\"data\":[{\"input\":[\"()\"],\"output\":[true]},{\"input\":[\"()[]{}\"],\"output\":[true]},{\"input\":[\"(]\"],\"output\":[false]}]}" },
                new Testcase { TestcaseId = 2, QuestionId = 2, funcName = "twoSum", cases = "{\"data\":[{\"run_test_input\": \"2 7 11 15 9 # 0 1\", \"output\": \"[0,1]\", \"input\": [[2, 7, 11, 15],9],}, {\"run_test_input\": \"3 2 4 6 # 0 1\", \"output\": \"[0,1]\", \"input\":[[3,2,4],6]}, {\"run_test_input\": \"3 3 6 # 0 1\", \"output\": \"[0,1]\", \"input\":[[3,3],6]}]}" }
             );
        }
    }
}
