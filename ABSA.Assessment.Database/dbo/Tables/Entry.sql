CREATE TABLE [dbo].[Entry] (
    [EntryId]     INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [PhoneNumber] VARCHAR (50) NOT NULL,
    [PhoneBookId] INT          NOT NULL,
    CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED ([EntryId] ASC),
    CONSTRAINT [FK_Entry_PhoneBook] FOREIGN KEY ([PhoneBookId]) REFERENCES [dbo].[PhoneBook] ([PhoneBookId])
);



