using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mdp { get; set; }
        public string Mail { get; set; }
        public string NumTel { get; set; }
        public bool Type { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public ApplicationUser(int id, string pseudo, string nom, string prenom, string mdp, string mail, string numTel)
        {
            Id = id;
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
            Mail = mail;
            NumTel = numTel;
        }
    }
}
