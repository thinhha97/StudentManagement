CREATE TABLE [dbo].[Class]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[ClassId] VARCHAR(20) NOT NULL,
	[ClassName] NVARCHAR(100) NOT NULL,
    [MajorId] VARCHAR(20) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_Class] PRIMARY KEY ([ClassId]), 
    CONSTRAINT [FK_Class_Major_MajorId] FOREIGN KEY ([MajorId]) REFERENCES [Major]([MajorId]) ON DELETE CASCADE,
)

GO

CREATE TRIGGER [dbo].[Trigger_ClassUpdated]
    ON [dbo].[Class]
    FOR UPDATE
    AS
    BEGIN
        UPDATE Class
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [ClassId] in (SELECT DISTINCT ClassId FROM inserted);
    END
