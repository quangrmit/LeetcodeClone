import React, { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import ProblemPage from "./ProblemPage";
import ProblemItem from "../components/ProblemItem";
import ProblemList from "../components/ProblemList";

export const QuestionProvider = React.createContext(null);

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

                <QuestionProvider.Provider value={{questions, setQuestions}}>
                    <ProblemList />
                </QuestionProvider.Provider>

        </>
    );
}

export default Home;
