import { Routes } from "react-router-dom";
import ProblemItem from "./ProblemItem";
import { useContext, useEffect } from "react";
import { QuestionProvider } from "../pages/HomePage";

function ProblemList() {

    let {questions} = useContext(QuestionProvider)


    return (
        <div>
                {questions.map((q, i) => {
                    return <ProblemItem key={i} q={q} />;
                })}
        </div>
    );
}

export default ProblemList;
