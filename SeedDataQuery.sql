USE EFCoreDB1
GO

Truncate table Students;
GO

INSERT INTO Standards VALUES('1st', 'First-Standard');
INSERT INTO Standards VALUES('2nd', 'Second-Standard');
INSERT INTO Standards VALUES('3rd', 'Third-Standard');
GO

INSERT INTO Students VALUES('Pranaya', 'Rout', '1988-02-29', 5.10, 72, 1);
INSERT INTO Students VALUES('Mahesh', 'Kumar', '1992-12-15', 5.11, 75, 2);
INSERT INTO Students VALUES('Hina', 'Sharma', '1986-10-20', 5.5, 65, 3);
GO