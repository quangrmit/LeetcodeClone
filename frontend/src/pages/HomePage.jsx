import { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import ProblemPage from "./ProblemPage";
import ProblemItem from "../components/ProblemItem";
import ProblemList from "../components/ProblemList";

function Home() {
    const [questions, setQuestions] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            let url = "http://localhost:5014/api/Question";
            let res = await fetch(url);
            res = await res.json();
            setQuestions([...res]);
            console.log(res);
        };
        fetchData();
    }, []);

    return (
        <>
            <div>Problem Set</div>
            <Router>
                <nav>
                    <Link to="/">Home</Link>
                </nav>
                <ProblemList questions={questions} />
                <Routes>
                    <Route path="/:id" element={<ProblemPage/>} />
                    {/* <Route path="/" element={<Home/>}/> */}
                </Routes>
            </Router>
        </>
    );
}

export default Home;
