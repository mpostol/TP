CREATE TABLE [dbo].[Persons] (
    [PersonId]  INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Age]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonId] ASC)
);
