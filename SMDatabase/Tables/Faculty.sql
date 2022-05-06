CREATE TABLE [dbo].[Faculty]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[FacultyId] VARCHAR(20) NOT NULL,
	[FacultyName] NVARCHAR(100) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_Faculty] PRIMARY KEY ([FacultyId]),
)

GO

CREATE TRIGGER [dbo].[Trigger_FacultyUpdated]
    ON [dbo].[Faculty]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Faculty
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [FacultyId] in (SELECT DISTINCT FacultyId FROM inserted);
    END