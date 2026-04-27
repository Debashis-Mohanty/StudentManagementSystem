
import React, { useState } from "react";
import API from "../services/api";
import { useNavigate } from "react-router-dom";

function Login() {
  const [data, setData] = useState({
    username: "",
    password: "",
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    setData({ ...data, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    API.post("/auth/login", data)
      .then((res) => {
        localStorage.setItem("token", res.data.token);
        navigate("/students");
      })
      .catch(() => {
        alert("Invalid credentials");
      });
  };

  return (
    <div className="d-flex justify-content-center align-items-center vh-100 bg-primary">
      <div
        className="card p-4 shadow-lg"
        style={{ width: "350px", borderRadius: "15px" }}
      >
        <h3 className="text-center mb-3">Welcome Back 👋</h3>

        <form onSubmit={handleSubmit}>
          <input
            className="form-control mb-3"
            name="username"
            placeholder="Username"
            onChange={handleChange}
            required
          />

          <input
            className="form-control mb-3"
            type="password"
            name="password"
            placeholder="Password"
            onChange={handleChange}
            required
          />

          <button className="btn btn-dark w-100">Login</button>
        </form>
      </div>
    </div>
  );
}

export default Login;