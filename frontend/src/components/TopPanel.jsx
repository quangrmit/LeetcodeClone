

import { useContext } from "react";
import { QuestionContext } from "../pages/ProblemPage";
import { ResultContext } from "../pages/ProblemPage";

function TopPanel() {

    const {question} = useContext(QuestionContext);

    const {setResult} = useContext(ResultContext)

    let handleSubmit = async () => {
        console.log("Clicked submit")
        let ans;

        if (question.active == "cpp"){
            ans = question.cppAnswerTemplate

        }else
        if (question.active == "java"){
            ans = question.javaAnswerTemplate
        }else{
            ans = question.pythonAnswerTemplate
        }   

        let url = "http://localhost:5014/api/Submission";
        let res = await fetch(url, {
            method: "POST",
            body: JSON.stringify( {
                questionId: question.questionId,
                answer: ans
            } )  ,
            headers: {
                "Content-Type": "application/json",
            },
        });
        let data = await res.json();
        setResult(data);
        console.log(data);
    }

    return (
        <div>
            TopPanel
            <button onClick={handleSubmit}>Submit</button>
        </div>
    )
}

export default TopPanel;