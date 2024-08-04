CREATE PROCEDURE getStudentsByNamePattern
AS
BEGIN
    SELECT * FROM StudentData WHERE Name LIKE 'A%' OR Name LIKE 'a%';
END;