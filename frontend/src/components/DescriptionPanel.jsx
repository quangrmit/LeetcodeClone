import { Divider } from "@mui/material";
import { useRef } from "react";
import Markdown from "react-markdown";
import Showdown from "react-showdown";

function DescriptionPanel({ markdown }) {

    return (
        <div className="description resizable">
            <Showdown markdown={markdown} />


        </div>
    );
}
scrollBy
export default DescriptionPanel;
// export default OtherDescriptionPanel;
// export default ResizableComponent;