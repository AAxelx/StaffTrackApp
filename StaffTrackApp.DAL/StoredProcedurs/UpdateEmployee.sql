CREATE PROCEDURE UpdateEmployeeDetails
    @EmployeeId INT,
    @DepartmentId INT,
    @PositionId INT,
    @FullName NVARCHAR(100),
    @Address NVARCHAR(100),
    @Phone NVARCHAR(20),
    @DateOfBirth DATE,
    @EmploymentDate DATE,
    @Salary DECIMAL(10, 2),
    @CompanyInfoId INT
AS
BEGIN
    UPDATE Employees
    SET
        DepartmentId = @DepartmentId,
        PositionId = @PositionId,
        FullName = @FullName,
        Address = @Address,
        Phone = @Phone,
        DateOfBirth = @DateOfBirth,
        EmploymentDate = @EmploymentDate,
        Salary = @Salary,
        CompanyInfoId = @CompanyInfoId
    WHERE ID = @EmployeeId;
END;

