CREATE TABLE [dbo].[FacilityStatus] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (500) NOT NULL,
    [Description] VARCHAR (500) NULL,
    CONSTRAINT [PK_FacilityStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

