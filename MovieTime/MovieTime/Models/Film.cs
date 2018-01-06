using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string Realisateur { get; set; }
        public double AvisDuSite { get; set; }
        public Categorie Categorie { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public Film(int filmId, string titre, string description, int duree, DateTime dateSortie, string realisateur, double avisDuSite, Categorie categorie)
        {
            FilmId = filmId;
            Titre = titre;
            Description = description;
            Duree = duree;
            DateSortie = dateSortie;
            Realisateur = realisateur;
            AvisDuSite = avisDuSite;
            Categorie = categorie;
        }
    }
}
