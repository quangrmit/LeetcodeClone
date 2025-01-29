import { Chip, CircularProgress, Divider } from "@mui/material";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";
import { useContext, useEffect, useState } from "react";
import TabsContainer from "./TabsContainer";
import DiffRenderer from "./DiffRenderer";
import Accordion from "@mui/material/Accordion";
import AccordionActions from "@mui/material/AccordionActions";
import Button from "@mui/material/Button";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import Paper from '@mui/material/Paper';
import { ResLoadingContext, ResultContext } from "../pages/ProblemPage";
import compareObj from "../utils/compareObj";

function TestCasesPanel() {
    let { result } = useContext(ResultContext);

    const {resLoading}  = useContext(ResLoadingContext);

    return (
        <div className="test-panel">
            {result.length > 0 ? (

                // resLoading ? 
                // <CircularProgress/>
                // : 

                result.map((item, i) => (
                    <Accordion>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1-content"
                            id="panel1-header"
                            sx={{ height: 2 }}
                        >
                            <div className="accordion-sum-wrapper">
                                <Chip
                                    label={`Case ${i + 1}`}
                                    key={i}
                                    icon={
                                        item.status == 'true' ? (
                                            <CheckCircleOutlineIcon color={"success"} />
                                        ) : (
                                            <ErrorOutlineIcon color="error" />
                                        )
                                    }
                                    sx={{ backgroundColor: "inherit" }}
                                />

                                <Chip label={JSON.stringify(item.input)} sx={{ background: "inherit" }} />
                            </div>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Divider/>
                            <DiffRenderer output={item.result} result={item.expected_result} />
                        </AccordionDetails>
                    </Accordion>
                ))
            ) : (
                <div> Run your code to see the results here</div>
            )}
        </div>
    );
}

export default TestCasesPanel;
