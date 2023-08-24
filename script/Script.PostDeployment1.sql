/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Categorie (Nom) VALUES ('Aventure');
INSERT INTO Categorie (Nom) VALUES ('Action');
INSERT INTO Categorie (Nom) VALUES ('RPG');

INSERT INTO Jeux (Nom, Description) VALUES ('Wow', 'Le meilleur MMO');
INSERT INTO Jeux (Nom, Description) VALUES ('LoL', 'Un jeu nul');

INSERT INTO [Jeu-Catégorie] (IdJeu, IdCat) VALUES (1, 3);
INSERT INTO [Jeu-Catégorie] (IdJeu, IdCat) VALUES (2, 2);