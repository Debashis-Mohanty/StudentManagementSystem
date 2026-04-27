# Student Management System

## 📌 Project Overview
This is a full-stack Student Management System built using ASP.NET Core Web API and React. It allows users to manage student records with secure authentication.

---

## 🚀 Features
- 🔐 JWT Authentication (Login)
- 📋 Get all students
- ➕ Add new student
- ✏️ Update student details
- ❌ Delete student
- 📄 Swagger API documentation
- ⚠️ Global Exception Handling

---

## 🛠 Tech Stack

### 🔹 Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication

### 🔹 Frontend
- React JS
- Bootstrap
- Axios

---

## 🗄 Database Schema

**Student Table:**
- Id
- Name
- Email
- Age
- Course
- CreatedDate

---

## ⚙️ Setup Instructions

### 🔹 Backend Setup

1. Open `StudentManagementSystem` in Visual Studio
2. Configure SQL Server connection string in `appsettings.json`
3. Run the project:
```
dotnet run
```
4. Open Swagger:
```
https://localhost:44355/swagger
```

---

### 🔹 Frontend Setup

1. Navigate to frontend folder:
```
cd student-ui
```

2. Install dependencies:
```
npm install
```

3. Run the app:
```
npm start
```

---

## 🔐 Login Credentials

```
Username: Admin
Password: Admin@123
```

---

## 🔗 API Endpoints

- POST `/api/Auth/login`
- GET `/api/Student`
- POST `/api/Student`
- PUT `/api/Student/{id}`
- DELETE `/api/Student/{id}`

---

## 📌 Project Structure

```
Debashis/
├── StudentManagementSystem (Backend)
└── student-ui (Frontend)
```

---

## 📈 Future Improvements
- Role-based authentication
- Pagination & search
- UI enhancements

---

## 👨‍💻 Author
Debashis Mohanty
