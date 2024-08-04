CREATE TABLE LecturerData (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    County NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Pay DECIMAL(10, 1) NOT NULL,
    Gender NVARCHAR(14) NOT NULL,
    Subject NVARCHAR(50) NOT NULL
);