CREATE DATABASE Police2
GO
USE Police2
GO
CREATE TABLE [User](
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Login] NVARCHAR(100) NOT NULL UNIQUE,
	[Password] NVARCHAR(100) NOT NULL,
	Surname NVARCHAR(100) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	Patronymic NVARCHAR(100) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(100) NOT NULL,
);
GO
CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(100) NOT NULL
);
GO
CREATE TABLE Request(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	AutoNumber NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
	IdStatus INT NOT NULL,
	IdUser INT NOT NULL,

	CONSTRAINT FK_Request_Status
	FOREIGN KEY (IdStatus) REFERENCES [Status](Id),
	CONSTRAINT FK_Request_User
	FOREIGN KEY (IdUser) REFERENCES [User](Id),
);

GO

INSERT INTO [Status] VALUES
('Новое'),
('Принято'),
('Отказано');

GO



CREATE PROCEDURE AddUser (@Login NVARCHAR(100), @Password NVARCHAR(100), @Surname NVARCHAR(100),
@Name NVARCHAR(100), @Patronymic NVARCHAR(100),
@Email NVARCHAR(100), @Phone NVARCHAR(100))
AS
BEGIN
	INSERT INTO [User] VALUES
	(@Login, @Password, @Surname , @Name , @Patronymic ,
@Email, @Phone );
END;

GO

CREATE PROCEDURE AddRequest(@AutoNumber NVARCHAR(100), @Description NVARCHAR(100),
@IdStatus INT, @IdUser INT)
AS
BEGIN
	INSERT INTO Request VALUES
	(@AutoNumber, @Description,
@IdStatus, @IdUser);
END;

GO

CREATE PROCEDURE EditRequest(@IdRequest INT, @IdStatus INT)
AS
BEGIN
	UPDATE Request
	SET
	IdStatus = @IdStatus
	WHERE Id = @IdRequest
END;