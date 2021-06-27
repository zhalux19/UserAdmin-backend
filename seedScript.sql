CREATE TABLE [dbo].[User] (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName varchar(256),
	LastName varchar(256),
	Email varchar(256),
	IsMale BIT NOT NULL,
	Status BIT NOT NULL
);

INSERT INTO [dbo].[User] VALUES('Jim', 'Lu', 'zhalux19@gmail.com', 1, 1)
