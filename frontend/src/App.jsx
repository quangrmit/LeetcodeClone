import React, { useState, useEffect, useRef, useCallback } from "react";
import viteLogo from "/vite.svg";
import "./App.css";

import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/HomePage";
import ProblemPage from "./pages/ProblemPage";



import { ThemeProvider, createTheme } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";

function App() {
    const darkTheme = createTheme({
        palette: {
            mode: "dark",
        },
    });
    return (
        <ThemeProvider theme={darkTheme}>
            <CssBaseline />
            <div className="all wrapper">
                <Router>
                <nav> 
                    <Link to="/">Home</Link>
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
export default App;
