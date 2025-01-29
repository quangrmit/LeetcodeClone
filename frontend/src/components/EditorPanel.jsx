import { python } from "@codemirror/lang-python";
import { cpp } from "@codemirror/lang-cpp";
// import 'codemirror/theme/tokyo-night.css';
import { tokyoNight, tokyoNightInit, tokyoNightStyle } from "@uiw/codemirror-theme-tokyo-night";
import { java } from "@codemirror/lang-java";
import Button from "@mui/material/Button";
import { useState, useCallback, useEffect, useRef, useContext } from "react";
import CodeMirror from "@uiw/react-codemirror";
import { Select, MenuItem, FormControl, InputLabel, FormHelperText, Divider } from "@mui/material";
import { QuestionContext } from "../pages/ProblemPage";
import { ResLoadingContext } from "../pages/ProblemPage";
import { ResultContext } from "../pages/ProblemPage";
import { CollabConnectionContext } from "../pages/ProblemPage";
import CircularProgress from "@mui/material/CircularProgress";

function EditorPanel({ language, width }) {
    const { question, setQuestion } = useContext(QuestionContext);
    const { result, setResult } = useContext(ResultContext);

    useEffect(() => {
        // Store the new question in local storage each time it changes

        localStorage.setItem("question", JSON.stringify(question));
        console.log("changing");
        console.log(question);

        console.log("this is local storange after changing");
        console.log(JSON.parse(localStorage.getItem("question")));
    }, [question]);

    //Load data from localstorage

    const handleChange = (event) => {
        setQuestion((prev) => {
            return { ...prev, active: event.target.value };
        });
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

        const handleMouseMove = (moveEvent) => {
            const newHeight = startHeight + (moveEvent.clientY - startY);
            console.log(`new height ${newHeight}`);
            resizable.style.height = `${newHeight}px`; // Dynamically set new width
            setHeight(newHeight);
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
    const { resLoading, setResLoading } = useContext(ResLoadingContext);
    let handleSubmit = async () => {
        console.log("Clicked submit");
        setResLoading(true);
        let ans;

        if (question.active == "cpp") {
            ans = question.cppAnswerTemplate;
        } else if (question.active == "java") {
            ans = question.javaAnswerTemplate;
        } else {
            ans = question.pythonAnswerTemplate;
        }

        let url = "http://localhost:5014/api/Submission";
        let res = await fetch(url, {
            method: "POST",
            body: JSON.stringify({
                QuestionId: question.questionId,
                Answer: ans,
                Language: question.active,
            }),
            headers: {
                "Content-Type": "application/json",
            },
        });
        let data = await res.json();
        setResult(data);
        console.log(data);
    };

    useEffect(() => {
        setResLoading((prev) => !prev);
    }, [result]);
    // let age = 5;
    return (
        <div className="editor">
            {/* Create a panel for choosing the language */}
            <div style={{ display: "flex", justifyContent: "space-between" }}>
                <FormControl sx={{ m: 1, minWidth: 120 }}>
                    <Select
                        value={question.active ? question.active : ""}
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
                <Button sx={{ marginRight: 2, color: "white" }} onClick={handleSubmit}>
                    {!resLoading ? "Submit" : <CircularProgress size={25} color="black" />}
                </Button>
            </div>
            <div ref={editorResizerRef}>
                <Editor question={question} setQuestion={setQuestion} height={height} width={width} />
            </div>
            <div className="editor-resizer" onMouseDown={handleMouseDown}>
                <Divider orientation="horizontal" />
            </div>

            {/* EditorPanel */}
        </div>
    );
}

function Editor({ question, setQuestion, height, width }) {

    const connection = useContext(CollabConnectionContext);


    useEffect(() => {
        console.log(height);
        // console.log(`This is ref `)
    }, [height]);

    let editorRef = useRef(null);
    let value;
    let lang = python();
    let detectLanguage = (language) => {
        if (language == "") {
            lang = python();
            value = question.pythonAnswerTemplate;
        } else if (language == "cpp") {
            lang = cpp();
            value = question.cppAnswerTemplate;
        } else if (language == "java") {
            lang = java();
            value = question.javaAnswerTemplate;
        }
    };
    // useEffect(() => {
    detectLanguage(question.active);
    // }, [])

    // Get the initial code based on the language


    const syncContent  = async (code, activeLang) => {
        console.log("calling sync")
        await connection.invoke("SyncContent", code, activeLang)
    }


    const onChange = useCallback(
        (val, viewUpdate) => {
            syncContent(val, question.active)
        },
        [question]
    );

    return (
        <div>
            <CodeMirror
                ref={editorRef}
                value={value}
                height={`${height}px`}
                maxHeight={`${height}px`}
                width={`${width}px`}
                extensions={[lang]}
                theme={tokyoNight}
                onChange={onChange}
                // onChange={onChange2}
            />
        </div>
    );
}

export default EditorPanel;
