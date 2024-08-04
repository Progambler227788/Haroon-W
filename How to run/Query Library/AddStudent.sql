CREATE PROCEDURE usp_AddStudent
    @name NVARCHAR(255),
    @age INT,
    @email NVarchar(255)
AS
BEGIN
    INSERT INTO Student(name, age, email)
    VALUES (@name, @age, @email);
END;