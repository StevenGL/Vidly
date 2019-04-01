using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name.")]
        public string Name { get; set; }
        [Display(Name= "Movie Genre")]
        [Required(ErrorMessage = "Movie Genre is required.")]
        public int GenreId { get; set; }

        [Display(Name="Genre")]
        public Genre Genre { get; set; }

        [Range(1,20)]
        [Display(Name = "Number in stock")]
        public int Stock { get; set; }

        [Display(Name="Realese Date")]
        public DateTime RealeseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

    }
}