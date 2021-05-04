CREATE TABLE [dbo].[Utilisation]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Post] NVARCHAR(MAX) NULL, 
    [RequiredSpace] NVARCHAR(MAX) NULL, 
    [AllocatedSpace] NVARCHAR(MAX) NULL, 
    [PercentageUtilised] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL
)
