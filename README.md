# ReviewFlow Prototype

ReviewFlow is a full-stack review management system built for educational institutions.

The project consists of:

- **Backend:** ASP.NET Core Web API (.NET 10)
- **Database:** PostgreSQL
- **Web Frontend:** React
- **Mobile/Desktop App:** .NET MAUI
- **API Documentation:** Swagger

---

# Project Structure

```
ReviewFlowPrototype
│
├── backend          -> ASP.NET Core Web API
├── frontend         -> React Web Application
├── Client           -> .NET MAUI Mobile/Desktop App
├── database         -> SQL Scripts
└── ReviewFlow.sln
```

---

# Software Required

Install the following software before opening the project.

## 1. Visual Studio 2026

Download:

https://visualstudio.microsoft.com/

During installation, select these workloads:

- ASP.NET and web development
- .NET Multi-platform App UI (MAUI)
- Desktop development with .NET

These workloads install everything required for the backend and MAUI application.

---

## 2. .NET 10 SDK

Download:

https://dotnet.microsoft.com/download

Verify installation:

```cmd
dotnet --version
```

You should see something similar to:

```
10.x.x
```

---

## 3. PostgreSQL 17

Download:

https://www.postgresql.org/download/windows/

During installation:

Remember the password you set for the **postgres** user.

Example:

```
Username : postgres
Password : your_password
```

Install pgAdmin when prompted.

---

## 4. Node.js LTS

Download:

https://nodejs.org/

Verify installation:

```cmd
node -v
npm -v
```

---

# Clone the Repository

Open Command Prompt.

```
https://github.com/ashwin81006/sample-web-api-and-maui-project.git
```

Move into the project.

```
cd sample-web-api-and-maui-project
```

---

# Database Setup

Open **pgAdmin**.

Create a new database named

```
ReviewFlowDB
```

Open

```
database/schema.sql
```

Execute the script.

This creates all required tables.


# Configure the Backend

Navigate to

```
backend/ReviewFlow.Api
```

Rename 

```
appsettings.example.json
```

to

```
appsettings.json
```

Update the connection string.

Example:

```json
{
  "ConnectionStrings": {
    "PostgresConnection": "Host=localhost;Port=5432;Database=ReviewFlowDB;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

---

# Restore NuGet Packages

Open

```
ReviewFlow.sln
```

Visual Studio automatically restores packages.

If required:

```
dotnet restore
```

---

# Install React Packages

Open Terminal.

Navigate to the frontend folder.

```
cd frontend
```

Install dependencies.

```
npm install
```

---

# Running the Backend

In Visual Studio:

Set

```
ReviewFlow.Api
```

as the Startup Project.

Press

```
F5
```

Swagger should open at

```
http://localhost:5110/swagger
```

If Swagger opens successfully, the backend is running correctly.

---

# Running the React Application

Open Terminal.

Navigate to

```
frontend
```

Run

```
npm run dev
```

Open the URL shown in the terminal.

Usually:

```
http://localhost:5173
```

---

# Running the MAUI Application

Open the solution.

Select one of the following targets:

- Windows Machine
- Android Emulator
- Physical Android Device

Press

```
F5
```

---

# Project Workflow

```
                PostgreSQL
                     │
                     ▼
          ASP.NET Core Web API
                     │
        ┌────────────┴────────────┐
        ▼                         ▼
   React Frontend          MAUI Application
```

The frontend and mobile application communicate only with the Web API.

The Web API communicates with PostgreSQL.

---

# Common Commands

Restore packages

```
dotnet restore
```

Build solution

```
dotnet build
```

Run backend

```
dotnet run
```

Install frontend packages

```
npm install
```

Run frontend

```
npm run dev
```

---

# Troubleshooting

## PostgreSQL Connection Failed

- Verify PostgreSQL service is running.
- Verify the password in `appsettings.json`.
- Verify the database `ReviewFlowDB` exists.

---

## React Cannot Reach API

Check that the backend is running.

Open:

```
http://localhost:5110/swagger
```

If Swagger loads, the API is working.

---

## NuGet Packages Missing

Run:

```
dotnet restore
```

---

## npm Packages Missing

Run:

```
npm install
```

---

## Android Emulator Not Found

Open Visual Studio Installer.

Modify Visual Studio.

Ensure the **.NET MAUI** workload is installed.

---

# Contributors

- Backend API
- Database
- React Frontend
- MAUI Application

---
