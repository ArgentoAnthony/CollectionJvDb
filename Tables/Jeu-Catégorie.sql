CREATE TABLE [dbo].[Jeu-Catégorie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdJeu] INT NOT NULL, 
    [IdCat] INT NOT NULL, 
    CONSTRAINT [FK_Jeu-Catégorie_jeu] FOREIGN KEY (IdJeu) REFERENCES Jeux(Id), 
    CONSTRAINT [FK_Jeu-Catégorie_Categorie] FOREIGN KEY (IdCat) REFERENCES Categorie(Id)
)
