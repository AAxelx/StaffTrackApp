CREATE PROCEDURE RemoveDuplicateEmployees
AS
BEGIN
    ;WITH RankedEmployees AS (
       SELECT *,
              ROW_NUMBER() OVER (PARTITION BY FullName, Phone ORDER BY ID DESC) AS rn
       FROM dbo.Employees
    )
    DELETE FROM RankedEmployees WHERE rn > 1;
END;