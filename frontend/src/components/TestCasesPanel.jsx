import { Chip } from "@mui/material";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
// import DoneIcon from '@mui/icons-material/DoneIcon';
// import ErrorOutlineIcon from '@material-ui/icons/ErrorOutline';
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import { useState } from "react";
import TabsContainer from "./TabsContainer";
// import Tab from "@mui/material/Tab";
// import TabContext from "@mui/lab/TabContext";
// import TabList from "@mui/lab/TabList";
// import TabPanel from "@mui/lab/TabPanel";

function TestCasesPanel() {
    let exampleJson = {
        problem: "twoSum",
        data: [
            {
                input: [[2, 7, 11, 15], 9],
                output: [[0, 1]],
                result: [[0, 1]],
            },
            {
                input: [[3, 2, 4], 6],
                output: [[0, 1]],
                result: [[1, 2]],
            },
            {
                input: [[3, 3], 6],
                output: [[0, 1]],
                result: [[0, 1]],
            },
        ],
    };

    let handleChange = (event, newTabValue) => {
        setTabValue(newTabValue);
    };

    let [tabValue, setTabValue] = useState("one");

    return (
        <div>
            <TabsContainer
                names={exampleJson.data.map((item, i) => (
                    <Chip label={`Case ${i + 1}`} key={i} icon={<CheckCircleOutlineIcon color="success" />} sx={{backgroundColor:"black"}}/>
                ))}
                contents={[]}
            />


            




        </div>
    );
}

export default TestCasesPanel;
