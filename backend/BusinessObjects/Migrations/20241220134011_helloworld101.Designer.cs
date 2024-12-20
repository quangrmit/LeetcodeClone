﻿// <auto-generated />
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241220134011_helloworld101")]
    partial class helloworld101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusinessObjects.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("QuestionTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cppAnswerTemplate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("javaAnswerTemplate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pythonAnswerTemplate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Content = "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\nOpen brackets must be closed by the same type of brackets.\r\nOpen brackets must be closed in the correct order.\r\nEvery close bracket has a corresponding open bracket of the same type.\r\n \r\n\r\nExample 1:\r\n\r\nInput: s = \"()\"\r\n\r\nOutput: true\r\n\r\nExample 2:\r\n\r\nInput: s = \"()[]{}\"\r\n\r\nOutput: true\r\n\r\nExample 3:\r\n\r\nInput: s = \"(]\"\r\n\r\nOutput: false\r\n\r\nExample 4:\r\n\r\nInput: s = \"([])\"\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= s.length <= 104\r\ns consists of parentheses only '()[]{}'.",
                            QuestionTitle = "Valid Parentheses",
                            cppAnswerTemplate = "class Solution {\r\n    public: \r\n boolean isValid(std::string s) {\r\n        \r\n    }\r\n};",
                            javaAnswerTemplate = "class Solution {\r\n    public boolean isValid(String s) {\r\n        \r\n    }\r\n}",
                            pythonAnswerTemplate = "class Solution:\r\n    def isValid(String s):\r\n        \r\n    \r\n"
                        },
                        new
                        {
                            QuestionId = 2,
                            Content = "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?",
                            QuestionTitle = "Two Sum",
                            cppAnswerTemplate = "class Solution {\r\n    public: \r\n vector<int> twoSum(vector<int>& nums, int target)  {\r\n        \r\n    }\r\n};",
                            javaAnswerTemplate = "class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n    }\r\n}",
                            pythonAnswerTemplate = "class Solution:\r\n    def twoSum(self, nums: List[int], target: int) -> List[int]:\r\n        \r\n    \r\n"
                        });
                });

            modelBuilder.Entity("BusinessObjects.Testcase", b =>
                {
                    b.Property<int>("TestcaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("cases")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("funcName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TestcaseId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Testcases");

                    b.HasData(
                        new
                        {
                            TestcaseId = 1,
                            QuestionId = 1,
                            cases = "{\"data\":[{\"input\":[\"()\"],\"output\":[true]},{\"input\":[\"()[]{}\"],\"output\":[true]},{\"input\":[\"(]\"],\"output\":[false]}]}",
                            funcName = "isValid"
                        },
                        new
                        {
                            TestcaseId = 2,
                            QuestionId = 2,
                            cases = "{\"data\":[{\"run_test_input\": \"2 7 11 15 9 # 0 1\", \"output\": \"[0,1]\", \"input\": [[2, 7, 11, 15],9],}, {\"run_test_input\": \"3 2 4 6 # 0 1\", \"output\": \"[0,1]\", \"input\":[[3,2,4],6]}, {\"run_test_input\": \"3 3 6 # 0 1d\", \"output\": \"[0,1]\", \"input\":[[3,3],6]}]}",
                            funcName = "twoSum"
                        });
                });

            modelBuilder.Entity("BusinessObjects.Testcase", b =>
                {
                    b.HasOne("BusinessObjects.Question", "question")
                        .WithMany("Testcases")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("BusinessObjects.Question", b =>
                {
                    b.Navigation("Testcases");
                });
#pragma warning restore 612, 618
        }
    }
}
