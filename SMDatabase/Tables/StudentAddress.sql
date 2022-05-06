CREATE TABLE [dbo].[StudentAddress]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[StudentId] VARCHAR(20) NOT NULL,
    [Address] NVARCHAR(100) NOT NULL,
    [Ward] NVARCHAR(50) NOT NULL,
    [District] NVARCHAR(50) NOT NULL,
    [Province] NVARCHAR(50) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETUTCDATE(),
	[ModifiedAt] DATETIME2 DEFAULT GETUTCDATE(), 
    CONSTRAINT [PK_StudentAddress] PRIMARY KEY ([StudentId]), 
    CONSTRAINT [FK_StudentAddress_Student_StudentId] 
    FOREIGN KEY ([StudentId]) 
    REFERENCES [Student](StudentId)
    ON DELETE CASCADE,
)

GO

CREATE TRIGGER [dbo].[Trigger_StudentAddressUpdated]
    ON [dbo].[StudentAddress]
    FOR UPDATE
    AS
    BEGIN
        UPDATE StudentAddress
        SET [ModifiedAt] = GETUTCDATE()
        WHERE [StudentId] in (SELECT DISTINCT StudentId FROM inserted);
    END


