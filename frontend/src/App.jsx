import { useState, useEffect, useRef } from "react";
import viteLogo from "/vite.svg";
import "./App.css";
import hljs from "highlight.js";
import "highlight.js/styles/github-dark.css";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/HomePage";
import ProblemPage from "./pages/ProblemPage";

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';

import {EditorView, basicSetup} from "codemirror";
import {javascript} from "codemirror"

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
        // <Router>
        //     <nav>
        //         <Link to="/">Home</Link>
        //         <Link to="/problem">Problem</Link>
        //     </nav>
        //     <Routes>
        //         <Route path="/" element={<Home />} />
        //         <Route path="/problem" element={<ProblemPage />} />
        //     </Routes>
        // </Router>

// import * as React from 'react';
      // <MultilineTextFields/>
      // <CodeEditor/>
      <div></div>

    );
}
function MultilineTextFields() {
  useEffect(() => {
    hljs.highlightAll(); // Initialize highlighting
}, []);
  return (

      <div>
        <pre>

        <code className="javascript">

        <TextField
          id="outlined-multiline-static"
          // label="Multiline"
          multiline
          rows={4}
          defaultValue="Default Value"
          />
          </code>
          </pre>
      </div>
  );
}

const CodeEditor = () => {
  const editorRef = useRef(null);

  useEffect(() => {
    // Initialize CodeMirror editor
    const editorInstance = CodeMirror(editorRef.current, {
      value: 'console.log("Hello, world!");',
      mode: 'javascript',
      theme: 'material', // Optional: specify a theme
      lineNumbers: true,
    });

    return () => {
      editorInstance.toTextArea(); // Cleanup CodeMirror on component unmount
    };
  }, []);

  return <div ref={editorRef} style={{ height: '300px' }} />;
};

// export default CodeEditor;

// function App() {
//     const code = `
//     function helloWorld() {
//       console.log("Hello, world!");
//     }
//   `;

//     return (
//         <div>
//             {/* <h1>Code Highlight Example</h1> */}
//             <CodeBlock language="javascript" value={code} />
//         </div>
//     );
// }

export default App;
