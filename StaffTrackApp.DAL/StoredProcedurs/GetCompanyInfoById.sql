CREATE PROCEDURE GetCompanyInfoById
    @CompanyId INT
AS
BEGIN
    SELECT ID, CompanyName, About
    FROM CompanyInfo
    WHERE ID = @CompanyId;
END;