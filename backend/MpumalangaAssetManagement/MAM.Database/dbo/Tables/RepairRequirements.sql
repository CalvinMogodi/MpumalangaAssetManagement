CREATE TABLE [dbo].[RepairRequirements]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Province] NVARCHAR(50) NULL, 
    [Town] NVARCHAR(50) NULL, 
    [UniqueIdentifyingCode] NVARCHAR(50) NULL, 
    [RepairDescription] NVARCHAR(MAX) NULL, 
    [BudgetType] NVARCHAR(MAX) NULL, 
    [Status] NVARCHAR(MAX) NULL, 
    [ExpenditureEstimate] NUMERIC NULL, 
    [ExpenditureEstimateYear1] NUMERIC NULL, 
    [ExpenditureEstimateYear2] NUMERIC NULL, 
    [ExpenditureEstimateYear3] NUMERIC NULL, 
    [UserId] INT NOT NULL
)
