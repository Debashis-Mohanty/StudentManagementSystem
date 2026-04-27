import React from "react";
import { useNavigate } from "react-router-dom";

function Navbar() {
  const navigate = useNavigate();

  const logout = () => {
    localStorage.removeItem("token");
    navigate("/");
  };

  return (
    <nav className="navbar navbar-dark bg-dark px-4">
      <span className="navbar-brand">🎓 Student Management</span>

      <button className="btn btn-outline-light" onClick={logout}>
        Logout
      </button>
    </nav>
  );
}

export default Navbar;