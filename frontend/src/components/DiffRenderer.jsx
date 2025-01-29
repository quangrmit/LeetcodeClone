import { useEffect } from "react";
import Paper from "@mui/material/Paper";
import { Divider } from "@mui/material";

export default function DiffRenderer({ output, result }) {
    return (
        <div className="diff-renderer">
            <div style={{display: "flex", flexDirection: 'column', alignItems: 'center'}}>
                <p>Output</p>

                <Paper
                    elevation={5}
                    sx={{
                        width: "fit-content",
                        paddingLeft: 2,
                        paddingRight: 2,
                        paddingTop: 1,
                        paddingBottom: 1,
                    }}
                >
                    {JSON.stringify(output)}{" "}
                </Paper>
            </div>

            <Divider orientation="vertical" />
            <div style={{display: "flex", flexDirection: 'column', alignItems: 'center'}}>
                <p>Result</p>
                <Paper
                    elevation={5}
                    sx={{
                        width: "fit-content",
                        paddingLeft: 2,
                        paddingRight: 2,
                        paddingTop: 1,
                        paddingBottom: 1,
                    }}
                >
                    {JSON.stringify(result)}{" "}
                </Paper>
            </div>
        </div>
    );
}
