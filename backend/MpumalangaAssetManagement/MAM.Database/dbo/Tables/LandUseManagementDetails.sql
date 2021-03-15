CREATE TABLE [dbo].[LandUseManagementDetails] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [TitleDeedNumber]      VARCHAR (50) NULL,
    [RegistrationDate]     DATETIME     NULL,
    [RegisteredOwner]      VARCHAR (50) NULL,
    [VestingDate]          DATETIME     NULL,
    [ConditionsOfTitle]    VARCHAR (50) NULL,
    [OwnershipCategory]    VARCHAR (50) NULL,
    [StateOwnedPercentage] INT          NULL,
    [LandUse]              VARCHAR (50) NULL,
    [Zoning]               VARCHAR (50) NULL,
    [UserDepartment]       VARCHAR (50) NULL,
    [FacilityName]         VARCHAR (50) NULL,
    [IncomeLeaseStatus]    VARCHAR (50) NULL,
    CONSTRAINT [PK_LandUseManagementDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);

