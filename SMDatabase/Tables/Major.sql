CREATE TABLE [dbo].[Major]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[MajorId] VARCHAR(20) NOT NULL,
	[MajorName] NVARCHAR(100) NOT NULL,
    [FacultyId] VARCHAR(20) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_Major] PRIMARY KEY (MajorId), 
    CONSTRAINT [FK_Major_Faculty_FacultyId] FOREIGN KEY ([FacultyId]) REFERENCES [Faculty]([FacultyId]) ON DELETE CASCADE,
)

GO
CREATE TRIGGER [dbo].[Trigger_MajorUpdated]
ON [dbo].[Major]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Major
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [MajorId] in (SELECT DISTINCT MajorId FROM inserted);
    END