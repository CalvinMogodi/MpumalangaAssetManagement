CREATE TABLE [dbo].[Finances] (
    [Id]                         INT          IDENTITY (1, 1) NOT NULL,
    [LandUseClass]               VARCHAR (50) NOT NULL,
    [NatureofAsset]              VARCHAR (50) NOT NULL,
    [SecondaryInformationNoteId] INT          NOT NULL,
    [ValuationId]                INT          NOT NULL,
    CONSTRAINT [PK_Finance] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Finance_SecondaryInformationNote] FOREIGN KEY ([SecondaryInformationNoteId]) REFERENCES [dbo].[SecondaryInformationNotes] ([Id]),
    CONSTRAINT [FK_Finance_Valuation] FOREIGN KEY ([ValuationId]) REFERENCES [dbo].[Valuations] ([Id])
);

