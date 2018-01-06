using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class Categorie
    {
        public int IdCategorie { get; set; }
        public string NomCategorie { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public Categorie(int idCategorie, string nomCategorie)
        {
            IdCategorie = idCategorie;
            NomCategorie = nomCategorie;
        }
    }
}
