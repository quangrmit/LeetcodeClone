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
                    pythonAnswerTemplate = "class Solution:\r\n    def isValid(String s):\r\n        \r\n    \r\n",
                    javaAnswerTemplate = "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}",
                    cppAnswerTemplate = "class Solution {\r\n    public: \r\n boolean isValid(std::string s) {\r\n        \r\n    }\r\n};",
                    Content = "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'."
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionTitle = "Two Sum",

            

                    javaAnswerTemplate = "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}",


                    pythonAnswerTemplate = "class Solution:\r\n    def twoSum(self, nums: List[int], target: int) -> List[int]:\r\n        \r\n    \r\n",
                    cppAnswerTemplate = "class Solution {\r\n    public: \r\n vector<int> twoSum(vector<int>& nums, int target)  {\r\n        \r\n    }\r\n};",

                    Content = "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?"
                }
            );

            modelBuilder.Entity<Testcase>().HasData(
                new Testcase { TestcaseId = 1, QuestionId = 1, funcName = "isValid", cases = "{\"data\":[{\"input\":[\"()\"],\"output\":[true]},{\"input\":[\"()[]{}\"],\"output\":[true]},{\"input\":[\"(]\"],\"output\":[false]}]}" },
                new Testcase { TestcaseId = 2, QuestionId = 2, funcName = "twoSum", cases = "{\"data\":[{\"run_test_input\": \"2 7 11 15 9 # 0 1\", \"output\": \"[0,1]\", \"input\": [[2, 7, 11, 15],9],}, {\"run_test_input\": \"3 2 4 6 # 0 1\", \"output\": \"[0,1]\", \"input\":[[3,2,4],6]}, {\"run_test_input\": \"3 3 6 # 0 1\", \"output\": \"[0,1]\", \"input\":[[3,3],6]}]}" }
             );
        }
    }
}
