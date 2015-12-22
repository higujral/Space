CREATE TABLE [dbo].[StoryTypes] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.StoryTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

