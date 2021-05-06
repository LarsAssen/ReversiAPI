CREATE TABLE [dbo].[Game]
(
[GUID] INT NOT NULL PRIMARY KEY IDENTITY,
[Omschrijving] VARCHAR(255) NULL,
[Speler1Token] INT NULL,
[Speler2Token] INT NULL,
[GameState] INT NULL
)