﻿CREATE TABLE [dbo].[Jeux]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nom] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(250) NOT NULL, 
    [CatégorieId] INT NOT NULL
)
