--CREATE TABLE Books (
--    BookID INT PRIMARY KEY,
--    Title NVARCHAR(255) NOT NULL,
--    Author NVARCHAR(255) NOT NULL,
--    PublicationYear INT,
--);

---- Insert sample data into the Books table
--INSERT INTO Books (BookID, Title, Author, PublicationYear)
--VALUES
--    (1, 'To Kill a Mockingbird', 'Harper Lee', 1960),
--    (2, '1984', 'George Orwell', 1949),
--    (3, 'The Great Gatsby', 'F. Scott Fitzgerald', 1925),
--    (4, 'Pride and Prejudice', 'Jane Austen', 1813),
--    (5, 'The Catcher in the Rye', 'J.D. Salinger', 1951);
--CREATE PROCEDURE usp_AddBook
--    @Title NVARCHAR(255),
--    @Author NVARCHAR(255),
--    @PublicationYear INT
--AS
--BEGIN
--    INSERT INTO Books (Title, Author, PublicationYear)
--    VALUES (@Title, @Author, @PublicationYear);
--END;

CREATE PROCEDURE usp_GetBooks
AS
BEGIN
    SELECT * FROM Books;
END;



