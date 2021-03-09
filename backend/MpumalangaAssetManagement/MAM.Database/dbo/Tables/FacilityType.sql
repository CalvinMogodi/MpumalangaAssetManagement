CREATE TABLE [dbo].[FacilityType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) NULL,
    [Description] VARCHAR (100) NULL,
    CONSTRAINT [PK_FacilityType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

