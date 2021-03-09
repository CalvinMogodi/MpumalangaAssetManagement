CREATE TABLE [dbo].[AuditLog] (
    [Id]        NCHAR (10)     NOT NULL,
    [Date]      DATETIME       NOT NULL,
    [Thread]    NVARCHAR (MAX) NULL,
    [Level]     NVARCHAR (MAX) NULL,
    [Logger]    NVARCHAR (MAX) NULL,
    [Message]   NVARCHAR (MAX) NULL,
    [Exception] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AuditLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

