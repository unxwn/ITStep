CREATE TABLE Authors (
	Id int primary key identity,
	Firstname nvarchar(20) not null,
	Surname nvarchar(20) not null,
	YearOfBirth int not null
);

INSERT INTO Authors (Firstname, Surname, YearOfBirth)
VALUES (N'Кліффорд', N'Саймак', 1903),
       (N'Джордж', N'Оруелл', 1902),
       (N'Леся', N'Українка', 1871);