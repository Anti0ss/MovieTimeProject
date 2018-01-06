using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListingId { get; set; }

        public int AvisUtil { get; set; }
        [Required]
        public bool Visionnage { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public virtual Film Film { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}