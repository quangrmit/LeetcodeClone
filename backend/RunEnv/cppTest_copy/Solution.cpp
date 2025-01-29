#include <iostream>
#include <map>
#include<vector>
using namespace std;

class Solution{
public:
    vector<int> twoSum (vector<int> nums, int target){
        
        map<int, int> archive = {};
        vector<int> answer = {};
        for (int i = 0; i < nums.size(); i ++){
            if (archive.find(nums[i]) == archive.end()){
                archive[target - nums[i]] = i;
            }else {
                answer.push_back(archive.at(nums[i]));
                answer.push_back(i);

            }
        }
        return answer;

    }

};
