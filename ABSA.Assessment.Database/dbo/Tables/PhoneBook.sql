﻿CREATE TABLE [dbo].[PhoneBook] (
    [PhoneBookId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PhoneBook] PRIMARY KEY CLUSTERED ([PhoneBookId] ASC)
);





