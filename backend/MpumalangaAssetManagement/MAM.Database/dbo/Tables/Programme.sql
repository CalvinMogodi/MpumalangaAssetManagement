CREATE TABLE [dbo].[Programme]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [PlannedOutputs] NVARCHAR(MAX) NULL, 
    [RequiredServiceLevel] NVARCHAR(MAX) NULL, 
    [PossibleNonAssetSolutions] NVARCHAR(MAX) NULL, 
    [OptimalAssetSolution] NVARCHAR(MAX) NULL, 
    [Motivation] NVARCHAR(MAX) NULL, 
    [RationaleForChosenSolution] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL
)
