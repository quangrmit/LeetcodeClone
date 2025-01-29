#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <cstdlib>
#include <cstring>
#include <iterator>
#include "solution.h"

int main()
{
    // Print environment variable
    const char *envVariable2 = std::getenv("JOB_COMPLETION_INDEX");
    std::cout << "JOB_INDEX: " << (envVariable2 ? envVariable2 : "Not Set") << std::endl;

    // Read file content
    std::string content;
    std::ifstream file(std::string("/etc/config/input-") + (envVariable2 ? envVariable2 : ""));
    if (file)
    {
        std::ostringstream ss;
        ss << file.rdbuf();
        content = ss.str();
    }
    else
    {
        std::cerr << "Error reading file" << std::endl;
        return 1;
    }

    // Split content into arguments
    std::istringstream iss(content);
    std::vector<std::string> args((std::istream_iterator<std::string>(iss)), std::istream_iterator<std::string>());

    // Combine arguments into a single string
    std::string input;
    for (const auto &arg : args)
    {
        input += arg + " ";
    }
    input = input.substr(0, input.size() - 1);

    // Split the input based on the # symbol
    size_t pos = input.find('#');
    if (pos == std::string::npos)
    {
        std::cerr << "Invalid input format! Expected format: numbers target # result" << std::endl;
        return 1;
    }

    std::string numbersPart = input.substr(0, pos);
    std::string resultPart = input.substr(pos + 1);

    // Parse numbers before #
    std::istringstream numStream(numbersPart);
    std::vector<int> nums;
    int value;
    while (numStream >> value)
    {
        nums.push_back(value);
    }
    if (nums.empty())
    {
        std::cerr << "Invalid input! No numbers provided." << std::endl;
        return 1;
    }
    int target = nums.back();
    nums.pop_back();

    // Parse expected result after #
    std::istringstream resultStream(resultPart);
    std::vector<int> expectedResult;
    while (resultStream >> value)
    {
        expectedResult.push_back(value);
    }

    try
    {
        // Call the twoSum method
        Solution sol;
        std::vector<int> result = sol.twoSum(nums, target);

        // Compare result with expected result
        if (result == expectedResult)
        {
            std::cout << "true" << std::endl;
        }
        else
        {
            std::cout << "false" << std::endl;
        }

        std::cout << "["; // Start the array print
        for (size_t i = 0; i < result.size(); ++i)
        {
            std::cout << result[i];
            if (i != result.size() - 1)
            {
                std::cout << ","; // Add comma if it's not the last element
            }
        }
        std::cout << "]" << std::endl;
    }
    catch (const std::exception &e)
    {
        std::cerr << "error" << std::endl;
        std::cerr << e.what() << std::endl;
    }

    return 0;
}
