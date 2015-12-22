CREATE TABLE [dbo].[SubTopics] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NULL,
    [TopicID] INT            NOT NULL,
    CONSTRAINT [PK_dbo.SubTopics] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.SubTopics_dbo.Topics_TopicID] FOREIGN KEY ([TopicID]) REFERENCES [dbo].[Topics] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TopicID]
    ON [dbo].[SubTopics]([TopicID] ASC);

