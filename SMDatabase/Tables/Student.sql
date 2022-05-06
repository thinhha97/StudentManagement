CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[StudentId] VARCHAR(20) NOT NULL,
	[Surname] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(20) NOT NULL,
    [DateOfBirth] DATETIME2 NOT NULL,
    [Gender] NVARCHAR(3) NOT NULL,
    [ClassId] VARCHAR(20) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_Student] PRIMARY KEY ([StudentId]), 
    CONSTRAINT [FK_Student_Class_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Class]([ClassId]) ON DELETE CASCADE,
)

GO

CREATE TRIGGER [dbo].[Trigger_StudentUpdated]
    ON [dbo].[Student]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Class
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [ClassId] in (SELECT DISTINCT ClassId FROM inserted);
    END

