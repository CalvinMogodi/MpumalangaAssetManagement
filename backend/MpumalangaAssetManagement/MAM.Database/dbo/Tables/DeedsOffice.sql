CREATE TABLE [dbo].[DeedsOffice] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [DeedsOffice]      VARCHAR (100) NULL,
    [TitleDeeds]       VARCHAR (100) NULL,
    [RegistrationDate] VARCHAR (100) NULL,
    [ClientCode]       VARCHAR (100) NULL,
    CONSTRAINT [PK_DeedsOffice] PRIMARY KEY CLUSTERED ([Id] ASC)
);

