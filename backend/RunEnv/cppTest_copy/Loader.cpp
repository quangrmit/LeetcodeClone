#include <iostream>
#include <nlohmann/json.hpp>

#include "Solution.cpp"
using namespace std;
using json = nlohmann::json;

class Loader : Solution {
   private:
    /* data */
   public:
    Loader(/* args */);
    ~Loader();
    json execute(json input) {
        json numJson = input.at(0);
        int target = input.at(1);

        vector<int> res = Solution::twoSum(numJson, target);

        json output = json::array();
        output.push_back(res);
        return output;
    }
};

Loader::Loader(/* args */) {
}

Loader::~Loader() {
}
