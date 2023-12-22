CREATE PROCEDURE GetAverageSalaryByDepartments
AS
BEGIN
    SELECT d.DepartmentID, d.DepartmentName, AVG(e.Salary) AS AverageSalary
    FROM dbo.Employees e
    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
    GROUP BY d.DepartmentID, d.DepartmentName;
END;

