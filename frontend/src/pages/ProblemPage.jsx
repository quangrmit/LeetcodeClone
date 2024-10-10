
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
function Problem() {
    const { id } = useParams();
    const [question, setQuestion] = useState({});
    useEffect(() => {
        const fetchData = async () => {
            let url = `http://localhost:5014/api/Question/${id}`;
            let res = await fetch(url);
            let data = await res.json();
            setQuestion({ ...data });
            console.log(data);
        };
        fetchData();
    }, [id])
    return (
        <>
            <h2>Problem {id}. {question.questionTitle}</h2>
            <p> {question.content}</p>
            <p> {question.pythonAnswerTemplate} </p>
        </>
    )
}

export default Problem;