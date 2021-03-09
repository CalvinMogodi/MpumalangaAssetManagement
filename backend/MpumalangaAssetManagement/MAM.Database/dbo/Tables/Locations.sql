CREATE TABLE [dbo].[Locations] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [StreetName]           VARCHAR (100) NULL,
    [Suburb]               VARCHAR (100) NULL,
    [Town]                 VARCHAR (100) NULL,
    [Province]             VARCHAR (100) NULL,
    [MagisterialDistrict]  VARCHAR (100) NULL,
    [DistrictMunicipality] VARCHAR (100) NULL,
    [LocalMunicipality]    VARCHAR (100) NULL,
    [ClientCode]           VARCHAR (100) NULL,
    CONSTRAINT [PK_DwellingFacilities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

