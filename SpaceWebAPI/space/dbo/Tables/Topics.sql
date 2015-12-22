CREATE TABLE [dbo].[Topics] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (450) NULL,
    CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UniqueIndex]
    ON [dbo].[Topics]([Name] ASC);

