from solution import Solution
import json
import inspect
from typing import List

def main():
	data = {}
	with open("./mount/data.json", "r") as file:
		data = json.load(file)
	
	# Get solution
	answer = Solution()
	func = getattr(answer, data['problem'])

	# Examin test cases
	for testcase in data['data']:
		signature = inspect.signature(func)
		args = list(signature.parameters)
		kwargs = dict(zip(args, testcase['input']))
		# Call function
		testcase['result'] = [func(**kwargs)]

	with open("./mount/res.json", "w") as file:
		json.dump(data, file)

if __name__ == "__main__":
	main()