CREATE TABLE [dbo].[Subject]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[SubjectId] VARCHAR(20) NOT NULL,
	[SubjectName] NVARCHAR(100) NOT NULL,
    [Credit] INT NOT NULL,
    [MajorId] VARCHAR(20) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_Subject] PRIMARY KEY (SubjectId), 
    CONSTRAINT [FK_Subject_Major_MajorId] FOREIGN KEY ([MajorId]) REFERENCES [Major]([MajorId]) ON DELETE CASCADE,
)

GO
CREATE TRIGGER [dbo].[Trigger_SubjectUpdated]
ON [dbo].[Subject]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [Subject]
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [SubjectId] in (SELECT DISTINCT SubjectId FROM inserted);
    END
GO

