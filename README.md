# ReviewFlow Prototype

ReviewFlow is a full-stack academic review management system designed to simplify project reviews, assignment evaluations, and faculty consultations within educational institutions.

The system consists of a centralized REST API, a React web application, a .NET MAUI mobile/desktop application, and a PostgreSQL database.

---

# Technology Stack

| Layer | Technology |
|--------|------------|
| Backend | ASP.NET Core Web API (.NET 10) |
| Database | PostgreSQL 17 |
| Web Frontend | React + Vite |
| Mobile/Desktop | .NET MAUI |
| ORM | Entity Framework Core |
| API Documentation | Swagger (OpenAPI) |
| Version Control | Git & GitHub |

---

# Project Structure

```text
ReviewFlowPrototype
│
├── backend/
│   └── ReviewFlow.Api
│
├── frontend/
│   └── React Application
│
├── Client/
│   └── ReviewFlow.MAUI
│
├── database/
│   ├── schema.sql
│   └── sample_data.sql
│
├── .gitignore
├── README.md
└── ReviewFlow.sln
```

---

# Architecture

```text
                 PostgreSQL
                      ▲
                      │
            ASP.NET Core Web API
             (Business Logic Layer)
               ▲               ▲
               │               │
        React Web        .NET MAUI App
```

The frontend applications communicate only with the Web API.

The Web API performs all business logic and communicates with PostgreSQL.

---

# Software Requirements

Install the following software before opening the project.

## 1. Visual Studio 2026

Download:

https://visualstudio.microsoft.com/

Install the following workloads:

- ASP.NET and web development
- .NET Multi-platform App UI (MAUI)
- Desktop development with .NET

---

## 2. .NET 10 SDK

Download:

https://dotnet.microsoft.com/download

Verify installation:

```bash
dotnet --version
```

Expected output:

```
10.x.x
```

---

## 3. PostgreSQL 17

Download:

https://www.postgresql.org/download/windows/

During installation:

```
Username : postgres
Password : YOUR_PASSWORD
```

Install **pgAdmin** when prompted.

---

## 4. Node.js LTS

Download:

https://nodejs.org/

Verify installation:

```bash
node -v
npm -v
```

---

# Clone the Repository

```bash
git clone https://github.com/ashwin81006/sample-web-api-and-maui-project.git
cd sample-web-api-and-maui-project
```

---

# Database Setup

Open **pgAdmin**.

Create a database named

```
ReviewFlowDB
```

Execute

```
database/schema.sql
```

---

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

Update the PostgreSQL connection string.

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

```bash
dotnet restore
```

---

# Install Frontend Packages

```bash
cd frontend
npm install
```

---

# Running the Backend

Open

```
ReviewFlow.sln
```

Set

```
ReviewFlow.Api
```

as the Startup Project.

Run

```
F5
```

or

```bash
dotnet run
```

Swagger should open at

```
http://localhost:5110/swagger
```

---

# Running the React Application

```bash
cd frontend
npm run dev
```

Open the URL shown in the terminal.

Usually

```
http://localhost:5173
```

---

# Running the MAUI Application

Open

```
ReviewFlow.sln
```

Choose one of the following targets:

- Windows Machine
- Android Emulator
- Physical Android Device

Press

```
F5
```

---

# Development Workflow

```text
Edit Code
     │
Build
     │
Run Backend
     │
Test Using Swagger
     │
Run React / MAUI
     │
Commit Changes
     │
Push to GitHub
```

---

# API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | `/api/review` | Get all reviews |
| GET | `/api/review/{id}` | Get a review |
| POST | `/api/review` | Create a review |
| PUT | `/api/review/{id}` | Update a review |
| DELETE | `/api/review/{id}` | Delete a review |

---

# Common Commands

Restore packages

```bash
dotnet restore
```

Build

```bash
dotnet build
```

Run backend

```bash
dotnet run
```

Install frontend packages

```bash
npm install
```

Run frontend

```bash
npm run dev
```

---

# Troubleshooting

## PostgreSQL Connection Failed

- Ensure PostgreSQL is running.
- Verify the connection string.
- Ensure `ReviewFlowDB` exists.

---

## Swagger Not Opening

Open

```
http://localhost:5110/swagger
```

If Swagger loads, the backend is working correctly.

---

## React Cannot Connect to API

Ensure the backend is running before starting the React application.

---

## Missing NuGet Packages

```bash
dotnet restore
```

---

## Missing npm Packages

```bash
npm install
```

---

## Android Emulator Not Found

Open **Visual Studio Installer**.

Modify Visual Studio.

Ensure the **.NET MAUI** workload is installed.

---

# Production Deployment (Planned)

The application is designed to be deployed on a Debian Linux server using:

- PostgreSQL
- ASP.NET Core Runtime
- Nginx
- Cloudflare Named Tunnel
- systemd
- OpenSSH

Deployment Architecture

```text
Internet
     │
Cloudflare Tunnel
     │
Nginx
     │
ASP.NET Core API
     │
PostgreSQL
```

This architecture allows multiple ASP.NET Core APIs to run independently on the same server while sharing a single PostgreSQL installation.

---

# Contributors

| Component | Contributor |
|-----------|-------------|
| Backend API | |
| Database | |
| React Frontend | |
| .NET MAUI Application | |

---

## License

This project is intended for educational and academic purposes.
