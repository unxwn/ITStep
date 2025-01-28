CREATE TABLE StudentGrades (
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(50) NOT NULL,
	GroupName NVARCHAR(20) NOT NULL,
	AverageGrade FLOAT NOT NULL,
	SubjectMinGrade NVARCHAR(30) NOT NULL,
	SubjectMaxGrade NVARCHAR(30) NOT NULL
);

INSERT INTO StudentGrades (FullName, GroupName, AverageGrade, SubjectMinGrade, SubjectMaxGrade)
VALUES
(N'Бабенко Андрій', N'ПВ321', 85.2, N'Математика', N'Програмування'),
(N'Голіченко Владислав', N'ПВ321', 92.5, N'Фізика', N'Англійська мова'),
(N'Антоненко Андрій', N'ПВ321', 74.3, N'Історія України', N'Математика');