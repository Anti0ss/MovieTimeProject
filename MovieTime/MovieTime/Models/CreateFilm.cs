using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class CreateFilm
    {
        public int IdCategorie { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string Realisateur { get; set; }
        public double AvisDuSite { get; set; }
        


        public CreateFilm(int idCategorie, string titre, string description, int duree, DateTime dateSortie, string realisateur, double avisDuSite)
        {
            IdCategorie = idCategorie;
            Titre = titre;
            Description = description;
            Duree = duree;
            DateSortie = dateSortie;
            Realisateur = realisateur;
            AvisDuSite = avisDuSite;
        }
    }
}
