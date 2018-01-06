using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>  //DropCreateDatabaseAlways
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Categorie categorie1 = new Categorie()
            {
                NomCategorie = "Action"
            };

            Categorie categorie2 = new Categorie()
            {
                NomCategorie = "Animation"
            };

            Categorie categorie3 = new Categorie()
            {
                NomCategorie = "Aventure"
            };

            Categorie categorie4 = new Categorie()
            {
                NomCategorie = "Biographie"
            };
            Categorie categorie5 = new Categorie()
            {
                NomCategorie = "Comédie"
            };

            Categorie categorie6 = new Categorie()
            {
                NomCategorie = "Drame"
            };

            Categorie categorie7 = new Categorie()
            {
                NomCategorie = "Fantastique"
            };

            Categorie categorie8 = new Categorie()
            {
                NomCategorie = "Guerre"
            };

            Categorie categorie9 = new Categorie()
            {
                NomCategorie = "Historique"
            };

            Categorie categorie10 = new Categorie()
            {
                NomCategorie = "Horreur"
            };

            Categorie categorie11 = new Categorie()
            {
                NomCategorie = "Policier"
            };

            Categorie categorie12 = new Categorie()
            {
                NomCategorie = "Romantique"
            };

            Categorie categorie13 = new Categorie()
            {
                NomCategorie = "Science-Fiction"
            };
            Categorie categorie14 = new Categorie()
            {
                NomCategorie = "Thriller"
            };

            Categorie categorie15 = new Categorie()
            {
                NomCategorie = "Western"
            };



            Film film1 = new Film()
            {
                Titre = "Star Wars : Episode V - L'Empire contre-attaque",
                Description = "Malgré la destruction de l'Etoile Noire, l'Empire maintient son emprise sur la galaxie, et poursuit sans relâche sa lutte contre l'Alliance rebelle.",
                Duree = 124,
                DateSortie = new DateTime(1980, 08, 20),
                Realisateur = "George Lucas",
                AvisDuSite = 9,
                Categorie = categorie13
            };

            Film film2 = new Film()
            {
                Titre = "300",
                Description = "Adapté du roman graphique de Frank Miller, 300 est un récit épique de la Bataille des Thermopyles, qui opposa en l'an - 480 le roi Léonidas et 300 soldats spartiates à Xerxès et l'immense armée perse.",
                Duree = 161,
                DateSortie = new DateTime(2007, 03, 21),
                Realisateur = "Zack Snyder",
                AvisDuSite = 8,
                Categorie = categorie9
            };

            Film film3 = new Film()
            {
                Titre = "Il faut sauver le soldat Ryan",
                Description = "Alors que les forces alliées débarquent à Omaha Beach, Miller doit conduire son escouade derrière les lignes ennemies pour une mission particulièrement dangereuse : trouver et ramener sain et sauf le simple soldat James Ryan, dont les trois frères sont morts au combat en l'espace de trois jours. ",
                Duree = 163,
                DateSortie = new DateTime(1998, 09, 30),
                Realisateur = "Steven Spielberg",
                AvisDuSite = 7,
                Categorie = categorie8
            };

            Film film4 = new Film()
            {
                Titre = "Pulp Fiction",
                Description = "L'odyssée sanglante et burlesque de petits malfrats dans la jungle de Hollywood à travers trois histoires qui s'entremêlent.",
                Duree = 149,
                DateSortie = new DateTime(1994, 10, 26),
                Realisateur = "Quentin Tarantino",
                AvisDuSite = 8,
                Categorie = categorie11
            };



            /*ApplicationUser superAdmin = new ApplicationUser()
            {
                Pseudo = "superAdmin",
                Nom = "Flantier",
                Prenom = "Etienne",
                Email = "MovieTie@support.be",
                PasswordHash = "Test*123",
                Admin = true
            };*/


            context.Categorie.Add(categorie1);
            context.Categorie.Add(categorie2);
            context.Categorie.Add(categorie3);
            context.Categorie.Add(categorie4);
            context.Categorie.Add(categorie5);
            context.Categorie.Add(categorie6);
            context.Categorie.Add(categorie7);
            context.Categorie.Add(categorie8);
            context.Categorie.Add(categorie9);
            context.Categorie.Add(categorie10);
            context.Categorie.Add(categorie11);
            context.Categorie.Add(categorie12);
            context.Categorie.Add(categorie13);
            context.Categorie.Add(categorie14);
            context.Categorie.Add(categorie15);

            context.SaveChanges();

            context.Film.Add(film1);
            context.Film.Add(film2);
            context.Film.Add(film3);
            context.Film.Add(film4);

            context.SaveChanges();
        }
    }
}