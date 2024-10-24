import { useContext, useEffect, useState } from "react";
import { QuestionContext } from "../pages/ProblemPage";
import { ResultContext } from "../pages/ProblemPage";
import Button from "@mui/material/Button";
import CircularProgress from "@mui/material/CircularProgress";

function TopPanel() {
    const { question } = useContext(QuestionContext);

    const { result, setResult } = useContext(ResultContext);

    const [loading, setLoading] = useState(false);

    let handleSubmit = async () => {
        console.log("Clicked submit");
        setLoading(true);   
        let ans;

        if (question.active == "cpp") {
            ans = question.cppAnswerTemplate;
        } else if (question.active == "java") {
            ans = question.javaAnswerTemplate;
        } else {
            ans = question.pythonAnswerTemplate;
        }

        let url = "http://localhost:5014/api/Submission";
        let res = await fetch(url, {
            method: "POST",
            body: JSON.stringify({
                questionId: question.questionId,
                answer: ans,
            }),
            headers: {
                "Content-Type": "application/json",
            },
        });
        let data = await res.json();
        setResult(data);
        console.log(data);
    };

    useEffect(() => {
        setLoading(prev => !prev);
    }, [result])

    return (
        <div>
            <Button variant="contained" onClick={handleSubmit}>
                {
                    !loading ? 
                    "Submit"
                    :
                    <CircularProgress/>
                }

            </Button>
            {/* <button onClick={handleSubmit}>Submit</button> */}
        </div>
    );
}

export default TopPanel;
