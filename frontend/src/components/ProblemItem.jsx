import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

function ProblemItem({ q }) {
    return (
        <div className="problem-item">
                <Link key={q.questionId} to={`/${q.questionId}`}>
                    {q.questionId}. {q.questionTitle}
                </Link>
        </div>
    );
}

export default ProblemItem;
