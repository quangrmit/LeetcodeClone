import { Divider } from "@mui/material";
import { useRef, useContext } from "react";
import Markdown from "react-markdown";
import Showdown from "react-showdown";

import { QuestionContext } from "../pages/ProblemPage";

function DescriptionPanel({ markdown }) {
    const {question} = useContext(QuestionContext);

    const tmpMarkdown = `Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\n\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\n\nYou can return the answer in any order.\n#### Example 1\n>**Input**: nums = [2,7,11,15], target = 9\n**Output**: [0,1]\n**Explanation**: Because nums[0] + nums[1] == 9, we return [0, 1]\n\n#### Example 2\n>**Input**: nums = [3,3], target = 6\n>**Output**: [1,2]\n\n#### Constraints\n- <div class='code'>2 <= nums.length <= 10<sup>4</sup></div>`

    return (
        <div className="description resizable">
            <h3>Problem: {question.questionTitle}</h3>
            <Showdown markdown={tmpMarkdown} />


        </div>
    );
}
scrollBy
export default DescriptionPanel;
// export default OtherDescriptionPanel;
// export default ResizableComponent;