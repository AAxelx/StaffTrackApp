CREATE PROCEDURE GetSalaryReport
    @DepartmentId INT = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    SELECT DepartmentID, SUM(Salary) AS TotalSalary
    FROM Employees
    WHERE (@DepartmentId IS NULL OR DepartmentID = @DepartmentId)
        AND (@StartDate IS NULL OR EmploymentDate >= @StartDate)
        AND (@EndDate IS NULL OR EmploymentDate <= @EndDate)
    GROUP BY DepartmentID;
END;

