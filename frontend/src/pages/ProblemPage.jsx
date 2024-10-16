import TopPanel from "../components/TopPanel";
import DescriptionPanel from "../components/DescriptionPanel";
// import TopPanel from "../components/TopPanel";
import TestCasesPanel from "../components/TestCasesPanel";
import EditorPanel from "../components/EditorPanel";
// import Markdown from 'react-markdown';
import { Divider } from "@mui/material";
import RightPanel from "../components/RightPanel";

import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import compareObj from "../utils/compareObj"

export const QuestionContext = React.createContext();
export const ResultContext = React.createContext();



function Problem({ questionId }) {
    const { id } = useParams();
    console.log(id);


    const [question, setQuestion] = useState(JSON.parse(localStorage.getItem("question")) || {})

    const [result, setResult] = useState({
        data: [],
    });
    useEffect(() => {
        
        console.log("is this reloading?");
        console.log(JSON.parse(localStorage.getItem("question")))
        const fetchData = async () => {
            let url = `http://localhost:5014/api/Question/${id}`;
            let res = await fetch(url);
            let data = await res.json();
            setQuestion({ ...data, active: "" });
            console.log(data);
        };
        if (compareObj(question, {})) {
            fetchData();
        } else {
            console.log("otherwise");
        }
    }, [id]);

    // Fetch data using useEffect()
    //

    let markdown = `
# Hello World

This is **Markdown** content.

- Item 1
- Item 2
`;

    return (
        <div>
            <div className="problem-page-content">
                <QuestionContext.Provider value={{ question, setQuestion }}>
                    <ResultContext.Provider value={{ result, setResult }}>
                        <TopPanel />
                        <div className="down-panels">
                            <DescriptionPanel markdown={question.content} />
                            <RightPanel />
                        </div>
                        {/* <div className="test">hiw</div> */}
                    </ResultContext.Provider>
                </QuestionContext.Provider>
            </div>
        </div>
    );
}

export default Problem;
