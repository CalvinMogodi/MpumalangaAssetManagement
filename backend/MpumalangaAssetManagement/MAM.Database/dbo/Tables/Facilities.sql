CREATE TABLE [dbo].[Facilities] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [FileReference] VARCHAR (50) NOT NULL,
    [Type]          VARCHAR (50) NOT NULL,
    [ClientCode]    VARCHAR (50) NOT NULL,
    [Status]        VARCHAR (50) NOT NULL,
    [UserId]        INT          NOT NULL,
    [LandId]        INT          NOT NULL,
    [FinanceId]     INT          NOT NULL,
    [CreatedBy]     INT          NOT NULL,
    [CreatedDate]   DATETIME     NOT NULL,
    [ModifiedBy]    INT          NULL,
    [ModifiedDate]  DATETIME     NULL,
    CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Facilities_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Facility_Finance] FOREIGN KEY ([FinanceId]) REFERENCES [dbo].[Finances] ([Id]),
    CONSTRAINT [FK_Facility_Land] FOREIGN KEY ([LandId]) REFERENCES [dbo].[Lands] ([Id])
);

