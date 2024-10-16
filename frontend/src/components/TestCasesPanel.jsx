import { Chip } from "@mui/material";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import { useContext, useEffect, useState } from "react";
import TabsContainer from "./TabsContainer";
import DiffRenderer from "./DiffRenderer";
import { ResultContext } from "../pages/ProblemPage";

function TestCasesPanel() {
    
    let {result} = useContext(ResultContext)

    
    return (
        <div>

            {
                result.data.length > 0 ? 

                <TabsContainer
                    names={result.data.map((item, i) => (
                        <Chip
                            label={`Case ${i + 1}`}
                            key={i}
                            icon={
                            item.output == item.result ?
                            <CheckCircleOutlineIcon color={"success"} />
                            :
                            <ErrorOutlineIcon color="error"/>

                        }
                            sx={{ backgroundColor: "black" }}
                        />
                    ))}
                    contents={
                        result.data.map((item, i) => {
                            return <DiffRenderer input={item.input}
                            output={item.output}
                            result={item.result}
                            />
                        })
                    }
                /> : 
                <div> Run your code to see the results here</div>
            }


        </div>
    );
}

export default TestCasesPanel;
