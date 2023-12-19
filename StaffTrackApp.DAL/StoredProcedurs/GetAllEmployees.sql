CREATE PROCEDURE GetAllEmployeesWithFilters
(
    @DepartmentId INT = NULL,
    @Position NVARCHAR(50) = NULL,
    @Name NVARCHAR(100) = NULL
)
AS
BEGIN
    SELECT *
    FROM dbo.Employees
    WHERE
        (@DepartmentId IS NULL OR DepartmentId = @DepartmentId) AND
        (@Position IS NULL OR PositionID = @Position) AND
        (@Name IS NULL OR FullName = @Name);
END;

