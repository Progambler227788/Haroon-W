CREATE PROCEDURE GetStudentsByProgram
    @Program NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM StudentData
    WHERE Program = @Program;
END;