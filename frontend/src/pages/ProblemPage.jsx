import { useParams } from "react-router-dom";
import TopPanel from "../components/TopPanel";
import DescriptionPanel from "../components/DescriptionPanel";
// import TopPanel from "../components/TopPanel";
import TestCasesPanel from "../components/TestCasesPanel";
import EditorPanel from "../components/EditorPanel";
// import Markdown from 'react-markdown';
import { Divider } from "@mui/material";
import RightPanel from "../components/RightPanel";

function Problem() {
    const { id } = useParams();
    console.log(id);

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
                    <RightPanel/>
                </div>
                    {/* <div className="test">hiw</div> */}
            </div>
        </div>
    );
}

export default Problem;
