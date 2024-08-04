
CREATE PROCEDURE enterLecturer
    @Name NVARCHAR(50),
    @Address NVARCHAR(100),
    @County NVARCHAR(50),
    @Age INT,
    @Phone NVARCHAR(15),
    @Email NVARCHAR(50),
    @Pay DECIMAL(10, 2),
    @Gender NVARCHAR(10),
	@Subject NVARCHAR(255)
AS
BEGIN
    INSERT INTO LecturerData (Name, Address, County, Age, Phone, Email, Pay, Gender,Subject)
    VALUES (@Name, @Address, @County, @Age, @Phone, @Email, @Pay, @Gender,@Subject);
END;