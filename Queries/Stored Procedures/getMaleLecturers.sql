CREATE PROCEDURE getMaleLecturers
AS
BEGIN
    SELECT * FROM LecturerData where Gender = 'Male';
END;