CREATE TABLE [dbo].[SecondaryInformationNotes] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [AdditionCash]    FLOAT (53) NULL,
    [AdditionNonCash] FLOAT (53) NULL,
    [Addition]        FLOAT (53) NULL,
    [Disposal]        FLOAT (53) NULL,
    [ClosingBalance]  FLOAT (53) NULL,
    CONSTRAINT [PK_SecondaryInformationNote] PRIMARY KEY CLUSTERED ([Id] ASC)
);

