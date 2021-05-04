CREATE TABLE [dbo].[GapAnalyses]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Programme] NVARCHAR(MAX) NULL, 
    [OptimalAssets] NVARCHAR(MAX) NULL, 
    [GapOptimalAssetsUtilisedAssets] NVARCHAR(MAX) NULL, 
    [QuantifiedNeedStatement] NVARCHAR(MAX) NULL, 
    [Priority] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL
)
