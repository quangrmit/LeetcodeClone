import { useContext, useEffect, useState } from "react";
import { QuestionContext } from "../pages/ProblemPage";
import { ResultContext } from "../pages/ProblemPage";
import Button from "@mui/material/Button";
import CircularProgress from "@mui/material/CircularProgress";
import { ResLoadingContext } from "../pages/ProblemPage";
import CreateRoomModal from "./CreateRoomModal";
import { CollabConnectionContext } from "../pages/ProblemPage";

function TopPanel() {

    const {username, roomId, joinedRoom, setJoinedRoom} = useContext(CollabConnectionContext)


    // I have some state which is "" at the start but will show value when a form is submitted

    // the problem is I show the value of the form 

    

    return (
        <div className="top-panel">
            <CreateRoomModal/>
            {/* <Button onClick={joinIndiRoom}>Join Room</Button> */}


            {joinedRoom ? username : ""}
            <br />
            {joinedRoom ? roomId : ""}
        </div>
    );
}

export default TopPanel;
