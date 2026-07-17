CREATE DATABASE ReviewFlowDB;

USE ReviewFlowDB;

CREATE TABLE ReviewRequests
(
    Id INT AUTO_INCREMENT PRIMARY KEY,

    StudentName VARCHAR(100),

    FacultyName VARCHAR(100),

    ProjectTitle VARCHAR(100),

    Status VARCHAR(30)
);

INSERT INTO ReviewRequests
(StudentName,FacultyName,ProjectTitle,Status)

VALUES

('Ashwin','Dr Kumar','Python Project','Pending'),

('Rahul','Dr Priya','DBMS Assignment','Completed');