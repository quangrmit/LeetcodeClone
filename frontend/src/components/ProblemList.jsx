import { Routes } from "react-router-dom";
import ProblemItem from "./ProblemItem";

function ProblemList({ questions }) {
    return (
        <div>
                {questions.map((q, i) => {
                    return <ProblemItem key={i} q={q} />;
                })}
        </div>
    );
}

export default ProblemList;
