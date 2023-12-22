CREATE PROCEDURE GetEmployees
(
    @DepartmentIds NVARCHAR(MAX) = NULL,
    @PositionIds NVARCHAR(MAX) = NULL,
    @Name NVARCHAR(100) = NULL
)
AS
BEGIN
    SELECT *
    FROM dbo.Employees
    WHERE
        (@DepartmentIds IS NULL OR DepartmentId IN (SELECT value FROM STRING_SPLIT(@DepartmentIds, ','))) AND
        (@PositionIds IS NULL OR PositionId IN (SELECT value FROM STRING_SPLIT(@PositionIds, ','))) AND
        (@Name IS NULL OR FullName = @Name);
END;