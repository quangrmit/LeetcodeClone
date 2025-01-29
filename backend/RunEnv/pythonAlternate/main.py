import os
import sys
import traceback

from solution import Solution

def main():
    # Print environment variable
    env_variable2 = os.getenv("JOB_COMPLETION_INDEX")
    print("JOB_INDEX:", env_variable2 if env_variable2 else "Not Set")

    # Read file content
    content = ""
    try:
        with open(f"/etc/config/input-{env_variable2}", "r") as file:
            content = file.read()
    except Exception as e:
        print("Error reading file:", str(e))

    # Combine arguments into a single string
    args = content.split()
    input_str = " ".join(args).strip()

    # Split the input based on the # symbol
    parts = input_str.split("#")
    if len(parts) != 2:
        print("Invalid input format! Expected format: numbers target # result", file=sys.stderr)
        return

    # Parse the numbers before the # symbol
    num_strings = parts[0].strip().split()
    nums = list(map(int, num_strings[:-1]))

    # Target value is the last number before #
    target = int(num_strings[-1])

    # Parse the expected result after the # symbol
    expected_result_strings = parts[1].strip().split()
    expected_result = list(map(int, expected_result_strings))

    try:
        # Call the two_sum method
        sol = Solution()
        result = sol.twoSum(nums, target)

        # Compare the result with the expected result
        if result == expected_result:
            print("true")
            print(result)
        else:
            print("false")
            print(result)

    except Exception as e:
        print("error")
        print(traceback.format_exc())

if __name__ == "__main__":
    main()
