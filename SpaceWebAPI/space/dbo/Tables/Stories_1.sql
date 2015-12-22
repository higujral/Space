CREATE TABLE [dbo].[Stories] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Content]          NVARCHAR (MAX) NULL,
    [StoryTypeID]      INT            NOT NULL,
    [Title]            NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [DateCreated]      DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [DateLastModified] DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    CONSTRAINT [PK_dbo.Stories] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Stories_dbo.StoryTypes_StoryTypeID] FOREIGN KEY ([StoryTypeID]) REFERENCES [dbo].[StoryTypes] ([ID]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_StoryTypeID]
    ON [dbo].[Stories]([StoryTypeID] ASC);

