CREATE TABLE Employee (
    EmployeeCode INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    DateOfBirth DATETIME,
    Gender BIT,
    Department VARCHAR(20),
    Designation VARCHAR(20),
    BasicSalary FLOAT(8)
);

ALTER TABLE Employee
ALTER COLUMN EmployeeCode INT Not null;

INSERT INTO Employee (EmployeeCode, EmployeeName, DateOfBirth, Gender, Department, Designation, BasicSalary)
VALUES (1, 'Abhijit', '1999-03-29', 1, 'IT', 'Software Engineer', 50000.00);

INSERT INTO Employee (EmployeeCode, EmployeeName, DateOfBirth, Gender, Department, Designation, BasicSalary)
VALUES (2, 'Sinha', '1999-10-20', 0, 'HR', 'HR Manager', 60000.00);

select * from Employee where EmployeeCode = 1