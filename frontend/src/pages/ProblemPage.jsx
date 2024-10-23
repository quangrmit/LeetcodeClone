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
import compareObj from "../utils/compareObj";

export const QuestionContext = React.createContext();
export const ResultContext = React.createContext();
export const ResLoadingContext = React.createContext();

function Problem({ questionId }) {
    const { id } = useParams();
    console.log(id);

    const [question, setQuestion] = useState(JSON.parse(localStorage.getItem("question")) || {});

    const [resLoading, setResLoading] = useState(false);

    const [result, setResult] = useState({
        data: [],
    });
    useEffect(() => {
        // check if the current id is the same as the id in the localStorage

        console.log("is this reloading?");
        console.log(JSON.parse(localStorage.getItem("question")));
        const fetchData = async () => {
            let url = `http://localhost:5014/api/Question/${id}`;
            let res = await fetch(url);
            let data = await res.json();
            setQuestion({ ...data, active: "" });
            console.log("here is data")
            console.log(data);
        };
        if (compareObj(question, {}) || question.questionId != id) {
            fetchData();
        } else {
            console.log("otherwise");
        }
    }, [id]);

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
                        <ResLoadingContext.Provider value={{ resLoading, setResLoading }}>
                            <TopPanel />
                            <Divider
                                orientation="horizontal"
                                // style={{ borderColor: "white" }}
                                // sx={{ borderBottomWidth: 0.5 }}
                            />
                            <div className="down-panels">
                                <DescriptionPanel markdown={question.content} />
                                <RightPanel />
                            </div>
                            {/* <div className="test">hiw</div> */}
                        </ResLoadingContext.Provider>
                    </ResultContext.Provider>
                </QuestionContext.Provider>
            </div>
        </div>
    );
}

export default Problem;
