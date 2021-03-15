CREATE TABLE [dbo].[Valuations] (
    [Id]                          INT          IDENTITY (1, 1) NOT NULL,
    [MunicipalValuationDate]      DATETIME     NULL,
    [NonMunicipalValuationDate]   DATETIME     NULL,
    [MunicipalValuation]          VARCHAR (50) NULL,
    [NonMunicipalValuation]       VARCHAR (50) NULL,
    [PropetyRatesAccount]         VARCHAR (50) NULL,
    [Value]                       VARCHAR (50) NULL,
    [AccountNoForService]         VARCHAR (50) NULL,
    [PersonInstitutionResposible] VARCHAR (50) NULL,
    CONSTRAINT [PK_Valuation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

