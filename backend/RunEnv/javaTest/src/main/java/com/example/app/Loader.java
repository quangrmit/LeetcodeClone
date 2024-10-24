package com.example.app;

import java.util.*;
import org.json.JSONArray;
public class Loader extends Solution {

    public Loader() {}

    public JSONArray execute(JSONArray input) {
        try {
            // Convert input to correspond parameter type
            JSONArray numJson = (JSONArray) input.get(0);
            int[] nums = new int[numJson.length()];
            for (int i = 0; i < numJson.length(); i++) {
                nums[i] = (int) numJson.get(i);
            }

            int target = (int) input.get(1);
            int[] res = super.twoSum(nums, target);

            // Format output
            JSONArray output = new JSONArray();
            JSONArray result = new JSONArray();
            for (int i = 0; i < res.length; i++) {
                result.put(res[i]);
            }
            output.put(result);
            return output;
        }
        catch (Exception e) {
            System.out.println(e.toString());
            return null;
        }
    }

}

