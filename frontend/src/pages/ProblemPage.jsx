import TopPanel from "../components/TopPanel";
import DescriptionPanel from "../components/DescriptionPanel";
// import TopPanel from "../components/TopPanel";
import TestCasesPanel from "../components/TestCasesPanel";
import EditorPanel from "../components/EditorPanel";
// import Markdown from 'react-markdown';
import { Divider } from "@mui/material";
import RightPanel from "../components/RightPanel";

import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

function Problem() {
    const { id } = useParams();
    console.log(id);
    const [question, setQuestion] = useState({});
    useEffect(() => {
        const fetchData = async () => {
            let url = `http://localhost:5014/api/Question/${id}`;
            let res = await fetch(url);
            let data = await res.json();
            setQuestion({ ...data });
            console.log(data);
        };
        fetchData();
    }, [id])


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
                <TopPanel />
                <div className="down-panels">
                    <DescriptionPanel markdown={markdown} />
                    <RightPanel />
                </div>
                {/* <div className="test">hiw</div> */}
            </div>
        </div>
    );
}

export default Problem;
