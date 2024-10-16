import { useEffect } from "react";

export default function DiffRenderer({ input, output, result }) {

    useEffect(() => {
        console.log(input)
    }, [])

    return (
        <div>
            <div>{JSON.stringify(input)}</div>
            <div>{JSON.stringify(output)}</div>
            <div>{JSON.stringify(result)}</div>
        </div>
    );
}
