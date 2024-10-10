import { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import ProblemPage from "./ProblemPage";


function Home() {
    const [question, setQuestion] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            let url = "http://localhost:5014/api/Question";
            let res = await fetch(url);
            res = await res.json();
            setQuestion([...res]);
            console.log(res);
        }
        fetchData();
    }, [])

    return (
        <>
            <div>Problem Set</div>
            <Router>
                <nav>
                    <Link to="/">Home</Link>
                    {
                        question.map((q) => {
                            return (
                                <Link key={q.questionId} to={`/${q.questionId}`}>{q.questionId}. {q.questionTitle}</Link>
                            )
                        })
                    }
                </nav>
                <Routes>
                    <Route path="/:id" element={<ProblemPage />} />
                </Routes>
            </Router>

        </>

    )
}

export default Home;