CREATE TABLE [dbo].[PropertyDescriptions] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [RegistrationDivision] VARCHAR (50) NULL,
    [TownshipName]         VARCHAR (50) NULL,
    [LandParcel]           VARCHAR (50) NULL,
    [LandPortion]          VARCHAR (50) NULL,
    [OldDescription]       VARCHAR (50) NULL,
    [LandRemainder]        BIT          NULL,
    [FarmName]             VARCHAR (50) NULL,
    [SGDiagramNumber]      INT          NULL,
    [Extent]               INT          NULL,
    [LPICode]              VARCHAR (50) NULL,
    [Acquired]             VARCHAR (50) NULL,
    [AcquiredOther]        VARCHAR (50) NULL,
    CONSTRAINT [PK_PropertyDescription] PRIMARY KEY CLUSTERED ([Id] ASC)
);

