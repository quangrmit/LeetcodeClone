import { useState, useEffect, useRef, useCallback } from "react";
import viteLogo from "/vite.svg";
import "./App.css";
// import hljs from "highlight.js";
// import "highlight.js/styles/github-dark.css";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/HomePage";
import ProblemPage from "./pages/ProblemPage";
import { Select, MenuItem, FormControl, InputLabel } from "@mui/material";

// import 'codemirror/theme/tokyo-night.css';
// import { tokyoNight, tokyoNightInit, tokyoNightStyle } from "@uiw/codemirror-theme-tokyo-night";
// // import ReactMardown from "react-markdown";
// // import  from "react-markdown";
// import Markdown from "react-markdown";
// import { Divider } from "@mui/material";

import { ThemeProvider, createTheme } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";

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
    const darkTheme = createTheme({
        palette: {
            mode: "dark",
        },
    });
    return (
        <ThemeProvider theme={darkTheme}>
            <CssBaseline />
            <div className="poppins-regular">
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
            </div>
        </ThemeProvider>
    );
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
