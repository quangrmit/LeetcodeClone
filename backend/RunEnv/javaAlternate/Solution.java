import java.util.HashMap;
class Solution {
    public int[] twoSum(int[] nums, int target) {
        HashMap<Integer, Integer> archive = new HashMap<Integer, Integer>();
        int[] answer = new int[2];
        for (int i=0; i< nums.length; i++) {
                if (archive.get(nums[i]) == null) {
                    archive.put(target - nums[i],i);
                }
                else {
                    answer[0] = archive.get(nums[i]);
                    answer[1] = i;
                }
        }
        return answer;
    }
}