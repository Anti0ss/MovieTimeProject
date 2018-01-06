using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class CreateFilm
    {
        [Required]
        public int IdCategorie { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duree { get; set; }
        [Required]
        public DateTime DateSortie { get; set; }
        [Required]
        public string Realisateur { get; set; }
        public double AvisDuSite { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}