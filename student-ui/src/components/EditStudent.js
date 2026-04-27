
import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import API from "../services/api";

function EditStudent() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [student, setStudent] = useState({
    name: "",
    email: "",
    age: "",
    course: "",
  });

  const [loading, setLoading] = useState(true);

  // Load student data
  useEffect(() => {
    API.get(`/student/${id}`)
      .then((res) => {
        setStudent(res.data);
        setLoading(false);
      })
      .catch(() => {
        alert("Failed to load student");
        navigate("/students");
      });
  }, [id, navigate]);

  const handleChange = (e) => {
    setStudent({ ...student, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    API.put(`/student/${id}`, student)
      .then(() => {
        alert("Student updated successfully");
        navigate("/students");
      })
      .catch(() => alert("Update failed"));
  };

  if (loading) {
    return <h3 className="text-center mt-5">Loading...</h3>;
  }

  return (
    <div className="container mt-4">
      <div
        className="card shadow-lg p-4"
        style={{ maxWidth: "600px", margin: "auto" }}
      >
        <h3 className="mb-3">Edit Student</h3>

        <form onSubmit={handleSubmit}>
          <input
            className="form-control mb-3"
            name="name"
            value={student.name}
            onChange={handleChange}
            placeholder="Name"
            required
          />

          <input
            className="form-control mb-3"
            name="email"
            type="email"
            value={student.email}
            onChange={handleChange}
            placeholder="Email"
            required
          />

          <input
            className="form-control mb-3"
            name="age"
            type="number"
            value={student.age}
            onChange={handleChange}
            placeholder="Age"
            required
          />

          <input
            className="form-control mb-3"
            name="course"
            value={student.course}
            onChange={handleChange}
            placeholder="Course"
            required
          />

          <button className="btn btn-primary me-2">Update</button>

          <button
            type="button"
            className="btn btn-secondary"
            onClick={() => navigate("/students")}
          >
            Cancel
          </button>
        </form>
      </div>
    </div>
  );
}

export default EditStudent;