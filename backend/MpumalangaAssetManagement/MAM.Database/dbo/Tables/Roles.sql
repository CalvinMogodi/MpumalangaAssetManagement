CREATE TABLE [dbo].[Roles] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (MAX) NOT NULL,
    [Description]    NVARCHAR (MAX) NOT NULL,
    [CreatedDate]    DATETIME       NOT NULL,
    [ModifiedDate]   DATETIME       NULL,
    [CreatedUserId]  INT            NOT NULL,
    [ModifiedUserId] INT            NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

