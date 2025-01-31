import { Button, FormControl, TextField } from "@mui/material";
import ContentCopyIcon from "@mui/icons-material/ContentCopy";
import generateId from "../utils/generateId";
import { useContext, useEffect, useRef, useState } from "react";
import { CollabConnectionContext, QuestionContext } from "../pages/ProblemPage";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { validateRoomId, validateUsername } from "../utils/inputValidation";

export default function CreateRoomForm({ closeModal }) {
    const { setConnection, username, setUsername, roomId, setRoomId, setJoinedRoom, joinedRoom } =
        useContext(CollabConnectionContext);
    const { setQuestion } = useContext(QuestionContext);

    const changeCodeByActiveLang = (code, activeLang) => {
        if (activeLang == "java") {
            setQuestion((prev) => {
                let newObj = { ...prev, javaAnswerTemplate: code };
                return newObj;
            });
        } else if (activeLang == "cpp") {
            setQuestion((prev) => {
                let newObj = { ...prev, cppAnswerTemplate: code };
                return newObj;
            });
        } else {
            setQuestion((prev) => {
                let newObj = { ...prev, pythonAnswerTemplate: code };
                return newObj;
            });
        }
    };
    const joinRoom = async (user = "default", room = "default") => {
        const newConnection = new HubConnectionBuilder().withUrl("http://localhost:5014/chatHub").build();

        await newConnection.start();
        newConnection.on("ReceiveContent", (content, activeLang) => {
            console.log("received content");
            changeCodeByActiveLang(content, activeLang);
        });

        await newConnection.invoke("JoinRoom", { user, room });

        setConnection(newConnection);
    };

    const showRandomId = () => {
        setRoomId(generateId);
    };

    const copyToClipboard = () => {
        navigator.clipboard.writeText(roomId);
    };

    const createRoom = (user, room) => {
        // cancel the modal
        closeModal();

        // validate input
        if (!validateRoomId(room)) {
            // error handling
        }

        if (!validateUsername(user)) {
            // error handling
        }

        // show room id and username in the TopPanel
        setJoinedRoom(true);

        // call the join room function
        joinRoom(user, room);
    };



    return (
        <div>
            <FormControl>
                <TextField
                    id="outlined-basic"
                    label="Enter room name"
                    variant="outlined"
                    value={roomId}
                    onChange={(e) => setRoomId(e.target.value)}
                />
                <Button onClick={copyToClipboard}>
                    <ContentCopyIcon />
                </Button>
                Or
                <Button onClick={showRandomId}>Generate room ID</Button>
                <TextField
                    id="outlined-basic"
                    label="Enter your name"
                    variant="outlined"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                    <Button onClick={() => createRoom(username, roomId)}>Create Room</Button>
               
            </FormControl>
        </div>
    );
}
