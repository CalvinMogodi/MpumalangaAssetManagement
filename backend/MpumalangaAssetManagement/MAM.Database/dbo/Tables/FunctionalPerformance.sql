CREATE TABLE [dbo].[FunctionalPerformance]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Province] NVARCHAR(50) NULL, 
    [Town] NVARCHAR(50) NULL, 
    [UniqueIdentifyingCode] NVARCHAR(50) NULL, 
    [PossibleNonAssetSolution] NVARCHAR(50) NULL, 
    [CommonAssetDescription] NVARCHAR(MAX) NULL, 
    [CurrentUser] NVARCHAR(50) NULL, 
    [RequiredPerformanceStandard] NVARCHAR(MAX) NULL, 
    [AccessibilityRating] NVARCHAR(50) NULL, 
    [SuitabilityIndex] NVARCHAR(50) NULL, 
    [ConditionalRating] NVARCHAR(50) NULL, 
    [OperatingPerformanceIndex] NVARCHAR(MAX) NULL, 
    [FunctionalPerformanceRating] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL
)
