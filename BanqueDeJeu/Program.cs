using BanqueDeJeu;
using JvDBAccesslayer;

int choix;
do
{

    Affichage affichage = new Affichage();

    Console.WriteLine("Que voulez vous faire?");
    Console.WriteLine("1 - Ajouter un jeu");
    Console.WriteLine("2 - Ajouter une catégorie");
    Console.WriteLine("3 - Afficher les jeux");
    Console.WriteLine("4 - Afficher les catégories");
    Console.WriteLine("0 - Quitter");

    choix = int.Parse(Console.ReadLine());

    switch (choix)
    {
        case 1:
            affichage.AjouterJeu();
            break;
        case 2:
            affichage.AjouterCategorie();
            break;
        case 3:
            affichage.AfficherJeux();
            break;
        case 4:
            affichage.AfficherCatégorie();
            break;

    }

} while (choix != 0);



