
import React, { useEffect, useState } from "react";
import API from "../services/api";
import { Link, useNavigate } from "react-router-dom";
import { FaEdit, FaTrash } from "react-icons/fa";

function StudentList() {
    const [students, setStudents] = useState([]);
    const navigate = useNavigate();

    const loadStudents = () => {
        API.get("/student")
            .then((res) => setStudents(res.data))
            .catch(() => {
                alert("Unauthorized. Please login again.");
                navigate("/");
            });
    };

    useEffect(() => {
        loadStudents();
    }, []);

    const deleteStudent = (id) => {
        if (!window.confirm("Are you sure to delete?")) return;

        API.delete(`/student/${id}`)
            .then(() => loadStudents())
            .catch(() => alert("Delete failed"));
    };

    return (
        <div className="container mt-4">
            {/* HEADER */}
            <div className="d-flex justify-content-between align-items-center mb-3">
                <h3>📚 Students</h3>

                <div>
                    <Link to="/add" className="btn btn-success me-2">
                        + Add Student
                    </Link>

                    <button
                        className="btn btn-danger"
                        onClick={() => {
                            localStorage.removeItem("token");
                            navigate("/");
                        }}
                    >
                        Logout
                    </button>
                </div>
            </div>

            {/* TABLE */}
            <div className="card shadow-lg p-3">
                <table className="table table-hover align-middle">
                    <thead className="table-dark">
                        <tr>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Age</th>
                            <th>Course</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <tbody>
                        {students.length === 0 ? (
                            <tr>
                                <td colSpan="5" className="text-center">
                                    No students found
                                </td>
                            </tr>
                        ) : (
                            students.map((s) => (
                                <tr key={s.id}>
                                    <td>{s.name}</td>
                                    <td>{s.email}</td>
                                    <td>{s.age}</td>
                                    <td>{s.course}</td>
                                    <td>
                                        <Link
                                            to={`/edit/${s.id}`}
                                            className="btn btn-warning btn-sm me-2 d-inline-flex align-items-center"
                                        >
                                            <FaEdit style={{ marginRight: "5px" }} />
                                            Edit
                                        </Link>

                                        <button
                                            className="btn btn-danger btn-sm d-inline-flex align-items-center"
                                            onClick={() => deleteStudent(s.id)}
                                        >
                                            <FaTrash style={{ marginRight: "5px" }} />
                                            Delete
                                        </button>
                                    </td>
                                </tr>
                            ))
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default StudentList;