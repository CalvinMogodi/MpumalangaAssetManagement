CREATE TABLE [dbo].[FacilityStatements] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [OpeningBalance]  VARCHAR (100) NULL,
    [ValueAdjustment] VARCHAR (100) NULL,
    [PpeaIN]          VARCHAR (100) NULL,
    [PpeaOut]         VARCHAR (100) NULL,
    [Disposal]        VARCHAR (100) NULL,
    [Additions]       VARCHAR (100) NULL,
    [Year]            INT           NULL,
    [ClosingBalance]  VARCHAR (100) NULL,
    [ClientCode]      VARCHAR (100) NULL,
    [FacilityType]    INT           NULL
);

