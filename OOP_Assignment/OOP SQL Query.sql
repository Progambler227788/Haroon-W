--CREATE TABLE StudentData (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Name NVARCHAR(50) NOT NULL,
--    Address NVARCHAR(100) NOT NULL,
--    County NVARCHAR(50) NOT NULL,
--    Age INT NOT NULL,
--    Phone NVARCHAR(15) NOT NULL,
--    Email NVARCHAR(100) NOT NULL,
--    StudentNumber NVARCHAR(30) NOT NULL
--);

--CREATE TABLE LecturerData (
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Name NVARCHAR(50) NOT NULL,
--    Address NVARCHAR(100) NOT NULL,
--    County NVARCHAR(50) NOT NULL,
--    Age INT NOT NULL,
--    Phone NVARCHAR(15) NOT NULL,
--    Email NVARCHAR(50) NOT NULL,
--    Pay DECIMAL(10, 1) NOT NULL,
--    Gender NVARCHAR(14) NOT NULL
--);

---- Inserting three records into StudentData table
--INSERT INTO StudentData (Name, Address, County, Age, Phone, Email, StudentNumber)
--VALUES
--    ('David Warner', 'Malaysia IOPO', 'Beijing', 20, '155-12349', 'DavidWarner@example.com', 'M12345'),
--    ('Virat Jamima', 'France Chowking', 'Ostria', 22, '554-5678', 'Virat Jamima@gmail.com', 'N64890'),
--    ('Cobson', 'Chinise Street', 'Guta', 25, '525-9876', 'BCOB34@hotmail.com', 'A13579');

--    -- Inserting three records into EmployeeData table
--INSERT INTO LecturerData (Name, Address, County, Age, Phone, Email, Pay, Gender)
--VALUES
--    ('Poye Jingo', 'Under Water City', 'Erangel', 10, '555-1111', 'tenny@gmail.com', 70000.00, 'Female'),
--    ('Davis Weise', 'Pochinki', 'Miramar', 34, '555-2222', 'Weise33@hotmail.com', 20000.00, 'Male'),
--    ('Morgan Charley', 'Novo', 'Jingi', 26, '555-3333', 'MrMorgan23@gmail.com', 55000.00, 'Female');


--CREATE PROCEDURE enterStudent
--    @Name NVARCHAR(50),
--    @Address NVARCHAR(100),
--    @County NVARCHAR(50),
--    @Age INT,
--    @Phone NVARCHAR(15),
--    @Email NVARCHAR(50),
--    @StudentNumber NVARCHAR(20),
--	@Program NVARCHAR(255)
--AS
--BEGIN
--    INSERT INTO StudentData (Name, Address, County, Age, Phone, Email, StudentNumber,Program)
--    VALUES (@Name, @Address, @County, @Age, @Phone, @Email, @StudentNumber,@Program);
--END;


--CREATE PROCEDURE getLecturers
--AS
--BEGIN
--    SELECT * FROM LecturerData;
--END;

--CREATE PROCEDURE GetHighestPaidLecturer
--AS
--BEGIN
--    SELECT TOP 1 * FROM LecturerData ORDER BY Pay DESC;
--END;


--CREATE PROCEDURE enterLecturer
--    @Name NVARCHAR(50),
--    @Address NVARCHAR(100),
--    @County NVARCHAR(50),
--    @Age INT,
--    @Phone NVARCHAR(15),
--    @Email NVARCHAR(50),
--    @Pay DECIMAL(10, 2),
--    @Gender NVARCHAR(10),
--	@Subject NVARCHAR(255)
--AS
--BEGIN
--    INSERT INTO LecturerData (Name, Address, County, Age, Phone, Email, Pay, Gender,Subject)
--    VALUES (@Name, @Address, @County, @Age, @Phone, @Email, @Pay, @Gender,@Subject);
--END

--CREATE PROCEDURE GetLecturersBySubject
--    @Subject NVARCHAR(50)
--AS
--BEGIN
--    SELECT *
--    FROM LecturerData
--    WHERE Subject = @Subject;
--END

--CREATE PROCEDURE getMaleLecturers
--AS
--BEGIN
--    SELECT * FROM LecturerData where Gender = 'Male';
--END;


--CREATE PROCEDURE getStudents
--AS
--BEGIN
--    SELECT * FROM StudentData;
--END;


--CREATE PROCEDURE getStudentsAbove25
--AS
--BEGIN
--    SELECT * FROM StudentData WHERE Age > 25;
--END;

--CREATE PROCEDURE GetStudentsByProgram
--    @Program NVARCHAR(50)
--AS
--BEGIN
--    SELECT *
--    FROM StudentData
--    WHERE Program = @Program;
--END;