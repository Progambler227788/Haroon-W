CREATE PROCEDURE GetLecturersBySubject
    @Subject NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM LecturerData
    WHERE Subject = @Subject;
END;