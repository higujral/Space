CREATE TABLE [dbo].[StoryFeedbacks] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [StoryID] INT            NOT NULL,
    [Rating]  INT            NOT NULL,
    [Comment] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.StoryFeedbacks] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.StoryFeedbacks_dbo.Stories_StoryID] FOREIGN KEY ([StoryID]) REFERENCES [dbo].[Stories] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StoryID]
    ON [dbo].[StoryFeedbacks]([StoryID] ASC);

