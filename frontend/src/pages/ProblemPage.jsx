import TopPanel from "../components/TopPanel";
import DescriptionPanel from "../components/DescriptionPanel";
import { Divider } from "@mui/material";
import RightPanel from "../components/RightPanel";

import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import compareObj from "../utils/compareObj";
import { HubConnectionBuilder } from "@microsoft/signalr";

export const QuestionContext = React.createContext();
export const ResultContext = React.createContext();
export const ResLoadingContext = React.createContext();
export const CollabConnectionContext = React.createContext();

function Problem({ questionId }) {
    const { id } = useParams();
    const [question, setQuestion] = useState(JSON.parse(localStorage.getItem("question")) || {});

    const [resLoading, setResLoading] = useState(false);

    const [result, setResult] = useState({
        data: [],
    });

    const [connection, setConnection] = useState(null);

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
    }

    const joinRoom = async () => {
        const newConnection = new HubConnectionBuilder().withUrl("http://localhost:5014/chatHub").build();

        await newConnection.start();
        newConnection.on("ReceiveContent", (content, activeLang) => {
            console.log("received content");
            changeCodeByActiveLang(content, activeLang);
        });

        let user = "default_user";
        let room = "default_room";
        await newConnection.invoke("JoinRoom", { user, room });

        setConnection(newConnection);
    };

    useEffect(() => {
        // check if the current id is the same as the id in the localStorage

        console.log("is this reloading?");
        console.log(JSON.parse(localStorage.getItem("question")));
        const fetchData = async () => {
            let url = `http://localhost:5014/api/Question/${id}`;
            let res = await fetch(url);
            let data = await res.json();
            setQuestion({ ...data, active: "" });
            console.log("here is data");
            console.log(data);
        };

        if (compareObj(question, {}) || question.questionId != id) {
            fetchData();
        } else {

            console.log("otherwise");
        }
        joinRoom();
    }, [id]);

    let markdown = `
# Hello World

This is **Markdown** content.

- Item 1
- Item 2
`;

    return (
        <div>
            <div className="problem-page-content">
                <QuestionContext.Provider value={{ question, setQuestion }}>
                    <ResultContext.Provider value={{ result, setResult }}>
                        <ResLoadingContext.Provider value={{ resLoading, setResLoading }}>
                            <CollabConnectionContext.Provider value={connection}>
                                <TopPanel />
                                <Divider
                                    orientation="horizontal"
                                    // style={{ borderColor: "white" }}
                                    // sx={{ borderBottomWidth: 0.5 }}
                                />
                                <div className="down-panels">
                                    <DescriptionPanel markdown={question.content} />
                                    <RightPanel />
                                </div>
                                {/* <div className="test">hiw</div> */}
                            </CollabConnectionContext.Provider>
                        </ResLoadingContext.Provider>
                    </ResultContext.Provider>
                </QuestionContext.Provider>
            </div>
        </div>
    );
}

export default Problem;
