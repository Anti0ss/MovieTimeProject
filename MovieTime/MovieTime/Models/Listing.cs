using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public int AvisUtil { get; set; }
        public bool Visionnage { get; set; }
        public ApplicationUser User { get; set; }
        public Film Film { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public Listing(int id, int avisUtil, bool visionnage, ApplicationUser user, Film film)
        {
            Id = id;
            AvisUtil = avisUtil;
            Visionnage = visionnage;
            User = user;
            Film = film;
        }
    }
}
