import { useContext, useEffect, useState } from "react";
import { QuestionContext } from "../pages/ProblemPage";
import { ResultContext } from "../pages/ProblemPage";
import Button from "@mui/material/Button";
import CircularProgress from "@mui/material/CircularProgress";
import { ResLoadingContext } from "../pages/ProblemPage";

function TopPanel() {
    const { question } = useContext(QuestionContext);

    const { result, setResult } = useContext(ResultContext);

    const {resLoading, setResLoading} = useContext(ResLoadingContext)

    const [loading, setLoading] = useState(false);



    return (
        <div>
            {/* <Button variant="contained" onClick={handleSubmit}>
                {
                    !resLoading ? 
                    "Submit"
                    :
                    <CircularProgress size={25} color="black"/>
                }

            </Button> */}
            {/* <button onClick={handleSubmit}>Submit</button> */}
        </div>
    );
}

export default TopPanel;
