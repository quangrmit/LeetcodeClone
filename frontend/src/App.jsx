import { useState, useEffect, useRef, useCallback } from "react";
import viteLogo from "/vite.svg";
import "./App.css";
// import hljs from "highlight.js";
// import "highlight.js/styles/github-dark.css";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/HomePage";
import ProblemPage from "./pages/ProblemPage";

import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import CodeMirror from '@uiw/react-codemirror';
import { javascript } from '@codemirror/lang-javascript';
import { python } from '@codemirror/lang-python';
import { cpp } from '@codemirror/lang-cpp';
// import 'codemirror/theme/tokyo-night.css';
import {tokyoNight, tokyoNightInit, tokyoNightStyle} from "@uiw/codemirror-theme-tokyo-night";
// import {EditorView, basicSetup} from "codemirror";
// import {javascript} from "codemirror"

const CodeBlock = ({ language, value }) => {
    useEffect(() => {
        hljs.highlightAll(); // Initialize highlighting
    }, []);

    return (
        <pre>
            <code className={language}>{value}</code>
        </pre>
    );
};

function App() {
    return (
        <Router>
            <nav>
                <Link to="/">Home</Link>
                <Link to="/1">Problem</Link>
            </nav>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/:id" element={<ProblemPage />} />
            </Routes>
        </Router>
    )
}
// function App() {
//     const [value, setValue] = useState("console.log('hello world!');");
//     const onChange = useCallback((val, viewUpdate) => {
//         console.log("val:", val);
//         setValue(val);
//     }, []);
//     return (
//         <CodeMirror
//             value={value}
//             height="200px"
//             // extensions={[javascript({ jsx: true })]}
//             extensions={[python()]}
//             theme={tokyoNight}
//             onChange={onChange}
//         />
//     );
// }



export default App;

