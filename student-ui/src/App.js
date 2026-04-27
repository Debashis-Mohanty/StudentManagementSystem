
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./components/Login";
import StudentList from "./components/StudentList";
import AddStudent from "./components/AddStudent";
import EditStudent from "./components/EditStudent";
import Navbar from "./components/Navbar";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />

        <Route
          path="/students"
          element={
            <>
              <Navbar />
              <StudentList />
            </>
          }
        />

        <Route
          path="/add"
          element={
            <>
              <Navbar />
              <AddStudent />
            </>
          }
        />

        <Route
          path="/edit/:id"
          element={
            <>
              <Navbar />
              <EditStudent />
            </>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;