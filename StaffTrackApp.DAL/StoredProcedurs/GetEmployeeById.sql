CREATE PROCEDURE GetEmployeeById
    @EmployeeId INT
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE Id = @EmployeeId;
END;
