CREATE PROCEDURE usp_AddBook
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @PublicationYear INT
AS
BEGIN
    INSERT INTO Books (Title, Author, PublicationYear)
    VALUES (@Title, @Author, @PublicationYear);
END;