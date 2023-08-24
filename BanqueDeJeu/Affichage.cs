using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JvDBAccesslayer;

namespace BanqueDeJeu
{
    internal class Affichage
    {
        public void AjouterJeu()
        {
            Jeux jeux = new Jeux();
            JeuxCategorie jeucat = new JeuxCategorie();

            Console.WriteLine("Nom du jeu:");
            jeux.Nom = Console.ReadLine();

            Console.WriteLine("Description:");
            jeux.Description = Console.ReadLine();

            Console.WriteLine("Catégorie:");
            AfficherCatégorie();
            
            jeucat.IdCat = int.Parse(Console.ReadLine());

            JeuxService service = new JeuxService();
            service.AjouterJeu(jeux);

            // Récupérer l'ID du jeu inséré
            jeucat.IdJeu = service.GetLastInsertedJeuxId();

            // Insérer une ligne dans la table Jeu-Catégorie pour lier le jeu à la catégorie
            service.AjouterJeuCategorie(jeucat);
        }
        public void AjouterCategorie()
        {
            Categorie categorie = new Categorie();

            Console.WriteLine("Nom de la catégorie:");
            categorie.Nom = Console.ReadLine();

            JeuxService service = new JeuxService();
            service.AjouterCategorie(categorie);
        }

        public void AfficherCatégorie()
        {
            JeuxService service = new JeuxService();
            foreach (Categorie C in service.Affichercategorie())
            {
                Console.WriteLine(C.Id +" "+C.Nom);
            }
        }
        public void AfficherJeux()
        {
            JeuxService service = new JeuxService();
            foreach (Jeux j in service.AfficherJeux())
            {
                Console.WriteLine(j.Id +" "+j.Nom);
            }
        }
        public void Modifier()
        {
            JeuxService service = new JeuxService();
            AfficherJeux();
            Console.WriteLine("Quel jeu souhaitez vous modifier?");
            int IdModif = int.Parse(Console.ReadLine());

            Console.WriteLine("Nouveau nom:");
            string NouvNom = Console.ReadLine();
            Console.WriteLine("Nouvelle description:");
            string NouvDesc = Console.ReadLine();

            service.Modifier(IdModif, NouvNom, NouvDesc);
        }
    }
}
