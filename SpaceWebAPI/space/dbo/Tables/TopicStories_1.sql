CREATE TABLE [dbo].[TopicStories] (
    [Topic_ID] INT NOT NULL,
    [Story_ID] INT NOT NULL,
    CONSTRAINT [PK_dbo.TopicStories] PRIMARY KEY CLUSTERED ([Topic_ID] ASC, [Story_ID] ASC),
    CONSTRAINT [FK_dbo.TopicStories_dbo.Stories_Story_ID] FOREIGN KEY ([Story_ID]) REFERENCES [dbo].[Stories] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TopicStories_dbo.Topics_Topic_ID] FOREIGN KEY ([Topic_ID]) REFERENCES [dbo].[Topics] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Topic_ID]
    ON [dbo].[TopicStories]([Topic_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Story_ID]
    ON [dbo].[TopicStories]([Story_ID] ASC);

