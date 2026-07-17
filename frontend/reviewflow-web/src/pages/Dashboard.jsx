import { useState } from "react";
import api from "../services/api";

export default function Dashboard() {
    const [studentName, setStudentName] = useState("");
    const [facultyName, setFacultyName] = useState("");
    const [projectTitle, setProjectTitle] = useState("");
    const [status, setStatus] = useState("Pending");
    const [reviewId, setReviewId] = useState("");
    const [reviewCount, setReviewCount] = useState(0);
    const [jsonResponse, setJsonResponse] = useState("");

    const [parsedReview, setParsedReview] = useState(null);

    const [logs, setLogs] = useState([]);
    function addLog(message) {
        setLogs(prev => [
            `[${new Date().toLocaleTimeString()}] ${message}`,
            ...prev
        ]);
    }

    async function getAllReviews() {
        try {
            addLog("GET /api/Review");

            const response = await api.get("/Review");

            setReviewCount(response.data.length);

            setJsonResponse(
                JSON.stringify(response.data, null, 4)
            );

            addLog(`${response.data.length} Reviews Loaded`);
        }
        catch {
            addLog("GET Failed");
        }
    }


    async function getReviewById() {
        if (reviewId === "") {
            addLog("Please enter a Review ID");
            return;
        }

        try {
            addLog(`GET /api/Review/${reviewId}`);

            const response = await api.get(`/Review/${reviewId}`);

            setJsonResponse(
                JSON.stringify(response.data, null, 4)
            );

            setParsedReview(response.data);

            addLog("200 OK");
        }
        catch (error) {
            addLog("404 Not Found");
        }
    }

    async function postReview() {
        try {
            addLog("POST /api/Review");

            const review =
            {
                studentName,
                facultyName,
                projectTitle,
                status
            };

            const response = await api.post("/Review", review);

            setJsonResponse(
                JSON.stringify(review, null, 4)
            );

            setParsedReview(review);

            addLog("201 Created");

            setStudentName("");
            setFacultyName("");
            setProjectTitle("");
            setStatus("Pending");
        }
        catch {
            addLog("POST Failed");
        }
    }

    async function updateReview() {
        if (reviewId === "") {
            addLog("Enter Review ID");
            return;
        }

        try {
            addLog(`PUT /api/Review/${reviewId}`);

            const review =
            {
                studentName,
                facultyName,
                projectTitle,
                status
            };

            await api.put(`/Review/${reviewId}`, review);

            setJsonResponse(
                JSON.stringify(review, null, 4)
            );

            setParsedReview(review);

            addLog("200 Updated");
        }
        catch {
            addLog("PUT Failed");
        }
    }

    async function deleteReview() {
        if (reviewId === "") {
            addLog("Enter Review ID");
            return;
        }

        try {
            addLog(`DELETE /api/Review/${reviewId}`);

            await api.delete(`/Review/${reviewId}`);

            setParsedReview(null);

            setJsonResponse("");

            addLog("200 Deleted");
        }
        catch {
            addLog("DELETE Failed");
        }
    }
    return (

        <div className="container mt-4">

            <h2>ReviewFlow API Demo</h2>

            <h5>Total Reviews : {reviewCount}</h5>

            <hr />

            <div className="row">

                <div className="col-md-6">

                    <label>Student Name</label>

                    <input
                        className="form-control"
                        value={studentName}
                        onChange={(e) => setStudentName(e.target.value)}
                    />

                    <br />

                    <label>Faculty Name</label>

                    <input
                        className="form-control"
                        value={facultyName}
                        onChange={(e) => setFacultyName(e.target.value)}
                    />

                    <br />
                    <label>Project Title</label>
                    <input
                        className="form-control"
                        value={projectTitle}
                        onChange={(e) => setProjectTitle(e.target.value)}
                    />


                    <br />

                    <label>Status</label>

                    <select
                        className="form-select"
                        value={status}
                        onChange={(e) => setStatus(e.target.value)}
                    >

                        <option>Pending</option>
                        <option>Completed</option>

                    </select>

                    <br />

                    <label>Review ID</label>

                    <input
                        className="form-control"
                        value={reviewId}
                        onChange={(e) => setReviewId(e.target.value)}
                    />

                </div>

                <div className="col-md-6">

                    <h5>Parsed Response</h5>

                    <div className="border rounded p-3">

                        Student : {parsedReview?.studentName}

                        <br />

                        Faculty : {parsedReview?.facultyName}

                        <br />

                        Project : {parsedReview?.projectTitle}

                        <br />

                        Status : {parsedReview?.status}

                    </div>

                    <br />

                    <h5>Raw JSON</h5>

                    <textarea
                        className="form-control"
                        rows="10"
                        value={jsonResponse}
                        readOnly
                    />

                </div>

            </div>

            <hr />

            <button
                className="btn btn-primary me-2"
                onClick={getAllReviews}
            >
                GET ALL
            </button>

            <button
                className="btn btn-info me-2"
                onClick={getReviewById}
            >

                GET BY ID

            </button>

            <button
                className="btn btn-success me-2"
                onClick={postReview}
            >
                POST
            </button>

            <button
                className="btn btn-warning me-2"
                onClick={updateReview}
            >
                PUT
            </button>
            <button
                className="btn btn-danger"
                onClick={deleteReview}
            >
                DELETE
            </button>

            <hr />

            <h5>API Activity</h5>

            <textarea
                className="form-control"
                rows="8"
                value={logs.join("\n")}
                readOnly
            />

        </div>

    );

}