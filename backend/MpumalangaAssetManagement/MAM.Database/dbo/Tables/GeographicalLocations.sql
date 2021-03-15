CREATE TABLE [dbo].[GeographicalLocations] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [Province]             VARCHAR (20) NOT NULL,
    [Town]                 VARCHAR (50) NULL,
    [Suburb]               VARCHAR (50) NULL,
    [StreetName]           VARCHAR (50) NULL,
    [StreetNumber]         INT          NULL,
    [DistrictMunicipality] VARCHAR (50) NULL,
    [Region]               VARCHAR (50) NULL,
    [LocalAuthority]       VARCHAR (50) NULL,
    [Latitude]             VARCHAR (50) NULL,
    [Longitude]            VARCHAR (50) NULL,
    [MagisterialDistrict]  VARCHAR (50) NULL,
    CONSTRAINT [PK_GeographicalLocation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

