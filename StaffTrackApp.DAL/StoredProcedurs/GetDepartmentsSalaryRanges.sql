CREATE PROCEDURE GetDepartmentsSalaryRanges
AS
BEGIN
    SELECT d.DepartmentID, d.DepartmentName, MIN(e.Salary) AS MinimumSalary, MAX(e.Salary) AS MaximumSalary
    FROM Employees e
    INNER JOIN Department d ON e.DepartmentID = d.ID
    GROUP BY d.DepartmentID, d.DepartmentName
    HAVING MIN(e.Salary) < 5000 AND MAX(e.Salary) > 15000;
END;
