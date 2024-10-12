import { python } from "@codemirror/lang-python";
import { cpp } from "@codemirror/lang-cpp";
// import 'codemirror/theme/tokyo-night.css';
import { tokyoNight, tokyoNightInit, tokyoNightStyle } from "@uiw/codemirror-theme-tokyo-night";
import { java } from "@codemirror/lang-java";

import { useState, useCallback, useEffect, useRef, useContext } from "react";
import CodeMirror from "@uiw/react-codemirror";
import { Select, MenuItem, FormControl, InputLabel, FormHelperText, Divider } from "@mui/material";
import { CodeTemplateContext } from "../pages/ProblemPage";

function EditorPanel({ language, width }) {
    //Load data from localstorage
    const [lang, setLang] = useState("");

    const handleChange = (event) => {
        setLang(event.target.value);
    };

    const [height, setHeight] = useState(200);

    useEffect(() => {
        console.log(height);
    }, [height]);

    const editorResizerRef = useRef(null);

    const handleMouseDown = (e) => {
        console.log("here");
        const resizable = editorResizerRef.current;
        const startY = e.clientY;
        const startHeight = resizable.offsetHeight;

        // Mousemove handler to resize the div
        // console.log(resizable.style.width);
        const handleMouseMove = (moveEvent) => {
            const newHeight = startHeight + (moveEvent.clientY - startY);
            console.log(`new height ${newHeight}`);
            resizable.style.height = `${newHeight}px`; // Dynamically set new width
            setHeight(newHeight);
        };

        // Remove event listeners after mouse is released
        const handleMouseUp = () => {
            document.removeEventListener("mousemove", handleMouseMove);
            document.removeEvKentListener("mouseup", handleMouseUp);
        };

        // Attach the event listeners for resizing
        document.addEventListener("mousemove", handleMouseMove);
        document.addEventListener("mouseup", handleMouseUp);
    };

    // let age = 5;
    return (
        <div className="editor">
            {/* Create a panel for choosing the language */}
            <FormControl sx={{ m: 1, minWidth: 120 }}>
                <Select
                    value={lang}
                    onChange={handleChange}
                    displayEmpty
                    inputProps={{ "aria-label": "Without label" }}
                    defaultValue="python"
                >
                    <MenuItem value="">Python</MenuItem>
                    <MenuItem value="java">Java</MenuItem>
                    <MenuItem value="cpp">C++</MenuItem>
                </Select>
            </FormControl>
            <div ref={editorResizerRef}>
                <Editor language={lang} height={height} width={width} />
            </div>
            <div className="editor-resizer" onMouseDown={handleMouseDown}>
                <Divider
                    orientation="horizontal"
                    style={{ borderColor: "white" }}
                    sx={{ borderBottomWidth: 3 }}
                />
            </div>

            {/* EditorPanel */}
        </div>
    );
}

function Editor({ language, height, width }) {
    // const [value, setValue] = useState(`print("hello")`);

    const langContext = useContext(CodeTemplateContext);
    const [langObj, setLangObj] = useState({ ...langContext });
    console.log("this is langobj");
    console.log(langObj);

    useEffect(() => {
        console.log(height);
        // console.log(`This is ref `)
    }, [height]);

    useEffect(() => {
        console.log("this is lang context after changing");
        console.log(langContext);
    }, [langContext]);

    let editorRef = useRef(null);
    let value;
    let lang = python();
    let detectLanguage = (language) => {
        if (language == "") {
            lang = python();
            value = langContext.codeTemplates.python;
        } else if (language == "cpp") {
            lang = cpp();
            value = langContext.codeTemplates.cpp;
            // set the value to cpp code
        } else if (language == "java") {
            lang = java();
            value = langContext.codeTemplates.java;
            // set the value to java code
        }
    };

    detectLanguage(language);

    useEffect(() => {
        console.log('langojb changing...')
        console.log(langObj)
    }, [langObj])

    // Get the initial code based on the language
    const onChange = useCallback((val, viewUpdate) => {
        console.log("val:", val);
        // Set the langObj to new value
        console.log(viewUpdate);

        let newObj;
        if (lang == "") {
            newObj = { ...langObj, python: val };
        } else if (lang == "java") {
            newObj = { ...langObj, java: val };
        } else if (lang == "cpp") {
            newObj = { ...langObj, cpp: val };
        }
        setLangObj(newObj);
    }, []);

    return (
        <CodeMirror
            ref={editorRef}
            value={value}
            height={`${height}px`}
            maxHeight={`${height}px`}
            width={`${width}px`}
            extensions={[lang]}
            theme={tokyoNight}
            onChange={onChange}
        />
    );
}

export default EditorPanel;
