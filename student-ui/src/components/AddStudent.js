
import React, { useState } from "react";
import API from "../services/api";
import { useNavigate } from "react-router-dom";

function AddStudent() {
  const navigate = useNavigate();

  const [student, setStudent] = useState({
    name: "",
    email: "",
    age: "",
    course: "",
  });

  const [loading, setLoading] = useState(false);

  // Handle input change
  const handleChange = (e) => {
    setStudent({ ...student, [e.target.name]: e.target.value });
  };

  // Submit form
  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);

    API.post("/student", student)
      .then(() => {
        alert("Student added successfully");
        navigate("/students");
      })
      .catch(() => {
        alert("Failed to add student");
        setLoading(false);
      });
  };

  return (
    <div className="container mt-4">
      <div
        className="card shadow-lg p-4"
        style={{ maxWidth: "600px", margin: "auto" }}
      >
        <h3 className="mb-3 text-center">➕ Add Student</h3>

        <form onSubmit={handleSubmit}>
          {/* Name */}
          <div className="mb-3">
            <label className="form-label">Name</label>
            <input
              className="form-control"
              name="name"
              value={student.name}
              onChange={handleChange}
              placeholder="Enter name"
              required
            />
          </div>

          {/* Email */}
          <div className="mb-3">
            <label className="form-label">Email</label>
            <input
              className="form-control"
              type="email"
              name="email"
              value={student.email}
              onChange={handleChange}
              placeholder="Enter email"
              required
            />
          </div>

          {/* Age */}
          <div className="mb-3">
            <label className="form-label">Age</label>
            <input
              className="form-control"
              type="number"
              name="age"
              value={student.age}
              onChange={handleChange}
              placeholder="Enter age"
              required
            />
          </div>

          {/* Course */}
          <div className="mb-3">
            <label className="form-label">Course</label>
            <input
              className="form-control"
              name="course"
              value={student.course}
              onChange={handleChange}
              placeholder="Enter course"
              required
            />
          </div>

          {/* Buttons */}
          <div className="d-flex justify-content-between">
            <button
              type="submit"
              className="btn btn-success"
              disabled={loading}
            >
              {loading ? "Adding..." : "Add Student"}
            </button>

            <button
              type="button"
              className="btn btn-secondary"
              onClick={() => navigate("/students")}
            >
              Cancel
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default AddStudent;