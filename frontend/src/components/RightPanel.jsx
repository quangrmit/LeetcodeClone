import EditorPanel from "./EditorPanel";
import TestCasesPanel from "./TestCasesPanel";
import { Divider } from "@mui/material";
import { useRef, useState } from "react";

function RightPanel() {
    const resizableRef = useRef(null);

    const [reWidth, setReWidth] = useState(500);

    const handleMouseDown = (e) => {
        console.log("handling mouse down")
        const resizable = resizableRef.current;
        const startX = e.clientX;
        const startWidth = resizable.offsetWidth;

        // Mousemove handler to resize the div
        // console.log(resizable.style.width);
        const handleMouseMove = (moveEvent) => {
            const newWidth = startWidth - (moveEvent.clientX - startX);
            resizable.style.width = `${newWidth}px`; // Dynamically set new width
            setReWidth(newWidth)
        };

        // Remove event listeners after mouse is released
        const handleMouseUp = () => {
            document.removeEventListener("mousemove", handleMouseMove);
            document.removeEventListener("mouseup", handleMouseUp);
        };

        // Attach the event listeners for resizing
        document.addEventListener("mousemove", handleMouseMove);
        document.addEventListener("mouseup", handleMouseUp);
    };

    return (
        <div className="right-panels" ref={resizableRef}>
            <div className="resizer" onMouseDown={handleMouseDown}>
                <Divider orientation="vertical"
                //  style={{ borderColor: "white" }} sx={{borderRightWidth:1}}
                 />
            </div>
            <div className="right-main">
                <EditorPanel width={reWidth}/>
                <TestCasesPanel />
            </div>
        </div>
    );
}

export default RightPanel;
