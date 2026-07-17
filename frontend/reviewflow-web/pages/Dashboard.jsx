import { useState } from "react";
import api from "../../services/api";

export default function Dashboard() {

    const [logs, setLogs] = useState([]);

    function addLog(message)
    {
        setLogs(prev => [
            `${new Date().toLocaleTimeString()}  ${message}`,
            ...prev
        ]);
    }

    async function loadReviews()
    {
        addLog("Calling GET /Review");

        const response = await api.get("/Review");

        addLog(`Success (${response.data.length} Reviews)`);
    }

    async function createReview()
    {
        addLog("Calling POST /Review");

        await api.post("/Review",{

            studentName:"Ashwin",

            facultyName:"Dr Kumar",

            projectTitle:"Demo Project",

            status:"Pending"

        });

        addLog("Review Created");
    }

    return(

        <div className="container mt-5">

            <h2>ReviewFlow Prototype</h2>

            <hr/>

            <button
            className="btn btn-primary me-3"
            onClick={loadReviews}>

            Load Reviews

            </button>

            <button
            className="btn btn-success"
            onClick={createReview}>

            Create Review

            </button>

            <hr/>

            <h4>API Activity</h4>

            <ul>

            {logs.map((log,index)=>

                <li key={index}>{log}</li>

            )}

            </ul>

        </div>

    );

}