CREATE DATABASE "ReviewFlowDB";

DROP TABLE IF EXISTS "ReviewRequests";

CREATE TABLE "ReviewRequests"
(
    "Id" SERIAL PRIMARY KEY,

    "StudentName" VARCHAR(100) NOT NULL,

    "FacultyName" VARCHAR(100) NOT NULL,

    "ProjectTitle" VARCHAR(100) NOT NULL,

    "Status" VARCHAR(30) NOT NULL
);


INSERT INTO "ReviewRequests"
(
    "StudentName",
    "FacultyName",
    "ProjectTitle",
    "Status"
)
VALUES
(
    'Ashwin',
    'Dr Kumar',
    'Python Project',
    'Pending'
),
(
    'Rahul',
    'Dr Priya',
    'DBMS Assignment',
    'Completed'
),
(
    'Aishwarya',
    'Dr Meena',
    'Machine Learning',
    'Pending'
),
(
    'Karthik',
    'Dr Suresh',
    'Hospital Management',
    'Approved'
),
(
    'Prisha',
    'Dr Arun',
    'ReviewFlow',
    'Completed'
),
(
    'Sakthi',
    'Dr Devi',
    'Placement Portal',
    'Pending'
),
(
    'Harini',
    'Dr Balamurugan',
    'Attendance System',
    'Rejected'
),
(
    'Vignesh',
    'Dr Naveen',
    'Library Management',
    'Pending'
),
(
    'Deepika',
    'Dr Anitha',
    'Student Dashboard',
    'Approved'
),
(
    'Nithin',
    'Dr Rajesh',
    'College ERP',
    'Completed'
);

-- Verify
SELECT * FROM "ReviewRequests";