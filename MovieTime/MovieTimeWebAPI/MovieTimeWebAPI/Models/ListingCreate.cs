using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class ListingCreate
    {
        [Required]
        public int AvisUtil { get; set; }

        [Required]
        public bool Visionnage { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        public int FilmId { get; set; }
    }
}