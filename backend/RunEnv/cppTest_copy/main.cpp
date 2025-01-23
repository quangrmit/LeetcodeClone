#include <fstream>
#include <iostream>
// #include <nlohmann/json.hpp>
#include <string>
#include <any>
// #include "Loader.cpp"
// #include "Solution.h"
#include "Solution.cpp"
#include <stdexcept>
#include <sstream>
#include <vector>

using namespace std;
// using json = nlohmann::json;

void printIntVector(vector<int> vi){
    std::cout << "[" << vi[0];
    for (int i = 1; i < vi.size(); i ++){
        std::cout<< " ," << vi[i] ;
    }
    std::cout << "]" << std::endl;
}

int main(int argc, char* argv[]) {
    // Check if input is provided
    if (argc == 1) {
        std::cerr << "No input provided!" << std::endl;
        return 1;
    }

    // Combine arguments into a single string
    std::ostringstream inputBuilder;
    for (int i = 1; i < argc; i++) {
        inputBuilder << argv[i] << " ";
    }
    std::string input = inputBuilder.str();
    input = input.substr(0, input.size() - 1);  // Trim trailing space

    std::cout << "here is the input" << std::endl << input << std::endl;

    // Split the input based on the '#' symbol
    size_t hashPos = input.find('#');
    if (hashPos == std::string::npos) {
        std::cerr << "Invalid input format! Expected format: numbers target # result" << std::endl;
        return 1;
    }

    std::string numbersPart = input.substr(0, hashPos);
    std::string resultPart = input.substr(hashPos + 1);

    // Parse the numbers before the '#' symbol
    std::istringstream numbersStream(numbersPart);
    std::vector<int> nums;
    int num;
    while (numbersStream >> num) {
        nums.push_back(num);
    }

    if (nums.size() < 1) {
        std::cerr << "Invalid input format! Expected format: numbers target # result" << std::endl;
        return 1;
    }

    // Target value is the last number before #
    int target = nums.back();
    nums.pop_back();  // Remove the target from nums

    // Parse the expected result after the '#' symbol
    std::istringstream resultStream(resultPart);
    std::vector<int> expectedResult;
    while (resultStream >> num) {
        expectedResult.push_back(num);
    }

    // Print parsed data (for testing purposes)
    std::cout << "Parsed numbers: ";
    for (int n : nums) {
        std::cout << n << " ";
    }
    std::cout << "\nTarget: " << target << std::endl;

    std::cout << "Expected result: ";
    for (int res : expectedResult) {
        std::cout << res << " ";
    }
    std::cout << std::endl; // Do we need this line



    try{
        Solution sol = Solution();
        vector<int> result = sol.twoSum(nums, target);

        if (result == expectedResult){
            std::cout << "true" << std::endl;
            printIntVector(result);
        }else{
            std::cout << "false" << std::endl;
            printIntVector(result);
        }

    }catch(const std::invalid_argument& e){
        std::cout << "error: " << e.what() << std::endl;
    }



    return 0;
}