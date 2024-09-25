
import {useParams} from "react-router-dom";
function Problem () {
    const {id} = useParams();
    console.log(id);
    return (
        <div>Problem {id}</div>
    )
}

export default Problem;