import java.util.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.io.*;


public class App {
    public static void main(String[] args) {
        // Print environment variable
        String envVariable2 = System.getenv("JOB_COMPLETION_INDEX");
        System.out.println("JOB_INDEX: " + (envVariable2 != null ? envVariable2 : "Not Set"));

        // Print file content
        String content = "";
        try {
            content = new String(Files.readAllBytes(Paths.get("/etc/config/input-" + envVariable2)));
        } catch (Exception e) {
            System.out.println("Error reading file: " + e.getMessage());
        }

        // Combine arguments into a single string
        args = content.split("\s+");
        StringBuilder inputBuilder = new StringBuilder();
        for (String arg : args) {
            inputBuilder.append(arg).append(" ");
        }
        String input = inputBuilder.toString().trim();

        // Split the input based on the # symbol
        String[] parts = input.split("#");
        if (parts.length != 2) {
            System.err.println("Invalid input format! Expected format: numbers target # result");
            return;
        }

        // Parse the numbers before the # symbol
        String[] numStrings = parts[0].trim().split(" ");
        int[] nums = new int[numStrings.length - 1];
        for (int i = 0; i < numStrings.length - 1; i++) {
            nums[i] = Integer.parseInt(numStrings[i]);
        }

        // Target value is the last number before #
        int target = Integer.parseInt(numStrings[numStrings.length - 1]);

        // Parse the expected result after the # symbol
        String[] expectedResultStrings = parts[1].trim().split(" ");
        int[] expectedResult = new int[expectedResultStrings.length];
        for (int i = 0; i < expectedResultStrings.length; i++) {
            expectedResult[i] = Integer.parseInt(expectedResultStrings[i]);
        }

        try {
            // Call the twoSum method
            Solution sol = new Solution();
            int[] result = sol.twoSum(nums, target);

            // Compare the result with the expected result
            if (Arrays.equals(result, expectedResult)) {
                System.out.println("true");
                System.out.println(Arrays.toString(result));
            } else {
                System.out.println("false");
                System.out.println(Arrays.toString(result));
            }

        } catch (Exception e) {
            System.out.println("error");
            e.printStackTrace(System.out);
        }
    }
}
