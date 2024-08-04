CREATE PROCEDURE enterStudent
    @Name NVARCHAR(50),
    @Address NVARCHAR(100),
    @County NVARCHAR(50),
    @Age INT,
    @Phone NVARCHAR(15),
    @Email NVARCHAR(50),
    @StudentNumber NVARCHAR(20),
	@Program NVARCHAR(255)
AS
BEGIN
    INSERT INTO StudentData (Name, Address, County, Age, Phone, Email, StudentNumber,Program)
    VALUES (@Name, @Address, @County, @Age, @Phone, @Email, @StudentNumber,@Program);
END;