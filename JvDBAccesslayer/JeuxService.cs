using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JvDBAccesslayer
{
    public class JeuxService
    {
        private string _connectionString = @"Data Source=DESKTOP-0PJ4SJR;Initial Catalog=CollectionJvDB;Integrated Security=True;";

        public void AjouterJeu(Jeux jeux)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand  cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO Jeux (Nom, Description) VALUES (@nom, @desc)";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("nom", jeux.Nom);
                    cmd.Parameters.AddWithValue("desc", jeux.Description);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }
        public void AjouterCategorie(Categorie categorie)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO Categorie (Nom) VALUES (@nom)";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("nom", categorie.Nom);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }
        public void AjouterJeuCategorie(JeuxCategorie jeucat)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO [dbo].[Jeu-Catégorie] (IdJeu, IdCat) VALUES (@IdJeu, @IdCat)";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("Idjeu", jeucat.IdJeu);
                    cmd.Parameters.AddWithValue("IdCat", jeucat.IdCat);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }
        public List<Categorie> Affichercategorie()
        {
            List<Categorie> list = new List<Categorie>();

            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Categorie";
                    cmd.CommandText = sql;
                    cnx.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Categorie
                            {
                                Id = (int)r["Id"],
                                Nom = (string)r["Nom"]
                            });
                        }
                    }
                    cnx.Close();
                }
            }
            return list;
        }
        public List<Jeux> AfficherJeux()
        {
            List<Jeux> list = new List<Jeux>();

            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Jeux";
                    cmd.CommandText = sql;
                    cnx.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Jeux
                            {
                                Id = (int)r["Id"],
                                Nom = (string)r["Nom"]
                            });
                        }
                    }
                    cnx.Close();
                }
            }
            return list;
        }
        public int GetLastInsertedJeuxId()
        {
            int Id;
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT TOP(1) Id FROM JEUX ORDER BY Id Desc";
                    cmd.CommandText = sql;
                    cnx.Open();
                    Id = (int)cmd.ExecuteScalar();
                    cnx.Close(); 
                }
            }
            return Id;
        } 
        public void Modifier(int Id, string Nom, string Desc)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = $"Update Jeu SET Nom ='{Nom}', Description = '{Desc}' WHERE Id ={Id}";
                    cmd.CommandText = sql;
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close() ;
                }
            }
        }
    }
}
